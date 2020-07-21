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
            this.STT_SV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_SV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_SV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSV)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDSSV
            // 
            this.dgvDSSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSSV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT_SV,
            this.Ma_SV,
            this.Ten_SV,
            this.MaLop});
            this.dgvDSSV.Location = new System.Drawing.Point(351, 11);
            this.dgvDSSV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDSSV.Name = "dgvDSSV";
            this.dgvDSSV.RowTemplate.Height = 24;
            this.dgvDSSV.Size = new System.Drawing.Size(238, 288);
            this.dgvDSSV.TabIndex = 0;
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
            // 
            // Ten_SV
            // 
            this.Ten_SV.DataPropertyName = "Ten_SV";
            this.Ten_SV.HeaderText = "Tên SV";
            this.Ten_SV.Name = "Ten_SV";
            // 
            // MaLop
            // 
            this.MaLop.DataPropertyName = "MaLop";
            this.MaLop.HeaderText = "Mã Lớp";
            this.MaLop.Name = "MaLop";
            // 
            // DanhSachSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 438);
            this.Controls.Add(this.dgvDSSV);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DanhSachSV";
            this.Text = "DanhSachSV";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT_SV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_SV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_SV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLop;
    }
}