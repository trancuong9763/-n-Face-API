using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.IO;
using System.Threading;
using System.Diagnostics;
namespace FaceAPI
{
    public partial class DanhSachSV : Form
    {
        private Capture quayVideo = null;
        static readonly CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt.xml");
        Mat frame = new Mat();
        private Image<Bgr, Byte> currentFrame = null;
        private bool addface = false;
        private bool facederection = false;
        public DanhSachSV()
        {
            InitializeComponent();
          
        }

        private void dgvDSSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            addface = true;
        }

        private void StartFrame(object sender, EventArgs e)
        {

            quayVideo.Retrieve(frame, 0);
            currentFrame = frame.ToImage<Bgr, Byte>().Resize(320,240, Inter.Cubic);
       
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
            CvInvoke.EqualizeHist(grayImage, grayImage);
            Rectangle[] faces = cascadeClassifier.DetectMultiScale(grayImage, 1.2, 10, new Size(20,20));


                if (faces.Length > 0)
                {
                    foreach (var face in faces)
                    {
                        // vẽ hình vuông vào mặt
                        CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                        //add khuôn mặt : resualtFace
                        Image<Gray, Byte> resualtFace = currentFrame.Convert<Gray, Byte>();
                        resualtFace.ROI = face;
                        picBox2.SizeMode = PictureBoxSizeMode.StretchImage;// Chỉnh size cho imagebox;
                        picBox2.Image = resualtFace.Bitmap;

                        if (addface)
                        {
                            string path = Directory.GetCurrentDirectory() + @"\TrainedImages";//Tạo thư mục Trained trong debug
                            if (!Directory.Exists(path))
                                Directory.CreateDirectory(path);
                            Task.Factory.StartNew(() =>
                            {
                                
                                    resualtFace.Resize(100, 100, Inter.Cubic).Save(path + @"\" + txtHoten.Text + "_" + txtMSSV.Text + "_" + txtLop.Text + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".bmp");
                                    Thread.Sleep(1000);
                      
                            });
                        }
                        addface = false;
                        if (btnThem.InvokeRequired)
                        {
                            btnThem.Invoke(new ThreadStart(delegate {
                                btnThem.Enabled = true;
                            }));
                        }
                    }  
                }
            picBox.Image = currentFrame.Bitmap;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            quayVideo = new Capture();
            quayVideo.ImageGrabbed += StartFrame;
            quayVideo.Start();
        }
    }
}
