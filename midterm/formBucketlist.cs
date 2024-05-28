using Guna.UI2.WinForms;
using Microsoft.VisualBasic;
using OOP2;
using System;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Guna.UI2.WinForms.Suite.Descriptions;
using OOP2.Properties;


namespace midterm
{
    public partial class formBucketlist : Form
    {
        private int userID;
        private Color selectedColor;
        private OleDbConnection connection;
        private const string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Schooby\Documents\data.mdb";
        FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();

        public formBucketlist(int userID)
        {
            InitializeComponent();
            this.userID = userID; 
            LoadBucketListsFromDatabase();
        }
        private void LoadBucketListsFromDatabase()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM bucketList WHERE userID = @userID";
                using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@userID", userID);
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = reader["title"].ToString();
                            Color color = Color.FromArgb(Convert.ToInt32(reader["color"]));

                            AddBucketListToUI(title, color);
                        }
                    }
                }
            }
        }

        private void DeletePanel(Panel panel, string title)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this bucket list?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                holderFlowLayout.Controls.Remove(panel);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string deleteFormQuery = "DELETE FROM bucketList WHERE title = @title AND userID = @userID";
                    using (OleDbCommand command = new OleDbCommand(deleteFormQuery, connection))
                    {
                        command.Parameters.AddWithValue("@title", title);
                        command.Parameters.AddWithValue("@userID", userID);
                        command.ExecuteNonQuery();
                    }
                    string deleteDescriptionsQuery = "DELETE FROM bucketList_Description WHERE title = @title AND userID = @userID";
                    using (OleDbCommand command = new OleDbCommand(deleteDescriptionsQuery, connection))
                    {
                        command.Parameters.AddWithValue("@title", title);
                        command.Parameters.AddWithValue("@userID", userID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            else
            {
            }
        }

        private void EditBucketList(Panel panel, string currentTitle)
        {
            string newTitle = Interaction.InputBox("Enter new title:", "Edit Bucket List Title", currentTitle);

            if (!string.IsNullOrWhiteSpace(newTitle))
            {
                if (TitleExists(newTitle))
                {
                    MessageBox.Show("Title already exists. Please choose a different title.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (Control control in panel.Controls)
                {
                    if (control is Label)
                    {
                        ((Label)control).Text = newTitle;
                        break;
                    }
                }

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE bucketList SET title = @newTitle WHERE title = @currentTitle AND userID = @userID";
                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@newTitle", newTitle);
                        command.Parameters.AddWithValue("@currentTitle", currentTitle);
                        command.Parameters.AddWithValue("@userID", userID);
                        command.ExecuteNonQuery();
                    }

                    string updateCheckboxTitlesQuery = "UPDATE bucketList_Description SET title = @newTitle WHERE title = @currentTitle AND userID = @userID";
                    using (OleDbCommand command = new OleDbCommand(updateCheckboxTitlesQuery, connection))
                    {
                        command.Parameters.AddWithValue("@newTitle", newTitle);
                        command.Parameters.AddWithValue("@currentTitle", currentTitle);
                        command.Parameters.AddWithValue("@userID", userID);
                        command.ExecuteNonQuery();
                    }
                }

                holderFlowLayout.Controls.Clear();

                LoadBucketListsFromDatabase();
            }
        }


        private void AddBucketListToUI(string title, Color color)
        {
            Panel panel1 = new Panel();
            panel1.Size = new Size(320, 272);
            holderFlowLayout.Controls.Add(panel1);

            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Delete");
            deleteMenuItem.Click += (sender, e) =>
            {
                DeletePanel(panel1, title);
            };
            contextMenuStrip.Items.Add(deleteMenuItem);
            panel1.ContextMenuStrip = contextMenuStrip;

            ToolStripMenuItem editMenuItem = new ToolStripMenuItem("Edit");
            editMenuItem.Click += (sender, e) =>
            {
                EditBucketList(panel1, title);
            };
            contextMenuStrip.Items.Add(editMenuItem);

            Panel panel2 = new Panel();
            panel2.Size = new Size(300, 250);
            panel2.Location = new Point(10, 11);
            panel1.Controls.Add(panel2);

            panel2.BackColor = color;

            Label label = new Label();
            label.Size = new Size(290, 141);
            label.Font = new Font("Nirmala UI", 27.75f, FontStyle.Bold);
            label.ForeColor = Color.White;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Dock = DockStyle.Top;
            label.Text = title;
            panel2.Controls.Add(label);

            Guna2Button guna2Button = new Guna2Button();
            guna2Button.Location = new Point(92, 165);
            guna2Button.Size = new Size(115, 45);
            guna2Button.AutoRoundedCorners = true;
            guna2Button.ForeColor = color;
            guna2Button.FillColor = Color.White;
            guna2Button.Text = "Open Form";
            guna2Button.Click += (s, ev) =>
            {
                CreateNewForm(title, color);
            };
            panel2.Controls.Add(guna2Button);
        }
        private void createList_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog.Color;

                string labelText = Interaction.InputBox("Enter text for the label:", "Label Text Input", "Your Text Here");

                if (TitleExists(labelText))
                {
                    MessageBox.Show("Title already exists. Please choose a different title.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO bucketList (title, color, userID) VALUES (@title, @color, @userID)";
                    using (OleDbCommand command = new OleDbCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@title", labelText);
                        command.Parameters.AddWithValue("@color", selectedColor.ToArgb());
                        command.Parameters.AddWithValue("@userID", userID);
                        command.ExecuteNonQuery();
                    }
                }
                AddBucketListToUI(labelText, selectedColor);
            }
        }

        private bool TitleExists(string title)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT COUNT(*) FROM bucketList WHERE title = @title AND userID = @userID";
                using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@userID", userID);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void CreateNewForm(string labelText, Color formColor)
        {
            Form form = new Form();
            form.Text = labelText;
            form.Size = new Size(550, 600);
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            form.AutoScroll = true;

            TextBox note = new TextBox();
            note.Location = new Point(52, 12);
            note.Size = new Size(432, 36);
            note.Font = new Font("Nirmala UI", 11.25f);
            note.AutoSize = false;
            form.Controls.Add(note);

            PictureBox setting = new PictureBox();
            setting.Size = new Size(30, 30);
            setting.Location = new Point(490, 18);
            setting.Image = Image.FromFile(@"C:\Users\Schooby\Documents\Programming\ver 8\midterm\Resources\bearing1.png");
            setting.SizeMode = PictureBoxSizeMode.Zoom;

            form.Controls.Add(setting);

            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Location = new Point(15, 67);
            flowLayoutPanel.Size = new Size(505, 482);
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.BorderStyle = BorderStyle.Fixed3D;
            form.Controls.Add(flowLayoutPanel);

            LoadCheckboxesFromDatabase(userID, labelText, flowLayoutPanel, formColor);
            PictureBox pictureBox = new PictureBox();
            pictureBox.Location = new Point(14, 16);
            pictureBox.Size = new Size(25, 25);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Image = Image.FromFile(@"C:\Users\Schooby\Downloads\icons\add.png");

            pictureBox.Click += (sender, e) =>
            {
                string noteText = note.Text.Trim();

                if (!string.IsNullOrWhiteSpace(noteText))
                {
                    Guna.UI2.WinForms.Guna2CheckBox checkBox = new Guna.UI2.WinForms.Guna2CheckBox();
                    checkBox.AutoSize = false;
                    checkBox.Size = new Size(491, 24);
                    checkBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    checkBox.TextAlign = ContentAlignment.MiddleCenter;
                    checkBox.Font = new Font("Nirmala UI", 11.25f);
                    checkBox.Checked = false;
                    checkBox.Text = noteText;

                    checkBox.CheckedState.BorderColor = formColor;
                    checkBox.CheckedState.FillColor = formColor;
                    checkBox.CheckMarkColor = Color.Transparent;
                    checkBox.UncheckedState.BorderColor = formColor;
                    checkBox.UncheckedState.BorderRadius = 2;
                    checkBox.UncheckedState.BorderThickness = 2;
                    checkBox.UncheckedState.FillColor = Color.Transparent;
                    flowLayoutPanel.Controls.Add(checkBox);

                    SaveCheckboxToDatabase(labelText, noteText, checkBox.Checked ? "yes" : "no");

                    note.Clear();
                }
                else
                {
                    MessageBox.Show("Please enter text in the note field.", "Note is empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            ComboBox comboBox = new ComboBox();
            comboBox.Items.AddRange(new object[] { "View checked status", "View unchecked status" });
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Size = new Size(179, 28); 
            comboBox.Location = new Point(341, 18);
            comboBox.Visible = false;
            comboBox.Font = new Font("Nirmala UI", 10f);

            comboBox.SelectedIndexChanged += (sender, e) =>
            {
                string selectedItem = comboBox.SelectedItem.ToString();
                if (selectedItem == "View checked status")
                {
                    LoadCheckboxesWithStatus(userID, labelText, flowLayoutPanel, formColor, true);
                }
                else if (selectedItem == "View unchecked status")
                {
                    LoadCheckboxesWithStatus(userID, labelText, flowLayoutPanel, formColor, false);
                }
            };

            setting.Click += (sender, e) =>
            {
                comboBox.DroppedDown = true;
            };


            form.Controls.Add(comboBox); 
            form.Controls.Add(pictureBox);
            form.ShowDialog();
        }

        private void LoadCheckboxesWithStatus(int userID, string title, FlowLayoutPanel flowLayoutPanel, Color formColor, bool isChecked)
        {
            flowLayoutPanel.Controls.Clear(); 

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT id, description FROM bucketList_Description WHERE userID = @userID AND title = @title AND status = @status";
                using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@userID", userID);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@status", isChecked);
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader["id"];
                            string description = reader["description"].ToString();

                            Guna.UI2.WinForms.Guna2CheckBox checkBox = new Guna.UI2.WinForms.Guna2CheckBox();
                            checkBox.AutoSize = false;
                            checkBox.Size = new Size(491, 24);
                            checkBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                            checkBox.TextAlign = ContentAlignment.MiddleCenter;
                            checkBox.Checked = isChecked;
                            checkBox.Text = description;
                            checkBox.Tag = id; 

                            checkBox.CheckedChanged += (s, e) =>
                            {
                                UpdateCheckboxStatus(userID, (int)checkBox.Tag, checkBox.Checked);
                            };
                            checkBox.Font = new Font("Nirmala UI", 11.25f);
                            checkBox.CheckedState.BorderColor = formColor;
                            checkBox.CheckedState.FillColor = formColor;
                            checkBox.CheckMarkColor = Color.Transparent;
                            checkBox.UncheckedState.BorderColor = formColor;
                            checkBox.UncheckedState.BorderRadius = 2;
                            checkBox.UncheckedState.BorderThickness = 2;
                            checkBox.UncheckedState.FillColor = Color.Transparent;
                            flowLayoutPanel.Controls.Add(checkBox);
                        }
                    }
                }
            }
        }

        private void LoadCheckboxesFromDatabase(int userID, string title, FlowLayoutPanel flowLayoutPanel, Color formColor)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT id, description, status FROM bucketList_Description WHERE userID = @userID AND title = @title";
                using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@userID", userID);
                    command.Parameters.AddWithValue("@title", title);
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader["id"];
                            string description = reader["description"].ToString();
                            bool status = (bool)reader["status"];

                            Guna.UI2.WinForms.Guna2CheckBox checkBox = new Guna.UI2.WinForms.Guna2CheckBox();
                            checkBox.Font  = new Font("Nirmala UI", 11.25f);
                            checkBox.AutoSize = false;
                            checkBox.Size = new Size(491, 24);
                            checkBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                            checkBox.TextAlign = ContentAlignment.MiddleCenter;
                            checkBox.Checked = status;
                            checkBox.Text = description;
                            checkBox.Tag = id;

                            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                            ToolStripMenuItem editMenuItem = new ToolStripMenuItem("Edit");
                            editMenuItem.Click += (sender, e) =>
                            {
                                EditCheckboxDescription(checkBox, userID, title);
                            };
                            contextMenuStrip.Items.Add(editMenuItem);

                            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Delete");
                            deleteMenuItem.Click += (sender, e) =>
                            {
                                DeleteCheckbox(checkBox, userID);
                            };
                            contextMenuStrip.Items.Add(deleteMenuItem);

                            checkBox.ContextMenuStrip = contextMenuStrip;

                            checkBox.CheckedChanged += (s, e) =>
                            {
                                UpdateCheckboxStatus(userID, (int)checkBox.Tag, checkBox.Checked);
                            };

                            checkBox.CheckedState.BorderColor = formColor;
                            checkBox.CheckedState.FillColor = formColor;
                            checkBox.CheckMarkColor = Color.Transparent;
                            checkBox.UncheckedState.BorderColor = formColor;
                            checkBox.UncheckedState.BorderRadius = 2;
                            checkBox.UncheckedState.BorderThickness = 2;
                            checkBox.UncheckedState.FillColor = Color.Transparent;
                            flowLayoutPanel.Controls.Add(checkBox);
                        }
                    }
                }
            }
        }

        private void DeleteCheckbox(Guna.UI2.WinForms.Guna2CheckBox checkBox, int userID)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this checkbox?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)checkBox.Parent;
                flowLayoutPanel.Controls.Remove(checkBox);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM bucketList_Description WHERE id = @id AND userID = @userID";
                    using (OleDbCommand command = new OleDbCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", (int)checkBox.Tag);
                        command.Parameters.AddWithValue("@userID", userID);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void EditCheckboxDescription(Guna.UI2.WinForms.Guna2CheckBox checkBox, int userID, string title)
        {
            string newDescription = Interaction.InputBox("Enter new description:", "Edit Checkbox Description", checkBox.Text);

            if (!string.IsNullOrWhiteSpace(newDescription))
            {
                checkBox.Text = newDescription;

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE bucketList_Description SET description = @description WHERE userID = @userID AND id = @checkboxID";
                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@description", newDescription);
                        command.Parameters.AddWithValue("@userID", userID);
                        command.Parameters.AddWithValue("@checkboxID", checkBox.Tag);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        private void UpdateCheckboxStatus(int userID, int checkboxID, bool isChecked)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE bucketList_Description SET status = @status WHERE userID = @userID AND id = @checkboxID";
                using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@status", isChecked);
                    command.Parameters.AddWithValue("@userID", userID);
                    command.Parameters.AddWithValue("@checkboxID", checkboxID);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void SaveCheckboxToDatabase(string title, string description, string status)
        {
            bool statusBool = status.ToLower() == "yes";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO bucketList_Description (userID, title, description, status, dateMade) VALUES (@userID, @title, @description, @status, @dateMade)";
                using (OleDbCommand command = new OleDbCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@userID", userID);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@status", statusBool);
                    command.Parameters.Add("@dateMade", OleDbType.Date).Value = DateTime.Now;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
