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
using BUS;
using DTO;
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
            LoadDSSV();
        }

        private void dgvDSSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        protected void LoadDSSV()
        {

            dgvDSSV.DataSource = SinhVienBUS.LayDSSV();

        }
        protected void XoaForm()
        {
            
            txtMSSV.Text = string.Empty;
            txtHoten.Text = string.Empty;
            txtLop.Text = string.Empty;
        }
        protected void GiaoDienThem(bool gd)
        {


            
            addface = true;


            txtMSSV.Enabled = gd;
            txtHoten.Enabled = gd;
            txtLop.Enabled = gd;
            btnThem.Enabled = gd;
            
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

            SinhVienDTO sv = new SinhVienDTO();
            sv.Ma_SV = txtMSSV.Text.Trim();
            sv.Ten_SV = System.Text.RegularExpressions.Regex.Replace(txtHoten.Text.Trim(), @"[\s+]", ""); //Ham cat khoang cach cua chuoi
            sv.Ma_Lop = txtLop.Text.Trim(); ;
            int dem = 0;

            if(dem ==0)
            {
                if (SinhVienBUS.ThemSV(sv))
                {
                    addface = true;
                   
                    LoadDSSV();
                    GiaoDienThem(true);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
                dem = dem + 1;
            }
            else
            {
                addface = true;
                XoaForm();
            }


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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SinhVienDTO sv = new SinhVienDTO();
            sv.Ma_SV = txtMSSV.Text;
                if (SinhVienBUS.XoaSV(sv))
            {
                XoaForm();
                LoadDSSV();
            }
            else
            {
                MessageBox.Show("Xóa Thất bại");
            }
        }

        private void dgvDSSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSSV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                txtMSSV.Enabled = false;
                GiaoDienThem(false);
                dgvDSSV.CurrentRow.Selected = true;
                txtMSSV.Text = dgvDSSV.Rows[e.RowIndex].Cells["Ma_SV"].FormattedValue.ToString();
                txtHoten.Text = dgvDSSV.Rows[e.RowIndex].Cells["Ten_SV"].FormattedValue.ToString();
                txtLop.Text = dgvDSSV.Rows[e.RowIndex].Cells["MaLop"].FormattedValue.ToString();
            }
        }
    }
}
