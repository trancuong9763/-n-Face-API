using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace FaceAPI
{
    public partial class Main : Form
    {
        //private FilterInfoCollection camera;
        //private VideoCaptureDevice cam;

        private Capture quayVideo = null;
        static readonly CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt.xml");
        Mat frame = new Mat();
        private bool facederection = false;//nhan diện khuôn mặt
        private bool addFace = false;// save khuôn mặt
        private Image<Bgr, Byte> currentFrame = null;// khuôn mặt hiện tại
        private bool isTrained = false;// Kiểm tra khuôn mặt

        EigenFaceRecognizer recognizer;
        List<string> PersonsNames = new List<string>();
        List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, byte>>();
        List<int> PersonsLabes = new List<int>();

        string names = null;
        //bool ktImg = false;



        public Main()
        {
            InitializeComponent();
            //camera = new FilterInfoCollection(FilterCategory.VideoInputDevice);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
            lblNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblGio.Text = DateTime.Now.ToString("HH:mm:ss");
            timer.Start();
        }

        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
          
            facederection = true;
            TrainImagesFromDir();
            //cam = new VideoCaptureDevice(camera[0].MonikerString);


        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            quayVideo.Retrieve(frame, 0);
            currentFrame = frame.ToImage<Bgr, Byte>().Resize(imgBox.Width, imgBox.Height, Inter.Cubic);


            //nhận diện khuôn mặt: facederection
            if (facederection)
            {
                Mat grayImage = new Mat();
                CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                CvInvoke.EqualizeHist(grayImage, grayImage);

                Rectangle[] faces = cascadeClassifier.DetectMultiScale(grayImage, 1.1, 3,Size.Empty,Size.Empty);
                if (faces.Length > 0)
                {
                    foreach (var face in faces)
                    {
                        // vẽ hình vuông vào mặt
                        CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                        //add khuôn mặt : resualtFace
                        Image<Bgr, Byte> resualtFace = currentFrame.Convert<Bgr, Byte>();
                        resualtFace.ROI = face;
                        imgBox2.SizeMode = PictureBoxSizeMode.StretchImage;// Chỉnh size cho imagebox;
                        imgBox2.Image = resualtFace.Bitmap;

                        if (addFace)
                        {
                            string path = Directory.GetCurrentDirectory() + @"\TrainedImages";//Tạo thư mục Trained trong debug
                            if (!Directory.Exists(path))
                                Directory.CreateDirectory(path);
                            Task.Factory.StartNew(() =>
                            {

                                resualtFace.Resize(100, 100, Inter.Cubic).Save(path + @"\" + txtTen.Text + "_" + DateTime.Now.ToString("hh-mm-ss") + ".jpg");
                                Thread.Sleep(1000);



                            });
                        }
                        addFace = false;


                        //Kết quả khuông mặt: grayFaceResult
                        if (isTrained)
                        {
                            Image<Gray, Byte> grayFaceResult = resualtFace.Convert<Gray, Byte>().Resize(100, 100, Inter.Cubic);
                            CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
                            var result = recognizer.Predict(grayFaceResult);
                            imgBox.Image = grayFaceResult.Bitmap;
                            //imgBox2.Image = TrainedFaces[result.Label].Bitmap;
                            imgBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                            //Here results found known faces
                            if (result.Label != 0 && result.Distance < 2000)
                            {
                                CvInvoke.PutText(currentFrame, PersonsNames[result.Label], new Point(face.X - 2, face.Y - 2),
                                            FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Green).MCvScalar, 2);
                                names = PersonsNames[result.Label];
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    int t = 0;
                                    if (lstDiHoc.Items.Count == 0)
                                    {
                                        lstDiHoc.Items.Add(names);
                                    }
                                    if (lstDiHoc.FindString(PersonsNames[result.Label]) != -1)
                                    {
                                        names = "";
                                    }
                                    else
                                    {
                                        lstDiHoc.Items.Add(names);
                                    }
                                }));

                            }
                            //here results did not found any know faces
                            else
                            {
                                CvInvoke.PutText(currentFrame, "Unknown", new Point(face.X - 2, face.Y - 2),
                                    FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                            }
                        }
                    }

                }
            }

            imgBox.Image = currentFrame.Bitmap;
        }






        private void btnDung_Click(object sender, EventArgs e)
        {
           

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            addFace = true;


        }



        private void btnThongKe_Click(object sender, EventArgs e)
        {
          for(int i =0; i<PersonsNames[0].Length; i++)
            {
                Debug.WriteLine(PersonsNames[i] + "test");
            }
            
        }

        private bool TrainImagesFromDir()// lấy hình ảnh trong file
        {
            double Threshold = 2000;
            int ImagesCount = 0;
            TrainedFaces.Clear();
            PersonsLabes.Clear();
            PersonsNames.Clear();
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    Image<Gray, Byte> trainedImage = new Image<Gray, Byte>(file).Resize(100, 100, Inter.Cubic);
                    CvInvoke.EqualizeHist(trainedImage, trainedImage);
                    TrainedFaces.Add(trainedImage);
                    PersonsLabes.Add(ImagesCount);
                    string name = file.Split('\\').Last().Split('_')[0];
                    PersonsNames.Add(name);
                    ImagesCount++;
                    Debug.WriteLine(ImagesCount + ". " + name);


                }
                if (TrainedFaces.Count() > 0)
                {

                    recognizer = new EigenFaceRecognizer(ImagesCount, Threshold);
                    recognizer.Train(TrainedFaces.ToArray(), PersonsLabes.ToArray());

                    isTrained = true;
                    //Debug.WriteLine(ImagesCount);
                    //Debug.WriteLine(isTrained);
                    return true;
                }
                else
                {
                    isTrained = false;
                    return false;
                }
            }
            catch (Exception ex)
            {
                isTrained = false;
                MessageBox.Show("Lỗi: " + ex.Message);
                return false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            quayVideo = new Capture();
            quayVideo.ImageGrabbed += ProcessFrame;
            quayVideo.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            quayVideo.Stop();
        }
    }
}
