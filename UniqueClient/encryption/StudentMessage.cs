using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace encryption
{
    public partial class StudentMessage : Form
    {
        BaseConnection1 con = new BaseConnection1();
        public StudentMessage()
        {
            InitializeComponent();
        }

        private void StudentMessage_Load(object sender, EventArgs e)
        {
           // Program.username = "anu123";
            tname.Text = Program.username;
            textBox3.Text = DateTime.Now.ToShortDateString();
            messageid();
            fillgrid();
        }
        public void messageid()
        {
            try
            {
                string query = "select isnull(max(mid),800)+1 from message";
                SqlDataReader dr = con.ret_dr(query);
                if (dr.Read())
                {

                    textBox1.Text = dr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while generating user Id........");
            }
        }
        public void fillgrid()
        {
            try
            {


                //  string query1 = "select * from Student_details where department=(select department from Teacher_details where userid='"+Program.userid+"')";
                string query1 = "select mid,sender,subject,message,mdate from message where receiver='" + Program.username + "' and status=0";
                DataSet ds1 = con.ret_ds(query1);
                dataGridView1.DataSource = ds1.Tables[0].DefaultView;



            }
            catch (Exception ex)
            {
                MessageBox.Show("exception occured....");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string ss = "0";
            string query1 = "insert into message values(" + textBox1.Text + ",'" + tname.Text + "','" + textBox2.Text + "','" + mob.Text + "','" + mail.Text + "','" + textBox3.Text + "','" + ss + "','" + ss + "',0)";
            if (con.exec1(query1) > 0)
            {
                MessageBox.Show("Message Send  Successfully...");
                this.Close();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
