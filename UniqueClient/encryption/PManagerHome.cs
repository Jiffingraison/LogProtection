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
    public partial class PManagerHome : Form
    {
        public PManagerHome()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            DeleteEmployee obj = new DeleteEmployee();
            obj.Show();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FileDirectoryView obj = new FileDirectoryView();
            obj.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            AddEmpDetails obj = new AddEmpDetails();
            obj.Show();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            DeleteEmployee obj = new DeleteEmployee();
            obj.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            FileDirectoryView obj = new FileDirectoryView();
            obj.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            LOGIN obj = new LOGIN();
            obj.Show();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            StudentMessage obj = new StudentMessage();
            obj.Show();
        }
    }
}
