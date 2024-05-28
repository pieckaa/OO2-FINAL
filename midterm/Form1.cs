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

namespace midterm
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\Schooby\\Documents\\data.mdb");

        private void registerTxt_Click(object sender, EventArgs e)
        {
            if (usernameTxt.Text == "" || passwordTxt.Text == "" || compasswordTxt.Text == "")
            {
                MessageBox.Show("Username or password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (passwordTxt.Text == compasswordTxt.Text)
            {
                try
                {
                    using (OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\Schooby\\Documents\\data.mdb"))
                    {
                        con.Open();
                        string register = "INSERT INTO users (username, [password]) VALUES (@username, @password)";
                        using (OleDbCommand cmd = new OleDbCommand(register, con))
                        {
                            cmd.Parameters.AddWithValue("@username", usernameTxt.Text);
                            cmd.Parameters.AddWithValue("@password", passwordTxt.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    usernameTxt.Text = "";
                    passwordTxt.Text = "";
                    compasswordTxt.Text = "";
                    MessageBox.Show("You have been registered", "Registration complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (OleDbException ex)
                {
                    if (ex.ErrorCode == -2147467259) // Error code for duplicate index
                    {
                        MessageBox.Show("Username already exists", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTxt.Text = "";
                compasswordTxt.Text = "";
                passwordTxt.Focus();
            }
        }

        private void showpassChkbx_CheckedChanged(object sender, EventArgs e)
        {
            if (showpassChkbx.Checked)
            {
                passwordTxt.PasswordChar = '\0';
                compasswordTxt.PasswordChar = '\0';
            }
            else
            {
                passwordTxt.PasswordChar = '*';
                compasswordTxt.PasswordChar = '*';
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login loginForm = new Login();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            usernameTxt.Text = "";
            passwordTxt.Text = "";
            compasswordTxt.Text = "";
            usernameTxt.Focus();
        }

        private void clearPicBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
