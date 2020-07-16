using Microsoft.ProjectOxford.Face;
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

namespace FaceAPI
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection camera;
        private VideoCaptureDevice cam;
        private Image<Bgr, Byte> currentFrame = null;
        public Form1()
        {
            InitializeComponent();
            camera = new FilterInfoCollection(FilterCategory.VideoInputDevice);

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
            if (cam != null && cam.IsRunning)
            {
                cam.Stop();
            }
            cam = new VideoCaptureDevice(camera[0].MonikerString);
            cam.NewFrame += Cam_NewFrame;
            cam.Start();

        }

     

        static readonly CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");

        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            Image<Bgr, byte> grayImage = new Image<Bgr, byte>(bitmap);
            Rectangle[] rectangles = cascadeClassifier.DetectMultiScale(grayImage, 1.1, 3,Size.Empty,Size.Empty);
            foreach (Rectangle rectangle in rectangles)
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Pen pen = new Pen(Color.Red, 3))
                    {
                        graphics.DrawRectangle(pen, rectangle);
                    }
                }
                Image<Bgr, Byte> resultImage = grayImage.Convert<Bgr, Byte>();
                resultImage.ROI = rectangle;
                imgBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                imgBox2.Image = resultImage.Bitmap;
            }
            imgBox.Image = bitmap;
        }

        private void btnDung_Click(object sender, EventArgs e)
        {
            if (cam.IsRunning)
            {
                cam.Stop();
            }
        }
        
    }
}
