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
        int dem = 1;
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
            
            txtMSSV.Text = "";
            txtHoten.Text ="";
            txtLop.Text = "" ;
        }
        protected void GiaoDienThem(bool gd)
        {
            txtMSSV.Enabled = gd;
            txtHoten.Enabled = gd;
            txtLop.Enabled = gd;
            btnThem.Enabled = gd;
            
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            
            SinhVienDTO sv = new SinhVienDTO();
            sv.Ma_SV = txtMSSV.Text;
            sv.Ten_SV = txtHoten.Text;
            sv.Ma_Lop = txtLop.Text; ;
            
            if (txtMSSV.Text == "" || txtHoten.Text == "" || txtLop.Text == "")
            {
                MessageBox.Show("Thông tin không được để trống");
            }
            else
            {
                
                if(dem == 1)
                {
                    if (SinhVienBUS.ThemSV(sv))
                    {
                        addface = true;
                        MessageBox.Show("Bạn Hãy Thêm Vào 5 Khuôn Mặt");
                        MessageBox.Show("Thêm Khuông Mặt Thứ: " + dem + " Thành Công");
                        LoadDSSV();
                        txtHoten.Enabled = false;
                        txtLop.Enabled = false;
                        txtMSSV.Enabled = false;
                        dem++;
                    }
                    else
                    {
                        MessageBox.Show("Sinh viên đã tồn tại");
                    }             
                }
                else if (dem > 1 && dem<=5)
                {
                    addface = true;
                    MessageBox.Show("Thêm Khuông Mặt Thứ: " + dem + " Thành Công");
                    dem++;
                    if(dem==6)
                    {
                        MessageBox.Show("Thêm sinh viên thành công");
                        txtHoten.Enabled = true;
                        txtLop.Enabled = true;
                        txtMSSV.Enabled = true;
                        txtHoten.Text = "";
                        txtLop.Text = "";
                        txtMSSV.Text = "";
                        dem = 1;
                    }
                    
                }
                else
                {

                    MessageBox.Show("Thêm sinh viên không thành công");

                   
                }
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
                                
                                    resualtFace.Resize(100, 100, Inter.Cubic).Save(path + @"\" + System.Text.RegularExpressions.Regex.Replace(txtHoten.Text.Trim(), @"[\s+]", "") + "_" + txtMSSV.Text.Trim() + "_" + txtLop.Text.Trim() + "_" + dem + ".bmp");
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
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc là muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (SinhVienBUS.XoaSV(sv))
                {
                    for (int i = 1; i <= 5; i++)
                    {

                        string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                        string[] files = Directory.GetFiles(path, txtHoten.Text + "_" + txtMSSV.Text + "_" + txtLop.Text + "_" + i + "*.bmp", SearchOption.AllDirectories);
                        foreach (var file in files)
                        {
                            File.Delete(file);
                           
                        }
                    }
                    MessageBox.Show("Xóa thành công");
                    XoaForm();
                    LoadDSSV();

                }
                else
                {
                    MessageBox.Show("Xóa Thất bại");
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void dgvDSSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1 && dgvDSSV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                
               
                dgvDSSV.CurrentRow.Selected = true;
                txtMSSV.Text = dgvDSSV.Rows[e.RowIndex].Cells["Ma_SV"].FormattedValue.ToString();
                txtHoten.Text = dgvDSSV.Rows[e.RowIndex].Cells["Ten_SV"].FormattedValue.ToString();
                txtLop.Text = dgvDSSV.Rows[e.RowIndex].Cells["MaLop"].FormattedValue.ToString();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(quayVideo!=null)
            {
                quayVideo.Stop();
            }
           
        }
    }
}
