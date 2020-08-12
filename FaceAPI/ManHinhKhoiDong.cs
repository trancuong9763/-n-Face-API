using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceAPI
{
    public partial class ManHinhKhoiDong : Form
    {
        public ManHinhKhoiDong()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {

            this.progressBar1.Increment(1);



        }

        private void ManHinhKhoiDong_Load(object sender, EventArgs e)
        {

            
            this.timer1.Start();
           
        }
    }
}
