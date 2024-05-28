using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace midterm
{
    public partial class MainMenu : Form
    {
        formBucketlist bucketlist;
        Browse browse;
        Account account;
        Menu menu;
        private Timer expandTimer;

        private int userID;

        public MainMenu(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            LoadProfilePictureMenu();
            LoadUsername();

            expandTimer = new Timer();
            expandTimer.Interval = 10;
            browse = new Browse(userID);

            browse.FormClosed += Browse_FormClosed;
            browse.MdiParent = this;
            browse.Dock = DockStyle.Fill;
            browse.Show();

            expandTimer.Tick += ExpandTimer_Tick;
            sidebar.MouseEnter += Sidebar_MouseEnter;
            pnlBrowse.MouseEnter += Sidebar_MouseEnter;
            pnlList.MouseEnter += Sidebar_MouseEnter;
            pnlAccount.MouseEnter += Sidebar_MouseEnter;
            pnlLogout.MouseEnter += Sidebar_MouseEnter;
            bigPanel.MouseEnter += Sidebar_MouseEnter;
            this.Click += MainMenu_Click;
        }
        private void MainMenu_Click(object sender, EventArgs e)
        {
            Point mousePos = this.PointToClient(MousePosition);

            if (!sidebar.Bounds.Contains(mousePos) && !bigPanel.Bounds.Contains(mousePos))
            {
                if (sidebarExpand)
                {
                    expandTimer.Start();
                }
            }
        }

        private void ExpandTimer_Tick(object sender, EventArgs e)
        {
            const int step = 5; // Set your desired step size for the animation

            if (sidebarExpand)
            {
                sidebar.Width -= step;
                if (sidebar.Width <= 70)
                {
                    sidebar.Width = 70;
                    expandTimer.Stop();
                    sidebarExpand = false;
                }
            }
            else
            {
                sidebar.Width += step;
                if (sidebar.Width >= 200)
                {
                    sidebar.Width = 200;
                    expandTimer.Stop();
                    sidebarExpand = true;
                }
            }

            bigPanel.Width = sidebar.Width;
            pnlBrowse.Width = sidebar.Width;
            pnlList.Width = sidebar.Width;
            pnlAccount.Width = sidebar.Width;
            pnlLogout.Width = sidebar.Width;
        }
        private void Sidebar_MouseEnter(object sender, EventArgs e)
        {
            if (!sidebarExpand)
            {
                expandTimer.Start();
            }
        }
        private void LoadUsername()
        {
            using (OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\Schooby\\Documents\\data.mdb"))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT username FROM users WHERE userID = @userID";
                cmd.Parameters.AddWithValue("@userID", userID);

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        label1.Text = result.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Username not found for the current user.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading username: " + ex.Message);
                }
            }
        }

        public void LoadProfilePictureMenu()
        {
            using (OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\Schooby\\Documents\\data.mdb"))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT picture FROM users WHERE userID = @userID";
                cmd.Parameters.AddWithValue("@userID", userID);

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        byte[] imageData = (byte[])result;
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pfpBox.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pfpBox.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error loading profile picture: " + ex.Message);
                }
            }
        }


        bool sidebarExpand = true;
        private void sidebarTransistion_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 5;
                if (sidebar.Width <= 70)
                {
                    sidebarExpand = false;
                    sidebarTransistion.Stop();
                }

                bigPanel.Width = sidebar.Width;
                pnlBrowse.Width = sidebar.Width;
                pnlList.Width = sidebar.Width;
                pnlAccount.Width = sidebar.Width;
                pnlLogout.Width = sidebar.Width;
            }
            else
            {
                sidebar.Width += 5;
                if (sidebar.Width >= 200)
                {
                    sidebarExpand = true;
                    sidebarTransistion.Stop();
                }

                bigPanel.Width = sidebar.Width;
                pnlBrowse.Width = sidebar.Width;
                pnlList.Width = sidebar.Width;
                pnlAccount.Width = sidebar.Width;
                pnlLogout.Width = sidebar.Width;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadProfilePictureMenu();
            sidebarTransistion.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            sidebarTransistion.Start();
            if (bucketlist == null)
            {
                bucketlist = new formBucketlist(userID);
                bucketlist.FormClosed += Bucketlist_FormClosed;
                bucketlist.MdiParent = this;
                bucketlist.Dock = DockStyle.Fill;
                bucketlist.Show();
            }
            else
            {
                bucketlist.Activate();
            }
        }
        private void Bucketlist_FormClosed(object sender, FormClosedEventArgs e)
        {
            bucketlist = null;
        }

        private void MENU_Click(object sender, EventArgs e)
        {
            sidebarTransistion.Start();

            if (menu == null)
            {
                menu = new Menu(userID);
                menu.FormClosed += Menu_FormClosed;
                menu.MdiParent = this;
                menu.Dock = DockStyle.Fill;
                menu.Show();
            }
            else
            {
                menu.Activate();
            }
        }
        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            bucketlist = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sidebarTransistion.Start();
            if (browse == null)
            {
                browse = new Browse(userID);
                browse.FormClosed += Browse_FormClosed;
                browse.MdiParent = this;
                browse.Dock = DockStyle.Fill;
                browse.Show();
            }
            else
            {
                browse.Activate();
            }
        }
        private void Browse_FormClosed(object sender, FormClosedEventArgs e)
        {
            browse = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sidebarTransistion.Start();
            account?.Dispose();
            account = new Account(userID);
            account.FormClosed += Account_FormClosed;
            account.MdiParent = this;
            account.Dock = DockStyle.Fill;
            account.Show();
        }

        private void Account_FormClosed(object sender, FormClosedEventArgs e)
        {
            account = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();

                Login loginForm = new Login();
                loginForm.FormClosed += (s, args) => this.Close();
                loginForm.Show();
            }
        }

        private void pfpBox_Click(object sender, EventArgs e)
        {
            sidebarTransistion.Start();
            account?.Dispose();
            account = new Account(userID);
            account.FormClosed += Account_FormClosed;
            account.MdiParent = this;
            account.Dock = DockStyle.Fill;
            account.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            sidebarTransistion.Start();
            account?.Dispose();
            account = new Account(userID);
            account.FormClosed += Account_FormClosed;
            account.MdiParent = this;
            account.Dock = DockStyle.Fill;
            account.Show();
        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
