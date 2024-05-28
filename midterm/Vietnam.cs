using Guna.UI2.WinForms;
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
    public partial class Vietnam : Form
    {
        private FlowLayoutPanel flowLayoutPanel;
        PictureBox innerPictureBox = new PictureBox();
        private int userID;
        private OleDbConnection connection;
        private const string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Schooby\Documents\data.mdb";
        Panel bottomPanel = new Panel();
        List<byte[]> attractionImages = new List<byte[]>();
        int currentIndex = 1;

        public Vietnam(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            InitializeDatabase();
            LoadPanelInfoFromDatabase("Vietnam");
            ModifyAdminBtnVisibility(userID);

            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Location = new Point(539, 682);
            flowLayoutPanel.Size = new Size(872, 500);
            flowLayoutPanel.AutoScroll = false;
            flowLayoutPanel.BackColor = Color.Transparent;
            flowLayoutPanel.BorderStyle = BorderStyle.FixedSingle;
            sorterBox.SelectedIndexChanged += sorterBox_SelectedIndexChanged;
        }

        private void sorterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = sorterBox.SelectedItem.ToString();

            if (selectedOption == "Highest Rated")
            {
                flowLayoutPanel1.Controls.Clear();

                LoadPanelInfoFromDatabaseHighestRated();
            }
            else if (selectedOption == "Most Rated")
            {
                flowLayoutPanel1.Controls.Clear();
                LoadPanelInfoFromDatabaseMostRated();
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string buttonName = Microsoft.VisualBasic.Interaction.InputBox("Enter a name for the attraction:");
            string status = "Attraction";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.png, *.gif, *.bmp)|*.jpg;*.png;*.gif;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (SavePanelInfoToDatabase(openFileDialog.FileName, buttonName, status, "Vietnam"))
                {
                    CreatePanel(openFileDialog.FileName, buttonName, status, "Vietnam");
                }
            }
        }

        private void addBtn2_Click(object sender, EventArgs e)
        {
            string buttonName = Microsoft.VisualBasic.Interaction.InputBox("Enter a name for the delicacy:");
            string status = "Delicacy";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.png, *.gif, *.bmp)|*.jpg;*.png;*.gif;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (SavePanelInfoToDatabase(openFileDialog.FileName, buttonName, status, "Vietnam"))
                {
                    CreatePanel(openFileDialog.FileName, buttonName, status, "Vietnam");
                }
            }
        }

        private void CreateCommentPanel(string commentText, DateTime commentDate, string username, byte[] pictureData, string attraction)
        {
            Panel commentPanel = new Panel();
            commentPanel.Width = 846;
            commentPanel.BackColor = Color.Transparent;
            flowLayoutPanel.Controls.Add(commentPanel);

            Guna2CirclePictureBox commentPictureBox = new Guna2CirclePictureBox();
            commentPictureBox.Location = new Point(3, 4);
            commentPictureBox.Size = new Size(50, 50);
            commentPictureBox.BorderStyle = BorderStyle.None;
            commentPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            if (pictureData != null && pictureData.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(pictureData))
                {
                    commentPictureBox.Image = Image.FromStream(ms);
                }
            }
            else
            {
                commentPictureBox.Image = Resources.no_profile1;
            }

            Label commentLabel = new Label();
            commentLabel.Location = new Point(59, 21);
            commentLabel.AutoSize = true;
            commentLabel.Text = username;

            float userRating = GetUserRatingByUsername(username, attraction);

            if (userRating != null)
            {
                Guna2RatingStar userRatingStar = new Guna2RatingStar();
                userRatingStar.Size = new Size(130, 30);
                userRatingStar.Location = new Point(3, 60);
                userRatingStar.BorderColor = Color.FromArgb(52, 49, 72);
                userRatingStar.RatingColor = Color.FromArgb(139, 201, 77);
                userRatingStar.ReadOnly = true;

                userRatingStar.Value = userRating;

                commentPanel.Controls.Add(userRatingStar);
            }

            Label dateLabel = new Label();
            dateLabel.Location = new Point(780, 21);
            dateLabel.Size = new Size(200, 30);
            dateLabel.Text = commentDate.ToString("MM-dd-yyyy");

            RichTextBox commentRichTextBox = new RichTextBox();
            commentRichTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            commentRichTextBox.Location = new Point(3, 96);
            commentRichTextBox.Width = 840;
            commentRichTextBox.Text = commentText;
            commentRichTextBox.ReadOnly = true;

            commentRichTextBox.ContextMenuStrip = new ContextMenuStrip();

            int commentUserID = GetUserIDByUsername(username);
            if (userID == commentUserID && userID != 1)
            {
                PictureBox optionsPictureBox = new PictureBox();
                optionsPictureBox.Size = new Size(20, 20);
                optionsPictureBox.Location = new Point(823, 40);
                optionsPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                optionsPictureBox.Image = Properties.Resources.bearing1;
                optionsPictureBox.Click += (sender, e) =>
                {
                    ShowOptions(commentText, commentRichTextBox, optionsPictureBox, commentDate);
                };
                commentPanel.Controls.Add(optionsPictureBox);
            }
            using (Graphics g = CreateGraphics())
            {
                SizeF textSize = g.MeasureString(commentText, commentRichTextBox.Font, commentRichTextBox.Width);
                int requiredHeight = (int)Math.Ceiling(textSize.Height) + 10;
                commentRichTextBox.Height = requiredHeight;
            }

            if (userID == commentUserID)
            {
                ToolStripMenuItem editMenuItem = new ToolStripMenuItem("Edit");
                editMenuItem.Click += (sender, e) =>
                {
                    commentRichTextBox.ReadOnly = false;
                };
                commentRichTextBox.ContextMenuStrip.Items.Add(editMenuItem);

                ToolStripMenuItem saveMenuItem = new ToolStripMenuItem("Save");
                saveMenuItem.Click += (sender, e) =>
                {
                    UpdateComment(commentText, commentRichTextBox.Text, commentDate);
                    commentRichTextBox.ReadOnly = true;
                };
                commentRichTextBox.ContextMenuStrip.Items.Add(saveMenuItem);
            }

            if (userID == 1 || userID == commentUserID)
            {
                ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Delete");
                deleteMenuItem.Click += (sender, e) =>
                {
                    DeleteComment(commentText, commentDate);
                    flowLayoutPanel.Controls.Remove(commentPanel);
                };
                commentRichTextBox.ContextMenuStrip.Items.Add(deleteMenuItem);
            }



            commentPanel.Controls.Add(commentPictureBox);
            commentPanel.Controls.Add(commentLabel);
            commentPanel.Controls.Add(dateLabel);
            commentPanel.Controls.Add(commentRichTextBox);

            commentPanel.Height = commentRichTextBox.Bottom + 10;

            AdjustFlowLayoutPanelHeight();
        }
        private float GetUserRatingByUsername(string username, string attraction)
        {
            string selectQuery = "SELECT rating FROM rates INNER JOIN users ON rates.userID = users.userID WHERE username = @Username AND attraction = @Attraction";
            using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Attraction", attraction);
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    float rating = Convert.ToSingle(result);
                    if (rating >= 1 && rating <= 5)
                    {
                        return rating;
                    }
                }
            }
            return 0;
        }
        private void CreatePanel(string imagePath, string buttonName, string status, string country)
        {
            Panel panel = new Panel();
            panel.Size = new Size(271, 338);
            panel.BorderStyle = BorderStyle.None;

            Label homeRate = new Label();
            homeRate.AutoSize = false;
            homeRate.Size = new Size(104, 37);
            homeRate.Location = new Point(76, 6);
            homeRate.Font = new Font("Microsoft Sans Serif", 9.75f);
            homeRate.TextAlign = ContentAlignment.MiddleCenter;
            homeRate.Text = "Ratings: ";
            panel.Controls.Add(homeRate);
            LoadRatingsAndDisplayAverage(buttonName, homeRate);

            RoundCornerPictureBox roundCornerPictureBox = new RoundCornerPictureBox();
            roundCornerPictureBox.Size = new Size(250, 200);
            roundCornerPictureBox.Location = new Point(6, 49);
            roundCornerPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            roundCornerPictureBox.Image = Image.FromFile(imagePath);

            Button button = new Button();
            button.Size = new Size(250, 72);
            button.Location = new Point(3, 255);
            button.Text = buttonName;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 192);
            button.Font = new Font("Nirmala UI", 12, FontStyle.Bold);
            button.MouseDown += Button_MouseDown;
            button.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.Hide();
                    OpenForm(buttonName, buttonName, homeRate);
                }
            };

            panel.Controls.Add(roundCornerPictureBox);
            panel.Controls.Add(button);

            if (status == "Attraction")
            {
                if (country == "Vietnam")
                {
                    flowLayoutPanel1.Controls.Add(panel);
                    flowLayoutPanel1.Width += 256;
                }
            }
            else if (status == "Delicacy")
            {
                if (country == "Vietnam")
                {
                    flowLayoutPanel2.Controls.Add(panel);
                    flowLayoutPanel2.Width += 256;
                }
            }
        }
        private bool SavePanelInfoToDatabase(string imagePath, string buttonName, string status, string country)
        {
            string insertQuery = "INSERT INTO panelSpots (ImageFilePath, Attraction, Status, Country) VALUES (@ImageFilePath, @Attraction, @Status, @Country)";
            string checkIfExistsQuery = "SELECT COUNT(*) FROM panelSpots WHERE Attraction = @Attraction AND Country = @Country";

            try
            {
                int existingAttractionCount;
                using (OleDbCommand checkCommand = new OleDbCommand(checkIfExistsQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Attraction", buttonName);
                    checkCommand.Parameters.AddWithValue("@Country", country);
                    existingAttractionCount = (int)checkCommand.ExecuteScalar();
                }

                if (existingAttractionCount > 0)
                {
                    MessageBox.Show("This already Exists");
                    return false;
                }

                using (OleDbCommand command = new OleDbCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@ImageFilePath", imagePath);
                    command.Parameters.AddWithValue("@Attraction", buttonName);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@Country", country);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (OleDbException ex)
            {
                return false;
            }
        }

        private void LoadPanelInfoFromDatabase(string country)
        {
            string selectQuery = "SELECT ImageFilePath, Attraction, Status FROM panelSpots WHERE Country = @Country";
            using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@Country", country);
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string imagePath = reader["ImageFilePath"].ToString();
                        string buttonName = reader["Attraction"].ToString();
                        string status = reader["Status"].ToString();
                        CreatePanel(imagePath, buttonName, status, country);
                    }
                }
            }
        }




        private void OpenForm(string buttonText, string buttonName, Label homeRate)
        {
            Label totalRates = new Label();
            Label avgRating = new Label();
            Guna2ProgressBar fifthProgressBar = new Guna2ProgressBar();
            Guna2ProgressBar fourthProgressBar = new Guna2ProgressBar();
            Guna2ProgressBar thirdProgressBar = new Guna2ProgressBar();
            Guna2ProgressBar secondProgressBar = new Guna2ProgressBar();
            Guna2ProgressBar firstProgressBar = new Guna2ProgressBar();


            LoadExistingComments(buttonText);
            LoadImagesFromDatabase(buttonText);
            LoadRatingsFromDatabase(buttonText);

            Form form = new Form();
            form.BackColor = Color.FromArgb(221, 213, 208);
            form.Size = new Size(1451, 971);
            form.AutoScroll = false;
            form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = buttonText;
            form.Show();

            Panel topPanel = new Panel();
            topPanel.Dock = DockStyle.Fill;
            topPanel.AutoScroll = true;
            topPanel.BackColor = Color.FromArgb(221, 213, 208);
            form.Controls.Add(topPanel);
            topPanel.Controls.Add(flowLayoutPanel);

            Panel analytic = new Panel();
            analytic.Location = new Point(58, 630);
            analytic.Size = new Size(453, 241);
            analytic.BackColor = Color.Transparent;
            topPanel.Controls.Add(analytic);

            avgRating.Font = new Font("Nirmala UI", 36f, FontStyle.Bold);
            avgRating.AutoSize = true;
            avgRating.Location = new Point(17, 80);
            analytic.Controls.Add(avgRating);

            totalRates.Font = new Font("Nirmala UI", 9.75f);
            totalRates.ForeColor = Color.Gray;
            totalRates.AutoSize = true;
            totalRates.Location = new Point(25, 153);
            analytic.Controls.Add(totalRates);


            fifthProgressBar.Location = new Point(162, 173);
            fifthProgressBar.Size = new Size(250, 20);
            fifthProgressBar.ProgressColor = Color.FromArgb(139, 201, 77);
            fifthProgressBar.FillColor = Color.FromArgb(255, 255, 192);
            fifthProgressBar.AutoRoundedCorners = true;
            analytic.Controls.Add(fifthProgressBar);

            fourthProgressBar.Location = new Point(162, 143);
            fourthProgressBar.Size = new Size(250, 20);
            fourthProgressBar.ProgressColor = Color.FromArgb(139, 201, 77);
            fourthProgressBar.FillColor = Color.FromArgb(255, 255, 192);
            fourthProgressBar.AutoRoundedCorners = true;
            analytic.Controls.Add(fourthProgressBar);

            thirdProgressBar.Location = new Point(162, 113);
            thirdProgressBar.Size = new Size(250, 20);
            thirdProgressBar.ProgressColor = Color.FromArgb(139, 201, 77);
            thirdProgressBar.FillColor = Color.FromArgb(255, 255, 192);
            thirdProgressBar.AutoRoundedCorners = true;
            analytic.Controls.Add(thirdProgressBar);

            secondProgressBar.Location = new Point(162, 83);
            secondProgressBar.Size = new Size(250, 20);
            secondProgressBar.ProgressColor = Color.FromArgb(139, 201, 77);
            secondProgressBar.FillColor = Color.FromArgb(255, 255, 192);
            secondProgressBar.AutoRoundedCorners = true;
            analytic.Controls.Add(secondProgressBar);

            firstProgressBar.Location = new Point(162, 53);
            firstProgressBar.Size = new Size(250, 20);
            firstProgressBar.ProgressColor = Color.FromArgb(139, 201, 77);
            firstProgressBar.FillColor = Color.FromArgb(255, 255, 192);
            firstProgressBar.AutoRoundedCorners = true;
            analytic.Controls.Add(firstProgressBar);



            int[] yCoordinates = { 48, 78, 108, 138, 168 };

            for (int i = 0; i < 5; i++)
            {
                Label ratingNum = new Label();

                ratingNum.Text = (5 - i).ToString();
                ratingNum.Font = new Font("Nirmala UI", 14.25f, FontStyle.Bold);
                ratingNum.AutoSize = true;

                ratingNum.Location = new Point(129, yCoordinates[i]);

                analytic.Controls.Add(ratingNum);
            }



            Panel ratePanel = new Panel();
            ratePanel.Location = new Point(58, 861);
            ratePanel.Size = new Size(453, 268);
            ratePanel.BackColor = Color.Transparent;
            topPanel.Controls.Add(ratePanel);

            Guna2RatingStar RatingStar = new Guna2RatingStar();
            RatingStar.Location = new Point(126, 51);
            RatingStar.Size = new Size(200, 40);
            RatingStar.RatingColor = Color.Green;
            RatingStar.Visible = false;
            ratePanel.Controls.Add(RatingStar);

            Guna2Button Guna2Button = new Guna2Button();
            Guna2Button.Location = new Point(126, 115);
            Guna2Button.Size = new Size(200, 45);
            Guna2Button.Text = "Give Rating";
            Guna2Button.Visible = false;
            Guna2Button.Font = new Font("Nirmala UI", 8f, FontStyle.Bold);
            Guna2Button.FillColor = Color.FromArgb(52, 49, 72);
            Guna2Button.BackColor = Color.Transparent;
            Guna2Button.ForeColor = Color.FromArgb(252, 247, 248);
            Guna2Button.AutoRoundedCorners = true;


            RatingStar.MouseClick += RatingStar_MouseClick;
            RatingStar.ContextMenuStrip = CreateRatingContextMenu();

            int userRating = GetUserRating(userID, buttonText);
            if (userRating != -1)
            {
                RatingStar.Value = userRating;
            }
            Guna2Button.Click += (sender, e) =>
            {
                int ratingValue = (int)RatingStar.Value;

                int existingRating = GetExistingRating(userID, buttonText);
                if (existingRating != -1)
                {
                    DialogResult result = MessageBox.Show("You have already rated this attraction. Do you want to update your rating?", "Update Rating", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        UpdateRatingInDatabase(userID, buttonText, ratingValue);
                        ClearAndReloadAnalyticPanel();
                    }
                }

                else
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to upload this rating?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        SaveRatingToDatabase(buttonText, ratingValue);
                        ClearAndReloadAnalyticPanel();
                    }
                }
            };
            ratePanel.Controls.Add(Guna2Button);

            void LoadRatingsFromDatabase(string attraction)
            {
                Guna2ProgressBar[] progressBars = { firstProgressBar, secondProgressBar, thirdProgressBar, fourthProgressBar, fifthProgressBar };

                string selectQuery = "SELECT rating, COUNT(*) FROM rates WHERE attraction = @Attraction GROUP BY rating";

                int totalRatings = 0;
                int totalScore = 0;

                using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Attraction", attraction);

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int rating = Convert.ToInt32(reader["rating"]);
                            int count = Convert.ToInt32(reader[1]);

                            totalRatings += count;
                            totalScore += rating * count;

                            progressBars[5 - rating].Value = count;
                        }
                    }
                }

                foreach (var progressBar in progressBars)
                {
                    progressBar.Maximum = totalRatings;
                }

                if (totalRatings == 0)
                {
                    avgRating.Text = "😭";
                    totalRates.Text = "No rating";
                }
                else
                {
                    double averageRating = (double)totalScore / totalRatings;
                    avgRating.Text = averageRating.ToString("0.0");
                    totalRates.Text = totalRatings + " rating" + (totalRatings == 1 ? "" : "s");
                }
            }


            void SaveRatingToDatabase(string attraction, int rating)
            {
                string insertQuery = "INSERT INTO rates (userID, attraction, rating) VALUES (@UserID, @Attraction, @Rating)";

                using (OleDbCommand command = new OleDbCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@Attraction", attraction);
                    command.Parameters.AddWithValue("@Rating", rating);

                    command.ExecuteNonQuery();
                }

                ClearAndReloadAnalyticPanel();
            }

            void ClearAndReloadAnalyticPanel()
            {
                firstProgressBar.Value = 0;
                secondProgressBar.Value = 0;
                thirdProgressBar.Value = 0;
                fourthProgressBar.Value = 0;
                fifthProgressBar.Value = 0;

                LoadRatingsFromDatabase(buttonText);
            }

            ContextMenuStrip CreateRatingContextMenu()
            {
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                ToolStripMenuItem deleteRatingMenuItem = new ToolStripMenuItem("Delete Rating");
                deleteRatingMenuItem.Click += DeleteRatingMenuItem_Click;
                contextMenuStrip.Items.Add(deleteRatingMenuItem);
                return contextMenuStrip;
            }

            int GetUserRating(int userID, string attraction)
            {
                string selectQuery = "SELECT rating FROM rates WHERE userID = @UserID AND attraction = @Attraction";

                using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@Attraction", attraction);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }

                return -1;
            }

            void DeleteRatingMenuItem_Click(object sender, EventArgs e)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete your rating?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DeleteUserRating(userID, buttonText);
                    ClearAndReloadAnalyticPanel();
                    RatingStar.Value = 0;
                }
            }

            void DeleteUserRating(int userID, string attraction)
            {
                string deleteQuery = "DELETE FROM rates WHERE userID = @UserID AND attraction = @Attraction";

                using (OleDbCommand command = new OleDbCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@Attraction", attraction);

                    command.ExecuteNonQuery();
                }
            }

            void RatingStar_MouseClick(object sender, MouseEventArgs e)
            {
                Guna2RatingStar ratingStar = (Guna2RatingStar)sender;

                float starWidth = ratingStar.Width / ratingStar.Maximum;

                int clickedStarIndex = (int)(e.X / starWidth) + 1;

                ratingStar.Value = clickedStarIndex;
            }

            int GetExistingRating(int userID, string attraction)
            {
                string selectQuery = "SELECT rating FROM rates WHERE userID = @UserID AND attraction = @Attraction";

                using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@Attraction", attraction);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
                return -1;
            }

            void UpdateRatingInDatabase(int userID, string attraction, int newRating)
            {
                string updateQuery = "UPDATE rates SET rating = @Rating WHERE userID = @UserID AND attraction = @Attraction";

                using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Rating", newRating);
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@Attraction", attraction);

                    command.ExecuteNonQuery();
                }
            }

            Label showRate = new Label();
            showRate.Location = new Point(8, 8);
            showRate.Size = new Size(442, 36);
            showRate.Font = new Font("Nirmala UI", 15.75f, FontStyle.Bold);
            showRate.Text = "Rate attraction?";
            showRate.TextAlign = ContentAlignment.MiddleCenter;
            ratePanel.Controls.Add(showRate);

            bool ratingControlsVisible = false;

            showRate.Click += (sender, e) =>
            {
                ratingControlsVisible = !ratingControlsVisible;

                RatingStar.Visible = ratingControlsVisible;
                Guna2Button.Visible = ratingControlsVisible;
            };



            PictureBox pictureBox = new PictureBox();
            pictureBox.BorderStyle = BorderStyle.None;
            pictureBox.Location = new Point(5, 25);
            pictureBox.Size = new Size(32, 32);
            pictureBox.Image = Properties.Resources.back;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Click += (sender, e) =>
            {
                form.Hide();
                this.Show();
                LoadRatingsAndDisplayAverage(buttonName, homeRate);
            }; topPanel.Controls.Add(pictureBox);

            Label label = new Label();
            label.Location = new Point(51, 20);
            label.Size = new Size(460, 37);
            label.Font = new Font("Nirmala UI", 20.25f, FontStyle.Bold);
            label.Text = buttonText;
            topPanel.Controls.Add(label);

            Panel innerPanel = new Panel();
            innerPanel.Location = new Point(58, 89);
            innerPanel.Size = new Size(453, 465);
            innerPanel.BackColor = Color.Transparent;
            innerPanel.BorderStyle = BorderStyle.FixedSingle;
            topPanel.Controls.Add(innerPanel);

            Label innerLabel = new Label();
            innerLabel.Location = new Point(3, 10);
            innerLabel.BorderStyle = BorderStyle.None;
            innerLabel.Size = new Size(200, 30);
            innerLabel.Font = new Font("Nirmala UI", 15.75f, FontStyle.Bold);
            innerLabel.Text = "About";
            innerPanel.Controls.Add(innerLabel);

            RichTextBox innerRichTextBox = new RichTextBox();
            innerRichTextBox.BackColor = Color.FromArgb(221, 213, 208);
            innerRichTextBox.Location = new Point(8, 43);
            innerRichTextBox.BorderStyle = BorderStyle.None;
            innerRichTextBox.Size = new Size(428, 410);
            innerRichTextBox.Font = new Font("Nirmala UI", 14.25f);
            innerRichTextBox.Text = "Input something";
            innerRichTextBox.TabStop = false;
            innerRichTextBox.ReadOnly = true;

            if (userID == 1)
            {
                innerRichTextBox.ReadOnly = false;
            }
            innerPanel.Controls.Add(innerRichTextBox);

            Button innerButton = new Button();
            innerButton.Location = new Point(424, 560);
            innerButton.Size = new Size(85, 45);
            innerButton.Text = "Enter";
            innerButton.Font = new Font("Nirmala UI", 10f);
            innerButton.BackColor = Color.Transparent;
            innerButton.FlatAppearance.BorderSize = 1;
            innerButton.FlatAppearance.BorderColor = Color.Black;
            innerButton.FlatStyle = FlatStyle.Flat;
            innerButton.Visible = false;
            if (userID == 1)
            {
                innerButton.Visible = true;
            }
            innerButton.Click += (sender, e) =>
            {
                using (OleDbCommand command = new OleDbCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE panelSpots SET Description = @Description WHERE Attraction = @Attraction";
                    command.Parameters.AddWithValue("@Description", innerRichTextBox.Text);
                    command.Parameters.AddWithValue("@Attraction", buttonText);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Description in saved");
            };
            topPanel.Controls.Add(innerButton);

            string description = GetAttractionDescription(buttonText);
            if (!string.IsNullOrEmpty(description))
            {
                innerRichTextBox.Text = description;
            }

            //if (userID == 1)
            {
                innerPictureBox.Location = new Point(539, 89);
                innerPictureBox.Size = new Size(862, 465);
                innerPictureBox.BackColor = Color.Transparent;
                innerPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                innerPictureBox.ContextMenuStrip = new ContextMenuStrip();
                ToolStripMenuItem deleteImageMenuItem = new ToolStripMenuItem("Delete Image");
                deleteImageMenuItem.Click += DeleteImageMenuItem_Click;
                innerPictureBox.ContextMenuStrip.Items.Add(deleteImageMenuItem);
            }

            topPanel.Controls.Add(innerPictureBox);

            Button picUpload = new Button();
            picUpload.Location = new Point(284, 560);
            picUpload.Size = new Size(130, 45);
            picUpload.Text = "Upload Image";
            picUpload.Font = new Font("Nirmala UI", 10f);
            picUpload.BackColor = Color.Transparent;
            picUpload.FlatAppearance.BorderSize = 1;
            picUpload.FlatAppearance.BorderColor = Color.Black;
            picUpload.FlatStyle = FlatStyle.Flat;
            picUpload.Visible = false;
            if (userID == 1)
            {
                picUpload.Visible = true;
            }
            picUpload.Click += (sender, e) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif) | *.jpg; *.jpeg; *.png; *.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveImageToDatabase(buttonText, Image.FromFile(openFileDialog.FileName));
                    LoadImagesFromDatabase(buttonText);
                }
            };
            topPanel.Controls.Add(picUpload);

            PictureBox nextPictureBox = new PictureBox();
            nextPictureBox.Location = new Point(1384, 272);
            nextPictureBox.Size = new Size(32, 64);
            nextPictureBox.BackColor = Color.Transparent;
            nextPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            nextPictureBox.Image = Properties.Resources.nextLates;
            nextPictureBox.Click += (sender, e) =>
            {
                if (attractionImages.Count > 0)
                {
                    currentIndex = (currentIndex + 1) % attractionImages.Count;
                    byte[] imageData = attractionImages[currentIndex];
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        innerPictureBox.Image = Image.FromStream(ms);
                    }
                }

            };
            topPanel.Controls.Add(nextPictureBox);

            PictureBox prevPictureBox = new PictureBox();
            prevPictureBox.Location = new Point(526, 272);
            prevPictureBox.Size = new Size(32, 64);
            prevPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            prevPictureBox.BackColor = Color.Transparent;
            prevPictureBox.Image = Properties.Resources.prevLatest;
            prevPictureBox.Click += (sender, e) =>
            {
                if (attractionImages.Count > 0)
                {
                    currentIndex = (currentIndex - 1 + attractionImages.Count) % attractionImages.Count;
                    byte[] imageData = attractionImages[currentIndex];
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        innerPictureBox.Image = Image.FromStream(ms);
                    }
                }
            };
            topPanel.Controls.Add(prevPictureBox);
            innerPictureBox.SendToBack();

            Guna2Button commentButton = new Guna2Button();
            commentButton.Location = new Point(539, 644);
            commentButton.Size = new Size(184, 32);
            commentButton.Text = "Comment";
            commentButton.Font = new Font("Nirmala UI", 8f, FontStyle.Bold);
            commentButton.FillColor = Color.FromArgb(52, 49, 72);
            commentButton.BackColor = Color.Transparent;
            commentButton.ForeColor = Color.FromArgb(252, 247, 248);
            commentButton.AutoRoundedCorners = true;
            commentButton.Click += (sender, e) =>
            {
                using (RichTextBoxInputDialog inputDialog = new RichTextBoxInputDialog())
                {
                    if (inputDialog.ShowDialog() == DialogResult.OK)
                    {
                        string commentText = inputDialog.InputText;
                        if (!string.IsNullOrWhiteSpace(commentText))
                        {
                            SaveCommentToDatabase(commentText);
                            LoadExistingComments(buttonText);
                        }
                    }
                }
            };
            topPanel.Controls.Add(commentButton);

            void SaveCommentToDatabase(string commentText)
            {
                string insertQuery = "INSERT INTO feedback (comment, userID, attraction, commentDate) VALUES (@Comment, @UserID, @Attraction, @CommentDate)";

                using (OleDbCommand command = new OleDbCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Comment", commentText);
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@Attraction", buttonText);
                    command.Parameters.Add("@CommentDate", OleDbType.Date).Value = DateTime.Now;

                    command.ExecuteNonQuery();
                }
            }

            topPanel.Controls.Add(bottomPanel);

        }





        private void LoadExistingComments(string attraction)
        {
            flowLayoutPanel.Controls.Clear();

            string selectQuery = "SELECT feedback.comment, feedback.commentDate, users.username, users.picture FROM feedback INNER JOIN users ON feedback.userID = users.userID WHERE attraction = @Attraction ORDER BY feedback.commentDate ASC";
            using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@Attraction", attraction);
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string commentText = reader["comment"].ToString();
                        DateTime commentDate = Convert.ToDateTime(reader["commentDate"]);
                        string username = reader["username"].ToString();
                        byte[] pictureData = null;

                        if (reader["picture"] != DBNull.Value && reader["picture"] != null)
                        {
                            pictureData = (byte[])reader["picture"];
                        }

                        CreateCommentPanel(commentText, commentDate, username, pictureData, attraction);
                    }
                }
            }

            AdjustFlowLayoutPanelHeight();
            bottomPanel.Location = new Point(flowLayoutPanel.Location.X, flowLayoutPanel.Bottom + 10);
            bottomPanel.Size = new Size(flowLayoutPanel.Width, 60);
            bottomPanel.BackColor = Color.Transparent;


        }
        private void UpdateComment(string oldComment, string newComment, DateTime commentDate)
        {
            string updateQuery = "UPDATE feedback SET comment = @NewComment WHERE comment = @OldComment AND commentDate = @CommentDate";
            using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@NewComment", newComment);
                command.Parameters.AddWithValue("@OldComment", oldComment);
                command.Parameters.Add("@CommentDate", OleDbType.Date).Value = commentDate;
                command.ExecuteNonQuery();
            }
        }
        private void DeleteComment(string commentText, DateTime commentDate)
        {
            string deleteQuery = "DELETE FROM feedback WHERE comment = @Comment AND commentDate = @CommentDate";
            using (OleDbCommand command = new OleDbCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@Comment", commentText);
                command.Parameters.Add("@CommentDate", OleDbType.Date).Value = commentDate;
                command.ExecuteNonQuery();
            }
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            if (userID == 1 && e.Button == MouseButtons.Right)
            {
                Button button = sender as Button;

                ContextMenu contextMenu = new ContextMenu();
                MenuItem deleteMenuItem = new MenuItem("Delete");
                deleteMenuItem.Click += (s, ev) =>
                {
                    Panel panel = button.Parent as Panel;
                    if (panel != null)
                    {
                        string buttonName = button.Text;

                        DeletePanelInfoFromDatabase(buttonName);
                        flowLayoutPanel1.Controls.Remove(panel);
                        flowLayoutPanel2.Controls.Remove(panel);
                    }
                };
                contextMenu.MenuItems.Add(deleteMenuItem);
                contextMenu.Show(button, new Point(e.X, e.Y));
            }
        }

        private void DeletePanelInfoFromDatabase(string buttonName)
        {
            string deleteImagesQuery = "DELETE FROM pictures WHERE attraction = @Attraction";
            using (OleDbCommand deleteImagesCommand = new OleDbCommand(deleteImagesQuery, connection))
            {
                deleteImagesCommand.Parameters.AddWithValue("@Attraction", buttonName);
                deleteImagesCommand.ExecuteNonQuery();
            }

            string deleteCommentsQuery = "DELETE FROM feedback WHERE attraction = @Attraction";
            using (OleDbCommand deleteCommentsCommand = new OleDbCommand(deleteCommentsQuery, connection))
            {
                deleteCommentsCommand.Parameters.AddWithValue("@Attraction", buttonName);
                deleteCommentsCommand.ExecuteNonQuery();
            }

            string deleteDescriptionQuery = "UPDATE panelSpots SET Description = NULL WHERE Attraction = @Attraction";
            using (OleDbCommand deleteDescriptionCommand = new OleDbCommand(deleteDescriptionQuery, connection))
            {
                deleteDescriptionCommand.Parameters.AddWithValue("@Attraction", buttonName);
                deleteDescriptionCommand.ExecuteNonQuery();
            }

            string deleteRatingsQuery = "DELETE FROM rates WHERE attraction = @Attraction";
            using (OleDbCommand deleteRatingsCommand = new OleDbCommand(deleteRatingsQuery, connection))
            {
                deleteRatingsCommand.Parameters.AddWithValue("@Attraction", buttonName);
                deleteRatingsCommand.ExecuteNonQuery();
            }

            string deletePanelQuery = "DELETE FROM panelSpots WHERE Attraction = @Attraction";
            using (OleDbCommand deletePanelCommand = new OleDbCommand(deletePanelQuery, connection))
            {
                deletePanelCommand.Parameters.AddWithValue("@Attraction", buttonName);
                deletePanelCommand.ExecuteNonQuery();
            }
        }

        private void LoadPanelInfoFromDatabaseMostRated()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();

            string selectQuery = "SELECT ImageFilePath, Attraction, Status, Country FROM panelSpots";
            using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
            {
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    List<(string imagePath, string attractionName, int totalRates, string status, string country)> attractions = new List<(string, string, int, string, string)>();

                    while (reader.Read())
                    {
                        string imagePath = reader["ImageFilePath"].ToString();
                        string attractionName = reader["Attraction"].ToString();
                        string status = reader["Status"].ToString();
                        string country = reader["Country"].ToString();
                        int totalRates = GetTotalRatings(attractionName, country);
                        attractions.Add((imagePath, attractionName, totalRates, status, country));
                    }

                    attractions = attractions.OrderByDescending(a => a.totalRates).ToList();

                    foreach (var attraction in attractions)
                    {
                        if (attraction.status == "Attraction")
                        {
                            CreatePanel(attraction.imagePath, attraction.attractionName, "Attraction", attraction.country);
                        }
                        else if (attraction.status == "Delicacy")
                        {
                            CreatePanel(attraction.imagePath, attraction.attractionName, "Delicacy", attraction.country);
                        }
                    }
                }
            }
        }

        private void LoadPanelInfoFromDatabaseHighestRated()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();

            string selectQuery = "SELECT ImageFilePath, Attraction, Status, Country FROM panelSpots";
            using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
            {
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    List<(string imagePath, string attractionName, double avgRating, string status, string country)> attractions = new List<(string, string, double, string, string)>();

                    while (reader.Read())
                    {
                        string imagePath = reader["ImageFilePath"].ToString();
                        string attractionName = reader["Attraction"].ToString();
                        string status = reader["Status"].ToString();
                        string country = reader["Country"].ToString();
                        double avgRating = GetAverageRating(attractionName, country);
                        attractions.Add((imagePath, attractionName, avgRating, status, country));
                    }

                    attractions = attractions.OrderByDescending(a => a.avgRating).ToList();

                    foreach (var attraction in attractions)
                    {
                        if (attraction.status == "Attraction")
                        {
                            CreatePanel(attraction.imagePath, attraction.attractionName, "Attraction", attraction.country);
                        }
                        else if (attraction.status == "Delicacy")
                        {
                            CreatePanel(attraction.imagePath, attraction.attractionName, "Delicacy", attraction.country);
                        }
                    }
                }
            }
        }

        private void LoadRatingsAndDisplayAverage(string attractionName, Label homeRate)
        {
            string selectQuery = "SELECT rating FROM rates WHERE attraction = @Attraction";

            int totalRatings = 0;
            int totalScore = 0;

            using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@Attraction", attractionName);

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int rating = Convert.ToInt32(reader["rating"]);
                        totalScore += rating;
                        totalRatings++;
                    }
                }
            }

            if (totalRatings > 0)
            {
                double averageRating = (double)totalScore / totalRatings;
                homeRate.Text = "Ratings: " + averageRating.ToString("0.0");
            }
            else
            {
                homeRate.Text = "Ratings: N/A";
            }
        }

        private void SaveImageToDatabase(string attractionName, Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                byte[] imageBytes = ms.ToArray();

                string insertQuery = "INSERT INTO pictures (attraction, pictures) VALUES (@Attraction, @Pictures)";
                using (OleDbCommand command = new OleDbCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Attraction", attractionName);
                    command.Parameters.AddWithValue("@Pictures", imageBytes);
                    command.ExecuteNonQuery();
                }
            }

            attractionImages.Clear();
            innerPictureBox.Image = null;

            LoadImagesFromDatabase(attractionName);
        }
        private void LoadImagesFromDatabase(string attractionName)
        {
            string selectQuery = "SELECT pictures FROM pictures WHERE attraction = @Attraction";
            using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@Attraction", attractionName);
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    attractionImages.Clear();

                    while (reader.Read())
                    {
                        byte[] imageData = (byte[])reader["pictures"];
                        attractionImages.Add(imageData);
                    }
                }
            }

            if (attractionImages.Count > 0)
            {
                byte[] firstImageData = attractionImages[0];
                using (MemoryStream ms = new MemoryStream(firstImageData))
                {
                    innerPictureBox.Image = Image.FromStream(ms);
                }

                innerPictureBox.Tag = attractionName;

                currentIndex = 0;
            }
            else
            {
                innerPictureBox.Image = null;
            }
        }

        private void DeleteImageMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this image?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string attractionName = innerPictureBox.Tag?.ToString();

                    if (!string.IsNullOrEmpty(attractionName))
                    {
                        DeleteImageFromDatabase(attractionName);

                        attractionImages.RemoveAt(currentIndex);
                        if (attractionImages.Count > 0)
                        {
                            byte[] imageData = attractionImages[currentIndex];
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                innerPictureBox.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            innerPictureBox.Image = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("NO picture on Display.", "Information", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteImageFromDatabase(string attractionName)
        {
            string deleteQuery = "DELETE FROM pictures WHERE attraction = @Attraction";

            using (OleDbCommand command = new OleDbCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@Attraction", attractionName);
                command.ExecuteNonQuery();
            }
        }

        private double GetAverageRating(string attractionName, string country)
        {
            string selectQuery = "SELECT rating FROM rates WHERE attraction = @Attraction";

            int totalRatings = 0;
            int totalScore = 0;

            using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@Attraction", attractionName);

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int rating = Convert.ToInt32(reader["rating"]);
                        totalScore += rating;
                        totalRatings++;
                    }
                }
            }

            if (totalRatings > 0)
            {
                return (double)totalScore / totalRatings;
            }
            else
            {
                return 0;
            }
        }
        private int GetTotalRatings(string attractionName, string country)
        {
            string selectQuery = "SELECT COUNT(*) FROM rates WHERE attraction = @Attraction";

            using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@Attraction", attractionName);
                return (int)command.ExecuteScalar();
            }
        }

        private string GetAttractionDescription(string attractionName)
        {
            string description = string.Empty;
            string selectQuery = "SELECT Description FROM panelSpots WHERE Attraction = @Attraction";

            using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@Attraction", attractionName);

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        description = reader["Description"].ToString();
                    }
                }
            }

            return description;
        }
        private void AdjustFlowLayoutPanelHeight()
        {
            int totalHeight = 0;
            foreach (Control control in flowLayoutPanel.Controls)
            {
                totalHeight += control.Height;
            }
            totalHeight += 10;
            flowLayoutPanel.Height = totalHeight;

            flowLayoutPanel.AutoScroll = true;

        }
        private void ShowOptions(string commentText, RichTextBox commentRichTextBox, PictureBox bearingImage, DateTime commentDate)
        {
            ContextMenu optionsMenu = new ContextMenu();

            MenuItem editMenuItem = new MenuItem("Edit");
            editMenuItem.Click += (sender, e) =>
            {
                commentRichTextBox.ReadOnly = false;
            };
            optionsMenu.MenuItems.Add(editMenuItem);

            MenuItem saveMenuItem = new MenuItem("Save");
            saveMenuItem.Click += (sender, e) =>
            {
                UpdateComment(commentText, commentRichTextBox.Text, commentDate);
                commentRichTextBox.ReadOnly = true;
            };
            optionsMenu.MenuItems.Add(saveMenuItem);

            MenuItem deleteMenuItem = new MenuItem("Delete");
            deleteMenuItem.Click += (sender, e) =>
            {
                DeleteComment(commentText, commentDate);
                flowLayoutPanel.Controls.Remove(commentRichTextBox.Parent);
            };
            optionsMenu.MenuItems.Add(deleteMenuItem);

            optionsMenu.Show(bearingImage, new Point(0, bearingImage.Height));
        }
        private int GetUserIDByUsername(string username)
        {
            int userID = -1;
            string selectQuery = "SELECT userID FROM users WHERE username = @Username";
            using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    userID = Convert.ToInt32(result);
                }
            }
            return userID;
        }
        private void InitializeDatabase()
        {
            connection = new OleDbConnection(connectionString);
            connection.Open();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            connection.Close();
        }
        private void ModifyAdminBtnVisibility(int userID)
        {
            if (userID == 1)
            {
                addBtn.Visible = true;
                addBtn2.Visible = true;
            }
            else
            {
                addBtn.Visible = false;
                addBtn2.Visible = false;
            }
        }
    }
}
