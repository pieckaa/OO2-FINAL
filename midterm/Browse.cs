using Microsoft.VisualBasic.ApplicationServices;
using OOP2;
using ReaLTaiizor.Controls;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace midterm
{
    public partial class Browse : Form
    {
        private int userID;
        private string[] imageFiles; 
        private int currentIndex = 1;


        public Browse(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            ModifyAdminBtnVisibility();
            searchBox.SelectedIndex = 0;
            searchBox.SelectedIndexChanged += searchBox_SelectedIndexChanged;
        }

        private void Browse_Load(object sender, EventArgs e)
        {
        }

        private void ModifyAdminBtnVisibility()
        {
        }

        private void Browse_Load_1(object sender, EventArgs e)
        {
            string folderPath = @"C:\Users\Schooby\Documents\browsepic";

            imageFiles = Directory.GetFiles(folderPath, "*.jpg")
                                   .Concat(Directory.GetFiles(folderPath, "*.png"))
                                   .ToArray();

            timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (imageFiles.Length > 0)
            {
                Pictures.BackgroundImage = Image.FromFile(imageFiles[currentIndex]);
                Pictures.BackgroundImageLayout = ImageLayout.Center;

                currentIndex = (currentIndex + 1) % imageFiles.Length;
            }
        }

        private void Browse_Load_2(object sender, EventArgs e)
        {
            string folderPath = @"C:\Users\Schooby\Documents\browsepic";

            imageFiles = Directory.GetFiles(folderPath, "*.jpg")
                                   .Concat(Directory.GetFiles(folderPath, "*.png"))
                                   .ToArray();

            timer1.Start();
        }

        private void bruneiBtn_Click(object sender, EventArgs e)
        {
            Brunei brunei = new Brunei(userID);
            brunei.Show();
        }

        private void search_Click(object sender, EventArgs e)
        {

        }

        private void cambodiaBtn_Click(object sender, EventArgs e)
        {
            Cambodia cambodia = new Cambodia(userID);
            cambodia.Show();
        }

        private void indonesiaBtn_Click(object sender, EventArgs e)
        {
            Indonesia indonesia = new Indonesia(userID);
            indonesia.Show();
        }

        private void laosBtn_Click(object sender, EventArgs e)
        {
            Laos laos = new Laos(userID);
            laos.Show();
        }

        private void malaysiaBtn_Click(object sender, EventArgs e)
        {
            Malaysia malaysia = new Malaysia(userID);
            malaysia.Show();
        }

        private void myanmarBtn_Click(object sender, EventArgs e)
        {
            Myanmar myanmar = new Myanmar(userID);
            myanmar.Show();
        }

        private void philippineBtn_Click(object sender, EventArgs e)
        {
            Philippines philippines = new Philippines(userID);
            philippines.Show();
        }

        private void singaporeBtn_Click(object sender, EventArgs e)
        {
            Singapore singapore = new Singapore(userID);
            singapore.Show();
        }

        private void thailandBtn_Click(object sender, EventArgs e)
        {
            Thailand thailand = new Thailand(userID);
            thailand.Show();
        }

        private void timorBtn_Click(object sender, EventArgs e)
        {
            TimorLeste timor = new TimorLeste(userID);
            timor.Show();
        }

        private void vietnamBtn_Click(object sender, EventArgs e)
        {
            Vietnam vietnam = new Vietnam(userID);
            vietnam.Show();
        }

        private void searchBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = searchBox.SelectedItem.ToString();

            switch (selectedOption)
            {
                case "Brunei":
                    Brunei brunei = new Brunei(userID);
                    brunei.Show();
                    break;
                case "Cambodia":
                    Cambodia cambodia = new Cambodia(userID);
                    cambodia.Show();
                    break;
                case "Indonesia":
                    Indonesia indonesia = new Indonesia(userID);
                    indonesia.Show();
                    break;
                case "Laos":
                    Laos laos = new Laos(userID);
                    laos.Show();
                    break;
                case "Malaysia":
                    Malaysia malaysia = new Malaysia(userID);
                    malaysia.Show();
                    break;
                case "Myanmar":
                    Myanmar myanmar = new Myanmar(userID);
                    myanmar.Show();
                    break;
                case "Philippines":
                    Philippines philippines = new Philippines(userID);
                    philippines.Show();
                    break;
                case "Singapore":
                    Singapore singapore = new Singapore(userID);
                    singapore.Show();
                    break;
                case "Thailand":
                    Thailand thailand = new Thailand(userID);
                    thailand.Show();
                    break;
                case "Timor-Leste":
                    TimorLeste timor = new TimorLeste(userID);
                    timor.Show();
                    break;
                case "Vietnam":
                    Vietnam vietnam = new Vietnam(userID);
                    vietnam.Show();
                    break;
                default:
                    break;
            }
        }
    }
}