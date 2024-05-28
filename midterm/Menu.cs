using System.IO;
using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace midterm
{
    public partial class Menu : Form
    {
        private int userID;
        private OleDbConnection connection;
        private const string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Schooby\Documents\data.mdb";

        public Menu(int userID)
        {
            InitializeComponent(); 
            this.userID = userID;
        }

        private void MenuLoad(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private bool IsReportAlreadySubmittedToday(int userID)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT MAX(reportDate) FROM report WHERE userID = ?";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("userID", OleDbType.Integer).Value = userID;

                        object result = command.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            DateTime lastReportDate = Convert.ToDateTime(result);
                            DateTime today = DateTime.Today;

                            return lastReportDate.Date == today;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while checking report submission: " + ex.Message);
                    return true;
                }
            }
        }

        private string attachedFilePath = ""; 

        private void attachSS_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*";
            openFileDialog.Title = "Select an Image";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                attachedFilePath = openFileDialog.FileName;
                label2.Text = System.IO.Path.GetFileName(attachedFilePath);
            }
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string[] options = { "Suggestion", "Bug" };

            string selectedOption = ShowCustomMessageBox("Submit as?", "Confirmation", options);

            if (selectedOption == null)
            {
                // User closed the form without selecting an option
                return;
            }

            string status = selectedOption;

            /*if (IsReportAlreadySubmittedToday(userID))
            {
                MessageBox.Show("You have already submitted a report today. Please try again tomorrow.");
                return;
            }*/

            string title = titleTxt.Text;
            string description = descriptiontxt.Text;
            DateTime reportDate = DateTime.Now;

            byte[] pictureData;

            if (string.IsNullOrEmpty(attachedFilePath))
            {
                string defaultImagePath = @"C:\Users\Schooby\Downloads\icons\Icons8-Windows-8-Travel-Beach.32.png";
                pictureData = File.ReadAllBytes(defaultImagePath);
            }
            else
            {
                pictureData = File.ReadAllBytes(attachedFilePath);
            }

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO report (userID, title, description, picture, reportDate, status) VALUES (?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("userID", OleDbType.Integer).Value = userID;
                        command.Parameters.Add("title", OleDbType.VarChar).Value = title;
                        command.Parameters.Add("description", OleDbType.VarChar).Value = description;
                        command.Parameters.Add("picture", OleDbType.LongVarBinary).Value = pictureData;
                        command.Parameters.Add("reportDate", OleDbType.Date).Value = reportDate;
                        command.Parameters.Add("status", OleDbType.VarChar).Value = status;

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Report saved successfully as " + status + ".");
                            titleTxt.Text = "Enter Text.";
                            descriptiontxt.Text = "Describe in detail, include screenshots if possible.";
                            attachedFilePath = "";
                            label2.Text = "Nothing attached.";
                        }
                        else
                        {
                            MessageBox.Show("Failed to save report.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private string ShowCustomMessageBox(string message, string title, string[] options)
        {
            Form prompt = new Form();
            prompt.StartPosition = FormStartPosition.CenterScreen;
            prompt.Width = 300;
            prompt.Height = 150;
            prompt.Text = title;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = message };
            ComboBox comboBox = new ComboBox() { Left = 50, Top = 50, Width = 200 };
            comboBox.Items.AddRange(options);
            comboBox.SelectedIndex = 0;
            Button confirmation = new Button() { Text = "OK", Left = 100, Width = 100, Top = 80 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.FormClosing += (sender, e) => { if (comboBox.SelectedItem == null) prompt.DialogResult = DialogResult.Cancel; };
            prompt.Controls.Add(comboBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.ShowDialog();
            return comboBox.SelectedItem?.ToString();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string title = titleTxt.Text;
            string description = 

            titleTxt.Text = "Enter Text.";
            descriptiontxt.Text = "Describe in detail, include screenshots if possible.";
            attachedFilePath = "";
            label2.Text = "Nothing attached.";

        }
    }
}
