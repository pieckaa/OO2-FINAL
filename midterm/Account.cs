using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace midterm
{
    public partial class Account : Form
    {
        private int userID;
        private Image defaultImage;
        private MainMenu mainMenu;
        public Account(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            LoadUsername();
            LoadPassword();
            LoadProfilePicture();
            defaultImage = def.Image;
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\Schooby\\Documents\\data.mdb");
        OleDbCommand cmd = new OleDbCommand();

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
                        user.Text = result.ToString(); 
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
        private void LoadPassword()
        {
            using (OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\Schooby\\Documents\\data.mdb"))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT password FROM users WHERE userID = @userID";
                cmd.Parameters.AddWithValue("@userID", userID);

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        password.Text = result.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Password not found for the current user.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading password: " + ex.Message);
                }
            }
        }
        private void LoadProfilePicture()
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
                            profile.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        profile.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error loading profile picture: " + ex.Message);
                }
            }
        }
        private void UpdatePassword(string newPassword)
        {
            using (OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\Schooby\\Documents\\data.mdb"))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE users SET [password] = ? WHERE userID = ?";
                cmd.Parameters.AddWithValue("@newPassword", newPassword);
                cmd.Parameters.AddWithValue("@userID", userID);

                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Password updated successfully
                    }
                    else
                    {
                        MessageBox.Show("Failed to update password.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating password: " + ex.Message);
                }
            }
        }
        private void uploadBtn_Click(object sender, EventArgs e)
        {
            if (profile.Image != null)
            {
                byte[] imageData = ConvertImageToByteArray(profile.Image);

                using (OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\Schooby\\Documents\\data.mdb"))
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE users SET [picture] = ? WHERE userID = ?";
                    cmd.Parameters.AddWithValue("@imageData", imageData);
                    cmd.Parameters.AddWithValue("@userID", userID);

                    try
                    {
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Profile picture updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update profile picture.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating profile picture: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a profile picture to upload.");
            }
        }
        private byte[] ConvertImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }


        private void profile_Click_1(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select Image";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; 
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                profile.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void roundCornerButton1_Click(object sender, EventArgs e)
        {
            string currentPassword = currentpass.Text;
            string newPassword = newpass.Text;
            string confirmPassword = compass.Text;

            if (currentPassword == password.Text)
            {
                if (newPassword == confirmPassword)
                {
                    UpdatePassword(newPassword);
                    MessageBox.Show("Password updated successfully!");
                }
                else
                {
                    MessageBox.Show("New password and confirm password do not match.");
                    currentpass.Clear();
                    newpass.Clear();
                    compass.Clear();
                    currentpass.Focus();
                }
            }
            else
            {
                MessageBox.Show("Current password is incorrect.");
                currentpass.Focus();
            }
        }

        private void currentpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Remove Profile Picture?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                profile.Image = defaultImage;

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}