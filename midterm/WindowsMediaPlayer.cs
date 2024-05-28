using System;
using System.Windows.Forms;

namespace OOP2
{
    internal class WindowsMediaPlayer
    {
        // Declare Windows Media Player control
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;

        public WindowsMediaPlayer()
        {
            InitializePlayer();
        }

        private void InitializePlayer()
        {
            // Create a new instance of the Windows Media Player control
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();

            // Set control properties
            axWindowsMediaPlayer1.Dock = DockStyle.Fill;

            // Add the control to the form
            Form form = new Form();
            form.Controls.Add(axWindowsMediaPlayer1);
            form.Load += Form_Load;
            Application.Run(form);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // Open file dialog to select a media file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media Files|*.mp3;*.mp4;*.wav;*.wmv;*.avi|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Load selected media file into the player
                axWindowsMediaPlayer1.URL = openFileDialog.FileName;
            }
        }

        public void Play()
        {
            // Start playback
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        public void Pause()
        {
            // Pause playback
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        public void Stop()
        {
            // Stop playback
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }
    }
}
