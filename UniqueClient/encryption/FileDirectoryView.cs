using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Collections;
namespace encryption
{
    public partial class FileDirectoryView : Form
    {
        public FileDirectoryView()
        {
            InitializeComponent();
        }
        BaseConnection1 con=new BaseConnection1();
        ArrayList filedetails = new ArrayList();
        public static string fpass = "";
        public static string fileid = "";
        protected void InitListView()
        {
            //init ListView control
            lvFiles.Clear();		//clear control
            //create column header for ListView
            lvFiles.Columns.Add("Name", 150, System.Windows.Forms.HorizontalAlignment.Left);
            lvFiles.Columns.Add("Size", 140, System.Windows.Forms.HorizontalAlignment.Left);
            lvFiles.Columns.Add("Created", 140, System.Windows.Forms.HorizontalAlignment.Left);
           

        }
        protected void InitListView1()
        {
            //init ListView control
            listView1.Clear();		//clear control
            //create column header for ListView
            listView1.Columns.Add("Name", 150, System.Windows.Forms.HorizontalAlignment.Left);
            listView1.Columns.Add("Size", 140, System.Windows.Forms.HorizontalAlignment.Left);
            listView1.Columns.Add("Created", 140, System.Windows.Forms.HorizontalAlignment.Left);


        }
        private void PaintListView(string root)
        {
            try
            {
                ListViewItem lvi;
                ListViewItem.ListViewSubItem lvsi;

                if (root.CompareTo("") == 0)
                    return;
                DirectoryInfo dir = new DirectoryInfo(root);
                DirectoryInfo[] dirs = dir.GetDirectories();
                FileInfo[] files = dir.GetFiles();

               // this.listViewFilesAndFolders.Items.Clear();
              //  this.labelCurrentPath.Text = root;
                this.lvFiles.BeginUpdate();
                foreach (DirectoryInfo di in dirs)
                {
                    lvi = new ListViewItem();
                    lvi.Text = di.Name;
                    lvi.Tag = di.FullName;

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = "";

                    lvi.SubItems.Add(lvsi);

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = di.LastAccessTime.ToString();
                    lvi.SubItems.Add(lvsi);

                    this.lvFiles.Items.Add(lvi);
                }

                foreach (FileInfo fi in files)
                {
                    lvi = new ListViewItem();
                    lvi.Text = fi.Name;
                    lvi.Tag = fi.FullName;

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = fi.Length.ToString();
                    lvi.SubItems.Add(lvsi);

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = fi.LastAccessTime.ToString();
                    lvi.SubItems.Add(lvsi);
                    this.lvFiles.Items.Add(lvi);
                }
                this.lvFiles.EndUpdate();
            }
            catch (System.Exception err)
            {
                MessageBox.Show("Error: " + err.Message);
            }
        }

        private void FileDirectoryView_Load(object sender, EventArgs e)
        {
            InitListView();
            InitListView1();
          //  Program.username = "anu123";
            string ppath = Application.StartupPath + "\\" + Program.username;
            PaintListView(ppath);

            string query = "select fileid,filepassword from datadb where status=2";
            SqlDataReader sd = con.ret_dr(query);
            while(sd.Read())
            {
                listBox2.Items.Add(sd[0].ToString());
                fpass = sd[1].ToString();
            }
            string query1 = "select username from sharedb where shareduser='" + Program.username + "'";
            SqlDataReader sd1 = con.ret_dr(query1);
            while (sd1.Read())
            {
                listBox1.Items.Add(sd1[0].ToString());
                
            }
        }

        private void lvFiles_MouseClick(object sender, MouseEventArgs e)
        {
          //  Program.username = "anu123";
           string fileid=lvFiles.SelectedItems[0].Text.ToString();
           string query = "select fileid,username,status,filepassword from datadb where filename='" + fileid + "'";
            SqlDataReader sd = con.ret_dr(query);
            if (sd.Read())
            {
                if (sd[2].ToString() == "2".ToString())
                {
                    FileDownload obj = new FileDownload(sd[0].ToString(), sd[3].ToString());
                    obj.Show();
                }
                else if (sd[2].ToString() == "1".ToString())
                {
                    if (sd[1].ToString() == Program.username)
                    {
                        FileDownload obj = new FileDownload(sd[0].ToString(), sd[3].ToString());
                        obj.Show();
                    }
                    else
                    {
                        MessageBox.Show("Permission Denied to access this file");
                    }

                }
                else
                {
                    MessageBox.Show("Permission Denied to access this file");
                }
            }
            else
            {
                MessageBox.Show("fileid not correct");
            } 


        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            FileDownload obj = new FileDownload(listBox2.SelectedItem.ToString(), fpass);
            obj.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query1 = "select fileid from sharedb where username='" + listBox1.SelectedItem.ToString() + "' and shareduser='" + Program.username + "'";
            SqlDataReader sd1 = con.ret_dr(query1);
            while (sd1.Read())
            {
                fileid = sd1[0].ToString()+".txt";
                filedetails.Add(fileid);
            }
            string ppath1 = Application.StartupPath + "\\" + listBox1.SelectedItem.ToString();
            PaintListView1(ppath1, filedetails);

        }
        private void PaintListView1(string root, ArrayList filedetails)
        {
            try
            {
                ListViewItem lvi;
                ListViewItem.ListViewSubItem lvsi;

                if (root.CompareTo("") == 0)
                    return;
                DirectoryInfo dir = new DirectoryInfo(root);
                DirectoryInfo[] dirs = dir.GetDirectories();
                FileInfo[] files = dir.GetFiles();

                // this.listViewFilesAndFolders.Items.Clear();
                //  this.labelCurrentPath.Text = root;
                this.listView1.BeginUpdate();
                foreach (DirectoryInfo di in dirs)
                {
                    lvi = new ListViewItem();
                    lvi.Text = di.Name;
                    lvi.Tag = di.FullName;

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = "";

                    lvi.SubItems.Add(lvsi);

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = di.LastAccessTime.ToString();
                    lvi.SubItems.Add(lvsi);

                    this.listView1.Items.Add(lvi);
                }

                foreach (FileInfo fi in files)
                {
                    if (filedetails.Contains(fi.ToString()))
                    {

                        lvi = new ListViewItem();
                        lvi.Text = fi.Name;
                        lvi.Tag = fi.FullName;

                        lvsi = new ListViewItem.ListViewSubItem();
                        lvsi.Text = fi.Length.ToString();
                        lvi.SubItems.Add(lvsi);

                        lvsi = new ListViewItem.ListViewSubItem();
                        lvsi.Text = fi.LastAccessTime.ToString();
                        lvi.SubItems.Add(lvsi);
                        this.listView1.Items.Add(lvi);
                    }
                }
                this.listView1.EndUpdate();
            }
            catch (System.Exception err)
            {
                MessageBox.Show("Error: " + err.Message);
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            string fileid1 = listView1.SelectedItems[0].Text.ToString();
            string query = "select fileid,username,status,filepassword from datadb where filename='" + fileid1 + "'";
            SqlDataReader sd = con.ret_dr(query);
            if (sd.Read())
            {
                if (sd[2].ToString() == "3".ToString())
                {
                    FileDownload obj = new FileDownload(sd[0].ToString(), sd[3].ToString());
                    obj.Show();
                }
               
                else
                {
                    MessageBox.Show("Permission Denied to access this file");
                }
            }
            else
            {
                MessageBox.Show("fileid not correct");
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
