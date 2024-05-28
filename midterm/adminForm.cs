using Microsoft.VisualBasic.ApplicationServices;
using midterm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP2
{
    public partial class adminForm : Form
    {
        private int userID;
        Browse browse;
        moderateComments moderate;
        checkFeedbacks check;
        Account account;

        private Timer expandTimer;
        public adminForm(int userID)
        {
            InitializeComponent(); 
            this.userID = userID;
            LoadProfilePictureMenu();
            LoadUsername();

            expandTimer = new Timer();
            expandTimer.Interval = 10;

            expandTimer.Tick += ExpandTimer_Tick;
            sidebar.MouseEnter += Sidebar_MouseEnter;
            ///=pnl1.MouseEnter += Sidebar_MouseEnter;
            //pnl2.MouseEnter += Sidebar_MouseEnter;
            pnlAccount.MouseEnter += Sidebar_MouseEnter;
            pnl3.MouseEnter += Sidebar_MouseEnter;
            bigPanel.MouseEnter += Sidebar_MouseEnter;
        }
        private void Sidebar_MouseEnter(object sender, EventArgs e)
        {
            if (!sidebarExpand)
            {
                expandTimer.Start();
            }
        }

        private void ExpandTimer_Tick(object sender, EventArgs e)
        {
            const int step = 5; 

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
            pnl1.Width = sidebar.Width;
            //pnl2.Width = sidebar.Width;
            pnl3.Width = sidebar.Width;
            pnl4.Width = sidebar.Width;
            pnlAccount.Width = sidebar.Width;
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

        bool sidebarExpand = true;
        private void x_Click(object sender, EventArgs e)
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
    
        private void button1_Click(object sender, EventArgs e)
        {
            sidebarTransistion.Start();

            if (moderate == null)
            {
                moderate = new moderateComments();
                moderate.FormClosed += moderateComments_FormClosed;
                moderate.MdiParent = this;
                moderate.Dock = DockStyle.Fill;
                moderate.Show();
            }
            else
            {
                moderate.Activate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sidebarTransistion.Start();

            if (check == null)
            {
                check = new checkFeedbacks();
                check.FormClosed += checkFeedbacks_FormClosed;
                check.MdiParent = this;
                check.Dock = DockStyle.Fill;
                check.Show();
            }
            else
            {
                check.Activate();
            }
        }
        private void moderateComments_FormClosed(object sender, FormClosedEventArgs e)
        {
            moderate = null;
        }

        private void checkFeedbacks_FormClosed(object sender, FormClosedEventArgs e)
        {
            moderate = null;
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void sidebarTransistion_Tick_1(object sender, EventArgs e)
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
                //pnl2.Width = sidebar.Width;
                //pnl3.Width = sidebar.Width;
                pnlAccount.Width = sidebar.Width;
                pnl4.Width = sidebar.Width;
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
                //pnl2.Width = sidebar.Width;
               // pnl3.Width = sidebar.Width;
                pnlAccount.Width = sidebar.Width;
                pnl4.Width = sidebar.Width;
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
        private void Account_FormClosed(object sender, FormClosedEventArgs e)
        {
            moderate = null;
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

        private void pnl2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
