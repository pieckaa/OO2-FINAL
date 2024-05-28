using Microsoft.VisualBasic.ApplicationServices;
using OOP2.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2
{
    public partial class test : Form
    {
        private string folderPath = @"C:\Users\Schooby\Documents\testfrom";
        private string[] imageFiles;
        private int currentIndex = 0;
        private int userID;

        // Declare PictureBox and Label at the class level
        private PictureBox pictureBox = new PictureBox();
        private Label label = new Label();

        public test(int userID)
        {
            InitializeComponent();
            this.userID = userID;

            // Initialize PictureBox and Label properties
            pictureBox.Size = new Size(50, 50);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            label.AutoSize = true;
            label.Location = new Point(61, 17);
            this.Load += Test_Load;
        }
        private void Test_Load(object sender, EventArgs e)
        {
            // Load user's profile and username
            LoadCurrentUserDetails();

            // Load comments from the database
            LoadCommentsFromDatabase();
        }
        private void LoadCommentsFromDatabase()
        {
            // Connect to the database
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\Schooby\\Documents\\data.mdb"))
            {
                string query = "SELECT Comments.CommentText, Comments.CommentDate, Users.username, Users.picture " +
                                "FROM Comments " +
                                "INNER JOIN Users ON Comments.userID = Users.userID " +
                                "ORDER BY Comments.CommentDate DESC";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            // Clear existing UI elements in the panel section
                            chatbox.Controls.Clear();

                            int totalPanelHeight = 0; // Total height of all comment panels

                            while (reader.Read())
                            {
                                // Read comment text, date, username, and profile picture from the database
                                string commentText = reader["CommentText"].ToString();
                                DateTime commentDate = (DateTime)reader["CommentDate"];
                                string username = reader["username"].ToString();
                                byte[] imageData = reader["picture"] as byte[];

                                // Create picture box for profile picture
                                // Create picture box for profile picture
                                PictureBox profilePictureBox = new PictureBox();
                                profilePictureBox.Size = new Size(50, 50);
                                profilePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                profilePictureBox.Location = new Point(4, totalPanelHeight + 4); // Adjust Y position based on total height
                                if (imageData != null && imageData.Length > 0)
                                {
                                    using (MemoryStream ms = new MemoryStream(imageData))
                                    {
                                        profilePictureBox.Image = Image.FromStream(ms);
                                    }
                                }
                                chatbox.Controls.Add(profilePictureBox);

                                // Create panel for username
                                Panel usernamePanel = new Panel();
                                usernamePanel.Size = new Size(250, 50); // Fixed size
                                usernamePanel.Location = new Point(60, totalPanelHeight + 4); // Adjust Y position based on total height
                                chatbox.Controls.Add(usernamePanel);


                                // Create label for username inside the panel
                                Label usernameLabel = new Label();
                                usernameLabel.Text = username;
                                usernameLabel.AutoSize = true;
                                usernameLabel.Location = new Point(3, 17); // Adjust label position inside the panel
                                usernamePanel.Controls.Add(usernameLabel);


                                // Create label for comment text
                                Label commentTextLabel = new Label();
                                commentTextLabel.Text = commentText;
                                commentTextLabel.AutoSize = false;
                                commentTextLabel.Width = 800;
                                commentTextLabel.Height = CalculateCommentTextHeight(commentText); // Adjust text box height
                                commentTextLabel.Location = new Point(4, totalPanelHeight + 60); // Adjust Y position based on total height
                                chatbox.ScrollControlIntoView(commentTextLabel);
                                chatbox.Controls.Add(commentTextLabel);


                                // Update total panel height
                                totalPanelHeight += CalculateCommentPanelHeight(commentText);

                            }

                            // Adjust the height of the chatbox panel
                            chatbox.Height = totalPanelHeight;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading comments: " + ex.Message);
                    }
                }
            }
        }

        private int CalculateCommentPanelHeight(string commentText)
        {
            // Calculate the height of the comment text box dynamically
            int textHeight = CalculateCommentTextHeight(commentText);

            // Calculate the required panel height considering other controls and spacing
            int panelHeight = textHeight + 80; // Adjust as needed

            return panelHeight;
        }

        private int CalculateCommentTextHeight(string commentText)
        {
            int maxWidth = 800; // Maximum width of the text box
            int maxHeight = 0; // Maximum height of the text box

            // Create a temporary RichTextBox to measure the text height
            using (RichTextBox tempRTB = new RichTextBox())
            {
                // Set the properties of the temporary RichTextBox
                tempRTB.Width = maxWidth;
                tempRTB.WordWrap = true;
                tempRTB.Text = commentText;

                // Measure the size of the text
                Size size = TextRenderer.MeasureText(tempRTB.Text, tempRTB.Font, new Size(maxWidth, maxHeight), TextFormatFlags.WordBreak);

                // Return the height required to fit the text
                return size.Height;
            }
        }

        private void LoadCurrentUserDetails()
        {
            // Connect to the database
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\Schooby\\Documents\\data.mdb"))
            {
                // Construct SQL command to fetch user details
                string query = "SELECT username, picture FROM users WHERE userID = @UserID";

                // Open the connection
                connection.Open();

                // Create command object
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@UserID", userID);

                    // Execute the query
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // If a record is found
                        {
                            // Get username and profile picture path from the database
                            string username = reader["username"].ToString();
                            byte[] imageData = reader["picture"] as byte[];

                            // Update label with username
                            label.Text = username;

                            // Load profile picture from byte array
                            if (imageData != null && imageData.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    pictureBox.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                // If the profile picture is null or empty, clear the existing image
                                pictureBox.Image = null;
                            }
                        }
                    }
                }
            }
        }
        // Method to save the comment to the database
        private void SaveCommentToDatabase(string commentText)
        {
            // Connect to the database
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\Schooby\\Documents\\data.mdb"))
            {
                string query = "INSERT INTO Comments (userID, CommentText, CommentDate) VALUES (@UserID, @CommentText, @CommentDate)";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Add parameters with explicit data types
                    command.Parameters.Add("@UserID", OleDbType.Integer).Value = userID;
                    command.Parameters.Add("@CommentText", OleDbType.LongVarWChar).Value = commentText;
                    command.Parameters.Add("@CommentDate", OleDbType.Date).Value = DateTime.Now;

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Comment added successfully.");
                            // Optionally, you can update the UI or perform other actions here
                        }
                        else
                        {
                            MessageBox.Show("Failed to add comment.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding comment: " + ex.Message);
                    }
                }
            }
        }

        // Method to calculate the height required for the RichTextBox based on its content


        private void test_Load(object sender, EventArgs e)
        {
            imageFiles = Directory.GetFiles(folderPath, "*.jpg"); 
            ShowImage(currentIndex);
        }
        private void ShowImage(int index)
        {
            if (index >= 0 && index < imageFiles.Length)
            {
                pictureBox1.Image = new System.Drawing.Bitmap(imageFiles[index]);
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            using (RichTextBoxInputDialog inputDialog = new RichTextBoxInputDialog())
            {
                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    string userInput = inputDialog.InputText;

                    // If user cancels the input box or inputs an empty string, return
                    if (string.IsNullOrWhiteSpace(userInput))
                        return;

                    // Load current user's details from the database
                    LoadCurrentUserDetails();

                    // Create panel to hold message components
                    Panel messagePanel = new Panel();
                    messagePanel.BackColor = Color.Transparent; // Set back color to transparent

                    // Create RichTextBox
                    RichTextBox richTextBox = new RichTextBox();
                    richTextBox.ReadOnly = true;
                    richTextBox.Text = userInput;
                    richTextBox.Width = 800; // Set a fixed width for the RichTextBox
                    richTextBox.WordWrap = true; // Wrap long lines
                    richTextBox.BorderStyle = BorderStyle.None; // Remove border if needed

                    // Set the size of the RichTextBox based on the content
                    richTextBox.Height = CalculateTextHeight(richTextBox, userInput) + 10; // Add some padding

                    // Calculate the required height for the panel based on the RichTextBox height
                    int panelHeight = richTextBox.Height + 60; // Add some padding for other components

                    // Set the size of the message panel
                    messagePanel.Size = new Size(859, panelHeight);

                    // Set the location of the RichTextBox within the panel
                    richTextBox.Location = new Point(4, 60);

                    // Add controls to messagePanel
                    messagePanel.Controls.Add(pictureBox);
                    messagePanel.Controls.Add(label);
                    messagePanel.Controls.Add(richTextBox);

                    // Add messagePanel to the FlowLayoutPanel
                    chatbox.Controls.Add(messagePanel);

                    // Increase the height of the chatbox panel
                    SaveCommentToDatabase(userInput);
                    LoadCommentsFromDatabase();
                }
            }

        }

        private int CalculateTextHeight(RichTextBox rtb, string text)
        {
            using (Graphics g = rtb.CreateGraphics())
            {
                SizeF size = g.MeasureString(text, rtb.Font, rtb.Width);
                return (int)Math.Ceiling(size.Height);
            }
        }


        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            currentIndex--;

            if (currentIndex < 0)
            {
                currentIndex = imageFiles.Length - 1;
            }

            ShowImage(currentIndex);
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            currentIndex++;

            if (currentIndex >= imageFiles.Length)
            {
                currentIndex = 0;
            }

            ShowImage(currentIndex);
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            //Brunei brunei = new Brunei(userID);
            //brunei.Show();
        }

        private void star5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
