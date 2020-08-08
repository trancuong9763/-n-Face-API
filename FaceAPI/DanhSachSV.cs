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
using Microsoft.Office.Core;
using xls = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;

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
            ChonLop();

        }


        protected void LoadDSSV()
        {

            dgvDSSV.DataSource = SinhVienBUS.LayDSSV();

        }
        protected void ChonLop()
        {
            SinhVienDTO sv = new SinhVienDTO();
            cboTim.DataSource = SinhVienBUS.ChonLop(sv);

            cboTim.DisplayMember = "MaLop";
            cboTim.ValueMember = "MaLop";

        }
        protected void XoaForm()
        {

            txtMSSV.Text = "";
            txtHoten.Text = "";
            txtLop.Text = "";
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
            btnStart.Enabled = false;
            btnXoa.Enabled = false;
            btnCapNhat.Enabled = false;
            txtHoten.Enabled = false;
            txtMSSV.Enabled = false;
            txtLop.Enabled = false;
            txtTim.Enabled = false;
            btnTim.Enabled = false;
            cboTim.Enabled = false;


            SinhVienDTO sv = new SinhVienDTO();
            sv.Ma_SV = txtMSSV.Text;
            sv.Ten_SV = txtHoten.Text;
            sv.Ma_Lop = txtLop.Text; ;
            sv.TrangThai = true;
            if (txtMSSV.Text == "" || txtHoten.Text == "" || txtLop.Text == "")
            {
                MessageBox.Show("Thông tin không được để trống");
            }


            else if (r.IsMatch(txtHoten.Text) || r.IsMatch(txtLop.Text) || r.IsMatch(txtMSSV.Text))
            {
                MessageBox.Show("Thông tin không hợp lệ");
            }
            else
            {

                if (dem == 1)
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
                        txtHoten.Enabled = true;
                        txtLop.Enabled = true;
                        txtMSSV.Enabled = true;
                        txtHoten.Text = "";
                        txtLop.Text = "";
                        txtMSSV.Text = "";

                    }
                }
                else if (dem > 1 && dem <= 5)
                {
                    addface = true;
                    MessageBox.Show("Thêm Khuông Mặt Thứ: " + dem + " Thành Công");
                    dem++;
                    if (dem == 6)
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
            currentFrame = frame.ToImage<Bgr, Byte>().Resize(320, 240, Inter.Cubic);

            Mat grayImage = new Mat();
            CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
            CvInvoke.EqualizeHist(grayImage, grayImage);
            System.Drawing.Rectangle[] faces = cascadeClassifier.DetectMultiScale(grayImage, 1.2, 10, new Size(20, 20));


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
                    //if (btnThem.InvokeRequired)
                    //{
                    //    btnThem.Invoke(new ThreadStart(delegate {
                    //        btnThem.Enabled = true;
                    //    }));
                    //}
                }
            }
            picBox.Image = currentFrame.Bitmap;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnThem.Enabled = true;
            txtHoten.Enabled = true;
            txtLop.Enabled = true;
            txtMSSV.Enabled = true;
            if (quayVideo == null)
            {
                quayVideo = new Capture();
                quayVideo.ImageGrabbed += StartFrame;
                quayVideo.FlipHorizontal = !quayVideo.FlipHorizontal;

                quayVideo.Start();

            }
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
                txtMSSV.Text = dgvDSSV.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                txtHoten.Text = dgvDSSV.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                txtLop.Text = dgvDSSV.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
            }
            btnXoa.Enabled = true;

            txtHoten.Enabled = false;
            txtLop.Enabled = false;
            txtMSSV.Enabled = false;
            if (quayVideo != null)
            {
                btnCapNhat.Enabled = true;
            }
            else
            {
                btnCapNhat.Enabled = false;
            }

            //if (picBox.Image!=null)
            //{
            //    btnCapNhat.Enabled = true;
            //    btnThem.Enabled = false;
            //}
            //else
            //{
            //    btnCapNhat.Enabled = false;
            //}
        }



        private void btnStop_Click(object sender, EventArgs e)
        {
            if (quayVideo != null)
            {
                quayVideo.Stop();
            }
            btnThem.Enabled = false;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SinhVienDTO sv = new SinhVienDTO();
            sv.Ma_Lop = cboTim.Text.ToString();
            dgvDSSV.DataSource = SinhVienBUS.LayDSLop(sv.Ma_Lop);

        }



        private void btnTim_Click(object sender, EventArgs e)
        {
            SinhVienDTO sv = new SinhVienDTO();
            sv.Ma_SV = txtTim.Text.ToString();
            if (txtTim.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin cần tìm");
            }
            else
                dgvDSSV.DataSource = SinhVienBUS.TimKiemMaSV(sv.Ma_SV);
        }
        System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"[~`!@#$%^&*()+=|\\{}':;.,<>/?[\]""_-]");


        private void txtLop_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.KeyChar = char.Parse(e.KeyChar.ToString().ToUpper());


            if (e.Handled = (e.KeyChar == (char)Keys.Space))
            {

            }

            else
            {
                e.Handled = false;
            }

        }

        private void txtMSSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // ko cho phep nhap dau .
            else if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') == -1))
            {
                e.Handled = true;
            }
            else if (e.Handled = (e.KeyChar == (char)Keys.Space))
            {

            }

            else
            {
                e.Handled = false;
            }
        }

        private void txtTim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
      (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // ko cho phep nhap dau .
            else if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') == -1))
            {
                e.Handled = true;
            }
            else if (e.Handled = (e.KeyChar == (char)Keys.Space))
            {

            }

            else
            {
                e.Handled = false;
            }
        }

        private void cboTim_TextChanged(object sender, EventArgs e)
        {
            if (cboTim.SelectedIndex < 0)
            {
                cboTim.Text = "";
            }
            else
            {
                cboTim.Text = cboTim.SelectedText;
            }
        }



        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            addface = true;
            SinhVienDTO sv = new SinhVienDTO();
            sv.Ma_SV = txtMSSV.Text;

            if (dem == 1)
            {
                if (SinhVienBUS.CapNhatTrangThai(sv))
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
                    MessageBox.Show("Sinh viên đã có hình ảnh");
                }
            }
            else if (dem > 1 && dem <= 5)
            {
                addface = true;
                MessageBox.Show("Thêm Khuông Mặt Thứ: " + dem + " Thành Công");
                dem++;
                if (dem == 6)
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


            LoadDSSV();


        }

        private void DanhSachSV_Load_1(object sender, EventArgs e)
        {
            LoadDSSV();

            btnStop.Enabled = false;
            btnXoa.Enabled = false;
            btnCapNhat.Enabled = false;
            txtHoten.Enabled = false;
            txtMSSV.Enabled = false;
            txtLop.Enabled = false;
            btnThem.Enabled = false;
        }
        public static void ExportDataGridViewTo_Excel12(DataGridView myDataGridViewQuantity)
        {

            xls.Application oExcel_12 = null; //Excel_12 Application 

            xls.Workbook oBook = null; // Excel_12 Workbook 

            xls.Sheets oSheetsColl = null; // Excel_12 Worksheets collection 

            xls.Worksheet oSheet = null; // Excel_12 Worksheet 

            xls.Range oRange = null; // Cell or Range in worksheet 

            Object oMissing = System.Reflection.Missing.Value;


            // Create an instance of Excel_12. 

            oExcel_12 = new xls.Application();


            // Make Excel_12 visible to the user. 

            oExcel_12.Visible = true;


            // Set the UserControl property so Excel_12 won't shut down. 

            oExcel_12.UserControl = true;

            // System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US"); 

            //object file = File_Name;

            //object missing = System.Reflection.Missing.Value;



            // Add a workbook. 

            oBook = oExcel_12.Workbooks.Add(oMissing);

            // Get worksheets collection 

            oSheetsColl = oExcel_12.Worksheets;

            // Get Worksheet "Sheet1" 

            oSheet = (xls.Worksheet)oSheetsColl.get_Item("Sheet1");
            oSheet.Name = "DanhSach";





            // Export titles 

            for (int j = 0; j < myDataGridViewQuantity.Columns.Count - 1; j++)
            {

                oRange = (xls.Range)oSheet.Cells[1, j + 1];
                oRange.Value2 = myDataGridViewQuantity.Columns[j].HeaderText;
                oRange.Style.Font.Size = 14;
                oRange.EntireColumn.AutoFit();
                oRange.Style.Font.Name = "Times New Roman";

            }

            // Export data 

            for (int i = 0; i < myDataGridViewQuantity.Rows.Count; i++)
            {

                for (int j = 0; j < myDataGridViewQuantity.Columns.Count - 1; j++)
                {
                    oRange = (xls.Range)oSheet.Cells[i + 2, j + 1];
                    oRange.Style.Font.Size = 14;
                    oRange.Value2 = myDataGridViewQuantity[j, i].Value;
                    oRange.EntireColumn.AutoFit();
                    oRange.Style.Font.Name = "Times New Roman";

                }

            }
            oBook = null;
            oExcel_12.Quit();
            oExcel_12 = null;
            GC.Collect();
        }

        private void btnXuatEX_Click(object sender, EventArgs e)
        {
            try
            {
                ExportDataGridViewTo_Excel12(dgvDSSV);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }


        }



        public DataTable ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0)
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007  
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sheet1$]", con); //here we read data from sheet1  
                    oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }
            return dtexcel;

        }
        int click = 0;

        private void btnNhapEX_Click(object sender, EventArgs e)
        {
            DanhSachSV fm = new DanhSachSV();
            SinhVienDTO sv = new SinhVienDTO();
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            click++;
            if (click == 1)
                if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
                {
                    filePath = file.FileName; //get the path of the file  
                    fileExt = Path.GetExtension(filePath); //get the file extension  
                    if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                    {
                        try
                        {
                            DataTable dtExcel = new DataTable();
                            dtExcel = ReadExcel(filePath, fileExt);
                            dgvDSSV.Visible = true;
                            dgvDSSV.DataSource = dtExcel;
                            click++;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }

                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chỉ chọn file .xls hoặc .xlsx.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  

                    }
                    Debug.WriteLine(click);
                }
                else
                {
                    click = 0;
                }
            if (click == 2)
            {
                try
                {
                    if (dgvDSSV.Rows.Count < 1)
                    {
                        MessageBox.Show("Vui lòng chọn file excel để nhập !", "Thông Báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        DialogResult dr;
                        dr = MessageBox.Show(" Nhập danh sách này vào CSDL", "Thông Báo", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            for (int i = 0; i < dgvDSSV.Rows.Count - 1; i++)
                            {
                                sv.Ma_SV = Convert.ToString(dgvDSSV.Rows[i].Cells[0].Value);
                                sv.Ten_SV = Convert.ToString(dgvDSSV.Rows[i].Cells[1].Value);
                                sv.Ma_Lop = Convert.ToString(dgvDSSV.Rows[i].Cells[2].Value);
                                sv.SoNgayHoc = Convert.ToInt32(dgvDSSV.Rows[i].Cells[3].Value);
                                sv.SoNgayVang = Convert.ToInt32(dgvDSSV.Rows[i].Cells[4].Value);
                                sv.TrangThai = Convert.ToBoolean(null);

                                SinhVienBUS.ThemSVExcel(sv);

                            }
                            dgvDSSV.DataSource = SinhVienBUS.LayDSSV();
                            ChonLop();
                            dgvDSSV.Columns[0].Width = 150;
                            dgvDSSV.Columns[1].Width = 150;
                            dgvDSSV.Columns[2].Width = 150;
                            dgvDSSV.Columns[3].Width = 100;
                            dgvDSSV.Columns[4].Width = 100;
                            dgvDSSV.Columns[5].Width = 150;


                            MessageBox.Show("\tĐã nhập thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDSSV();


                        }
                        else if (dr == DialogResult.No)
                        {
                            click = 0;

                        }
                    }

                    click = 0;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            SinhVienDTO sv = new SinhVienDTO();
            sv.Ma_Lop = cboTim.Text.ToString();
            string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
            string[] files = Directory.GetFiles(path, "*.bmp", SearchOption.AllDirectories);

            Debug.WriteLine(cboTim.Text.ToString());

            if (cboTim.Text.ToString() != "")
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc là làm mới danh sách sinh viên lớp " + sv.Ma_Lop + " ?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SinhVienBUS.LamMoiDSSV(sv);
                    foreach (var file in files)
                    {
                        string name = file.Split('\\').Last().Split('_')[0];
                        string mssv = file.Split('\\').Last().Split('_')[1];
                        string lop = file.Split('\\').Last().Split('_')[2];
                        for(int i=1;i<=5;i++)
                        {
                            string[] fileLop = Directory.GetFiles(path, name + "_" + mssv + "_" + sv.Ma_Lop + "_" + i + "*.bmp", SearchOption.AllDirectories);
                            foreach (var filelop in fileLop)
                            {
                                if (sv.Ma_Lop == lop)
                                {
                                    File.Delete(filelop);
                                }
                            }
                        } 
                    }
                    LoadDSSV();
                    ChonLop();
                }
                if (dialogResult == DialogResult.No)
                { }
            }
            else
            {
                MessageBox.Show("Bạn Chưa Chọn Lớp !!", "Thông Báo");
            }

        }

   

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            if (quayVideo != null)
            {
                quayVideo.Stop();
            }
            this.Close();
        }
        //hello world
    }

}
