namespace FaceAPI
{
    partial class DanhSachSV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDSSV = new System.Windows.Forms.DataGridView();
            this.Ma_SV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_SV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNgayHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNgayVang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtLop = new System.Windows.Forms.TextBox();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picBox2 = new System.Windows.Forms.PictureBox();
            this.btnXuat = new System.Windows.Forms.Button();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.cboTim = new System.Windows.Forms.ComboBox();
            this.lblNhapMSSV = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSV)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDSSV
            // 
            this.dgvDSSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSSV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ma_SV,
            this.Ten_SV,
            this.MaLop,
            this.SoNgayHoc,
            this.SoNgayVang});
            this.dgvDSSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDSSV.Location = new System.Drawing.Point(4, 23);
            this.dgvDSSV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvDSSV.Name = "dgvDSSV";
            this.dgvDSSV.RowTemplate.Height = 24;
            this.dgvDSSV.Size = new System.Drawing.Size(865, 218);
            this.dgvDSSV.TabIndex = 0;
            this.dgvDSSV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSSV_CellClick);
            // 
            // Ma_SV
            // 
            this.Ma_SV.DataPropertyName = "Ma_SV";
            this.Ma_SV.HeaderText = "Mã SV";
            this.Ma_SV.Name = "Ma_SV";
            this.Ma_SV.Width = 200;
            // 
            // Ten_SV
            // 
            this.Ten_SV.DataPropertyName = "Ten_SV";
            this.Ten_SV.HeaderText = "Tên SV";
            this.Ten_SV.Name = "Ten_SV";
            this.Ten_SV.Width = 200;
            // 
            // MaLop
            // 
            this.MaLop.DataPropertyName = "Ma_Lop";
            this.MaLop.HeaderText = "Mã Lớp";
            this.MaLop.Name = "MaLop";
            this.MaLop.Width = 200;
            // 
            // SoNgayHoc
            // 
            this.SoNgayHoc.DataPropertyName = "SoNgayHoc";
            this.SoNgayHoc.HeaderText = "Số Ngày Học";
            this.SoNgayHoc.Name = "SoNgayHoc";
            this.SoNgayHoc.Width = 120;
            // 
            // SoNgayVang
            // 
            this.SoNgayVang.DataPropertyName = "SoNgayVang";
            this.SoNgayVang.HeaderText = "Số Ngày Vắng";
            this.SoNgayVang.Name = "SoNgayVang";
            this.SoNgayVang.Width = 120;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDSSV);
            this.groupBox2.Location = new System.Drawing.Point(13, 412);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(873, 244);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Sinh Viên";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.txtLop);
            this.groupBox1.Controls.Add(this.txtMSSV);
            this.groupBox1.Controls.Add(this.txtHoten);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.picBox2);
            this.groupBox1.Location = new System.Drawing.Point(495, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(391, 329);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm Sinh Viên";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(173, 98);
            this.btnStop.Margin = new System.Windows.Forms.Padding(5);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(211, 54);
            this.btnStop.TabIndex = 13;
            this.btnStop.Text = "Dừng";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(173, 28);
            this.btnStart.Margin = new System.Windows.Forms.Padding(5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(211, 54);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "Bật Camera";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(208, 276);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(5);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(176, 43);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(9, 276);
            this.btnThem.Margin = new System.Windows.Forms.Padding(5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(176, 43);
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtLop
            // 
            this.txtLop.Location = new System.Drawing.Point(86, 239);
            this.txtLop.Margin = new System.Windows.Forms.Padding(5);
            this.txtLop.MaxLength = 10;
            this.txtLop.Name = "txtLop";
            this.txtLop.Size = new System.Drawing.Size(294, 27);
            this.txtLop.TabIndex = 8;
            this.txtLop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLop_KeyPress);
            // 
            // txtMSSV
            // 
            this.txtMSSV.Location = new System.Drawing.Point(86, 201);
            this.txtMSSV.Margin = new System.Windows.Forms.Padding(5);
            this.txtMSSV.MaxLength = 10;
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(294, 27);
            this.txtMSSV.TabIndex = 7;
            this.txtMSSV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMSSV_KeyPress);
            // 
            // txtHoten
            // 
            this.txtHoten.Location = new System.Drawing.Point(86, 163);
            this.txtHoten.Margin = new System.Windows.Forms.Padding(5);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(294, 27);
            this.txtHoten.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 250);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Lớp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 212);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "MSSV:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 168);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Họ Tên:";
            // 
            // picBox2
            // 
            this.picBox2.Location = new System.Drawing.Point(9, 28);
            this.picBox2.Margin = new System.Windows.Forms.Padding(5);
            this.picBox2.Name = "picBox2";
            this.picBox2.Size = new System.Drawing.Size(155, 124);
            this.picBox2.TabIndex = 0;
            this.picBox2.TabStop = false;
            // 
            // btnXuat
            // 
            this.btnXuat.Location = new System.Drawing.Point(740, 355);
            this.btnXuat.Margin = new System.Windows.Forms.Padding(5);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(135, 46);
            this.btnXuat.TabIndex = 11;
            this.btnXuat.Text = "Xuất Excel";
            this.btnXuat.UseVisualStyleBackColor = true;
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(13, 18);
            this.picBox.Margin = new System.Windows.Forms.Padding(5);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(473, 320);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 4;
            this.picBox.TabStop = false;
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(139, 364);
            this.txtTim.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTim.MaxLength = 10;
            this.txtTim.Multiline = true;
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(198, 27);
            this.txtTim.TabIndex = 5;
            this.txtTim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTim_KeyPress);
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(345, 361);
            this.btnTim.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(111, 33);
            this.btnTim.TabIndex = 6;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // cboTim
            // 
            this.cboTim.FormattingEnabled = true;
            this.cboTim.Location = new System.Drawing.Point(577, 364);
            this.cboTim.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboTim.Name = "cboTim";
            this.cboTim.Size = new System.Drawing.Size(151, 27);
            this.cboTim.TabIndex = 7;
            this.cboTim.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.cboTim.TextChanged += new System.EventHandler(this.cboTim_TextChanged);
            // 
            // lblNhapMSSV
            // 
            this.lblNhapMSSV.AutoSize = true;
            this.lblNhapMSSV.Location = new System.Drawing.Point(35, 367);
            this.lblNhapMSSV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNhapMSSV.Name = "lblNhapMSSV";
            this.lblNhapMSSV.Size = new System.Drawing.Size(96, 19);
            this.lblNhapMSSV.TabIndex = 8;
            this.lblNhapMSSV.Text = "Nhập MSSV:";
            this.lblNhapMSSV.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(493, 368);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Chọn lớp:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DanhSachSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 671);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.lblNhapMSSV);
            this.Controls.Add(this.cboTim);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DanhSachSV";
            this.Text = "DanhSachSV";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSSV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtLop;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.TextBox txtHoten;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picBox2;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.ComboBox cboTim;
        private System.Windows.Forms.Label lblNhapMSSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_SV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_SV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNgayHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNgayVang;
    }
}