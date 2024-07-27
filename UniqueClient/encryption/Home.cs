using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace encryption
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            uploadImage obj = new uploadImage();
            obj.Show();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
           

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            uploadImage obj = new uploadImage();
            obj.Show();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            FileDownload1 obj = new FileDownload1();
            obj.Show();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            FileDirectoryView obj = new FileDirectoryView();
            obj.Show();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            FileSharePermission obj = new FileSharePermission();
            obj.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            DeleteFile obj = new DeleteFile();
            obj.Show();
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            FileBlockPermission obj = new FileBlockPermission();
            obj.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            LOGIN obj = new LOGIN();
            obj.Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            StudentMessage obj = new StudentMessage();
            obj.Show();
        }
    }
}
