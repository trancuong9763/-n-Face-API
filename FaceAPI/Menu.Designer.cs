namespace FaceAPI
{
    partial class Menu
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
            this.btnDiemDanh = new System.Windows.Forms.Button();
            this.btnDSSV = new System.Windows.Forms.Button();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.lblTenTK = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDiemDanh
            // 
            this.btnDiemDanh.Location = new System.Drawing.Point(12, 76);
            this.btnDiemDanh.Name = "btnDiemDanh";
            this.btnDiemDanh.Size = new System.Drawing.Size(366, 53);
            this.btnDiemDanh.TabIndex = 1;
            this.btnDiemDanh.Text = "ĐIỂM DANH";
            this.btnDiemDanh.UseVisualStyleBackColor = true;
            this.btnDiemDanh.Click += new System.EventHandler(this.btnDiemDanh_Click);
            // 
            // btnDSSV
            // 
            this.btnDSSV.Location = new System.Drawing.Point(12, 148);
            this.btnDSSV.Name = "btnDSSV";
            this.btnDSSV.Size = new System.Drawing.Size(366, 53);
            this.btnDSSV.TabIndex = 2;
            this.btnDSSV.Text = "DANH SÁCH SINH VIÊN";
            this.btnDSSV.UseVisualStyleBackColor = true;
            this.btnDSSV.Click += new System.EventHandler(this.btnDSSV_Click);
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Location = new System.Drawing.Point(14, 219);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(366, 53);
            this.btnTaiKhoan.TabIndex = 3;
            this.btnTaiKhoan.Text = "TÀI KHOẢN";
            this.btnTaiKhoan.UseVisualStyleBackColor = true;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // lblTenTK
            // 
            this.lblTenTK.Location = new System.Drawing.Point(163, 14);
            this.lblTenTK.Name = "lblTenTK";
            this.lblTenTK.Size = new System.Drawing.Size(134, 22);
            this.lblTenTK.TabIndex = 4;
            this.lblTenTK.Text = "ten";
            this.lblTenTK.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(303, 8);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 34);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(392, 302);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lblTenTK);
            this.Controls.Add(this.btnTaiKhoan);
            this.Controls.Add(this.btnDSSV);
            this.Controls.Add(this.btnDiemDanh);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDiemDanh;
        private System.Windows.Forms.Button btnDSSV;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Label lblTenTK;
        private System.Windows.Forms.Button btnThoat;
    }
}