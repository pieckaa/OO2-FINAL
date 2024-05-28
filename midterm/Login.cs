using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using OOP2;
using Microsoft.VisualBasic.ApplicationServices;


namespace midterm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\Schooby\\Documents\\data.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        public static int CurrentUserID;

        private void registerTxt_Click(object sender, EventArgs e)
        {
            con.Open();
            string login = "SELECT userID, username FROM users WHERE StrComp(username, @username, 0) = 0 AND StrComp(password, @password, 0) = 0";
            cmd = new OleDbCommand(login, con);
            cmd.Parameters.AddWithValue("@username", usernameTxt.Text);
            cmd.Parameters.AddWithValue("@password", passwordTxt.Text);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int userID = Convert.ToInt32(dr["userID"]);
                string username = dr["username"].ToString();

                if (userID == 1 && username.ToLower() == "admin")
                {
                    new adminForm(userID).Show();
                }
                else
                {
                    new MainMenu(userID).Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                usernameTxt.Text = "";
                passwordTxt.Text = "";
                usernameTxt.Focus();
            }
            con.Close();
        }


        private void clearBtn_Click(object sender, EventArgs e)
        {
            usernameTxt.Text = "";
            passwordTxt.Text = "";
            usernameTxt.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();

            register registerForm = new register();
            registerForm.FormClosed += (s, args) => this.Close();
            registerForm.Show();
        }

        private void showpassChkbx_CheckedChanged(object sender, EventArgs e)
        {
            if (showpassChkbx.Checked)
            {
                passwordTxt.PasswordChar = '\0';
            }
            else
            {
                passwordTxt.PasswordChar = '*';
            }
        }

        private void clearPicBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
