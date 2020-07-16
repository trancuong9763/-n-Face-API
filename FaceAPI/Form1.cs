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
namespace FaceAPI
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection camera;
        private VideoCaptureDevice cam;
        private readonly IFaceServiceClient faceServiceClient = new FaceServiceClient("9ca99975e1f54cb6a5b39b0d1c9d6a52");
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
            if(cam!=null && cam.IsRunning)
            {
                cam.Stop();
            }
            cam = new VideoCaptureDevice(camera[0].MonikerString);
            cam.NewFrame += Cam_NewFrame;
            cam.Start();
        }

        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            imgBox.Image = bitmap; 
        }
    }
}
