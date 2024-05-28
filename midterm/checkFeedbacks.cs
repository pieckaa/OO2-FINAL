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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

    namespace OOP2
    {
        public partial class checkFeedbacks : Form
        {
            private OleDbConnection connection;
            private const string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Schooby\Documents\data.mdb";

            public checkFeedbacks()
            {
                InitializeComponent();
                LoadData();
                dataGrid.SelectionChanged += DataGrid_SelectionChanged;
            }

        private void LoadData()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT r.reportID, u.username, r.userID, r.title, r.description, r.picture, r.reportDate, r.status FROM report r INNER JOIN users u ON r.userID = u.userID";

                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGrid.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void DataGrid_SelectionChanged(object sender, EventArgs e)
            {
                if (dataGrid.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGrid.SelectedRows[0];

                    string title = selectedRow.Cells["title"].Value.ToString();
                    string username = selectedRow.Cells["username"].Value.ToString();
                    string description = selectedRow.Cells["description"].Value.ToString();
                    byte[] pictureBytes = (byte[])selectedRow.Cells["picture"].Value;
                    DateTime reportDate = Convert.ToDateTime(selectedRow.Cells["reportDate"].Value);

                    namelabel.Text = username;
                    titleTxt.Text = title;
                    descriptiontxt.Text = description;
                    pictureBox.Image = byteArrayToImage(pictureBytes);
                    timeLabel.Text = reportDate.ToString("MM-dd-yyyy HH:mm:ss");
                }
            }

            private Image byteArrayToImage(byte[] byteArrayIn)
            {
                Image returnImage = null;
                if (byteArrayIn != null)
                {
                    using (MemoryStream ms = new MemoryStream(byteArrayIn))
                    {
                        returnImage = Image.FromStream(ms);
                    }
                }
                return returnImage;
            }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count > 0)
            {
                int rowIndex = dataGrid.SelectedRows[0].Index;

                int reportID = Convert.ToInt32(dataGrid.Rows[rowIndex].Cells["reportID"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this feedback?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeleteFeedback(reportID);
                }
            }
        }

        private void DeleteFeedback(int reportID)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM report WHERE reportID = ?";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@reportID", reportID);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        dataGrid.Rows.RemoveAt(dataGrid.SelectedRows[0].Index);
                        namelabel.Text = "";
                        titleTxt.Text = "";
                        descriptiontxt.Text = "";
                        pictureBox.Image = null;
                        timeLabel.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("No rows were affected. ReportID may not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterReportsByStatus();
        }

        private void FilterReportsByStatus()
        {
            if (guna2ComboBox1.SelectedIndex == 1) 
            {
                ((DataTable)dataGrid.DataSource).DefaultView.RowFilter = "status = 'Bug'";
            }
            else if (guna2ComboBox1.SelectedIndex == 2)
            {
                ((DataTable)dataGrid.DataSource).DefaultView.RowFilter = "status = 'Suggestion'";
            }
            else
            {
                ((DataTable)dataGrid.DataSource).DefaultView.RowFilter = "";
            }
        }
    }
}
