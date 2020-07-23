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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.STT_SV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_SV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_SV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNgayHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNgayVang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSV)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDSSV
            // 
            this.dgvDSSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSSV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT_SV,
            this.Ma_SV,
            this.Ten_SV,
            this.MaLop,
            this.SoNgayHoc,
            this.SoNgayVang});
            this.dgvDSSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDSSV.Location = new System.Drawing.Point(3, 18);
            this.dgvDSSV.Name = "dgvDSSV";
            this.dgvDSSV.RowTemplate.Height = 24;
            this.dgvDSSV.Size = new System.Drawing.Size(770, 242);
            this.dgvDSSV.TabIndex = 0;
            this.dgvDSSV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSSV_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 272);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDSSV);
            this.groupBox2.Location = new System.Drawing.Point(12, 290);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 263);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // STT_SV
            // 
            this.STT_SV.DataPropertyName = "STT_SV";
            this.STT_SV.HeaderText = "STT";
            this.STT_SV.Name = "STT_SV";
            // 
            // Ma_SV
            // 
            this.Ma_SV.DataPropertyName = "Ma_SV";
            this.Ma_SV.HeaderText = "Mã SV";
            this.Ma_SV.Name = "Ma_SV";
            this.Ma_SV.Width = 150;
            // 
            // Ten_SV
            // 
            this.Ten_SV.DataPropertyName = "Ten_SV";
            this.Ten_SV.HeaderText = "Tên SV";
            this.Ten_SV.Name = "Ten_SV";
            this.Ten_SV.Width = 150;
            // 
            // MaLop
            // 
            this.MaLop.DataPropertyName = "MaLop";
            this.MaLop.HeaderText = "Mã Lớp";
            this.MaLop.Name = "MaLop";
            this.MaLop.Width = 150;
            // 
            // SoNgayHoc
            // 
            this.SoNgayHoc.DataPropertyName = "SoNgayHoc";
            this.SoNgayHoc.HeaderText = "Số Ngày Học";
            this.SoNgayHoc.Name = "SoNgayHoc";
            // 
            // SoNgayVang
            // 
            this.SoNgayVang.DataPropertyName = "SoNgayVang";
            this.SoNgayVang.HeaderText = "Số Ngày Vắng";
            this.SoNgayVang.Name = "SoNgayVang";
            // 
            // DanhSachSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 565);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DanhSachSV";
            this.Text = "DanhSachSV";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT_SV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_SV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_SV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNgayHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNgayVang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}