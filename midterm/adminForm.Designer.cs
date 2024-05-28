namespace OOP2
{
    partial class adminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminForm));
            this.sidebarTransistion = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.x = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl3 = new System.Windows.Forms.Panel();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.pnl4 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.bigPanel = new System.Windows.Forms.Panel();
            this.pnlAccount = new System.Windows.Forms.Panel();
            this.pfpBox = new OOP2.RoundPictureBox();
            this.nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl1.SuspendLayout();
            this.pnl3.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.pnl4.SuspendLayout();
            this.pnlAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pfpBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebarTransistion
            // 
            this.sidebarTransistion.Interval = 10;
            this.sidebarTransistion.Tick += new System.EventHandler(this.sidebarTransistion_Tick_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(-6, -9);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(222, 64);
            this.button2.TabIndex = 9;
            this.button2.Text = "Feedbacks";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pnl1
            // 
            this.pnl1.BackColor = System.Drawing.Color.SaddleBrown;
            this.pnl1.Controls.Add(this.x);
            this.pnl1.ForeColor = System.Drawing.Color.Black;
            this.pnl1.Location = new System.Drawing.Point(3, 3);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(197, 55);
            this.pnl1.TabIndex = 7;
            // 
            // x
            // 
            this.x.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.x.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.x.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold);
            this.x.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.x.Image = ((System.Drawing.Image)(resources.GetObject("x.Image")));
            this.x.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.x.Location = new System.Drawing.Point(-6, -5);
            this.x.Name = "x";
            this.x.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.x.Size = new System.Drawing.Size(222, 64);
            this.x.TabIndex = 9;
            this.x.Text = "Add \r\nDestinations";
            this.x.UseVisualStyleBackColor = false;
            this.x.Click += new System.EventHandler(this.x_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(63, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "username";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnl3
            // 
            this.pnl3.BackColor = System.Drawing.Color.SaddleBrown;
            this.pnl3.Controls.Add(this.button2);
            this.pnl3.ForeColor = System.Drawing.Color.Black;
            this.pnl3.Location = new System.Drawing.Point(3, 64);
            this.pnl3.Name = "pnl3";
            this.pnl3.Size = new System.Drawing.Size(197, 46);
            this.pnl3.TabIndex = 10;
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.sidebar.Controls.Add(this.pnl1);
            this.sidebar.Controls.Add(this.pnl3);
            this.sidebar.Controls.Add(this.pnl4);
            this.sidebar.Controls.Add(this.bigPanel);
            this.sidebar.Controls.Add(this.pnlAccount);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.ForeColor = System.Drawing.Color.Black;
            this.sidebar.Location = new System.Drawing.Point(0, 38);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(200, 1000);
            this.sidebar.TabIndex = 8;
            // 
            // pnl4
            // 
            this.pnl4.BackColor = System.Drawing.Color.SaddleBrown;
            this.pnl4.Controls.Add(this.button3);
            this.pnl4.ForeColor = System.Drawing.Color.Black;
            this.pnl4.Location = new System.Drawing.Point(3, 116);
            this.pnl4.Name = "pnl4";
            this.pnl4.Size = new System.Drawing.Size(197, 46);
            this.pnl4.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(-6, -9);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(222, 64);
            this.button3.TabIndex = 10;
            this.button3.Text = "Logout";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // bigPanel
            // 
            this.bigPanel.BackColor = System.Drawing.Color.Transparent;
            this.bigPanel.ForeColor = System.Drawing.Color.Black;
            this.bigPanel.Location = new System.Drawing.Point(3, 168);
            this.bigPanel.Name = "bigPanel";
            this.bigPanel.Size = new System.Drawing.Size(197, 652);
            this.bigPanel.TabIndex = 13;
            // 
            // pnlAccount
            // 
            this.pnlAccount.BackColor = System.Drawing.Color.Transparent;
            this.pnlAccount.Controls.Add(this.pfpBox);
            this.pnlAccount.Controls.Add(this.label1);
            this.pnlAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.pnlAccount.Location = new System.Drawing.Point(3, 826);
            this.pnlAccount.Name = "pnlAccount";
            this.pnlAccount.Size = new System.Drawing.Size(197, 125);
            this.pnlAccount.TabIndex = 15;
            // 
            // pfpBox
            // 
            this.pfpBox.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pfpBox.ErrorImage")));
            this.pfpBox.Image = ((System.Drawing.Image)(resources.GetObject("pfpBox.Image")));
            this.pfpBox.Location = new System.Drawing.Point(9, 37);
            this.pfpBox.Name = "pfpBox";
            this.pfpBox.Size = new System.Drawing.Size(50, 50);
            this.pfpBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pfpBox.TabIndex = 9;
            this.pfpBox.TabStop = false;
            this.pfpBox.Click += new System.EventHandler(this.pfpBox_Click);
            // 
            // nightControlBox1
            // 
            this.nightControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nightControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.nightControlBox1.CloseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.nightControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nightControlBox1.DefaultLocation = true;
            this.nightControlBox1.DisableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.DisableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.EnableCloseColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMaximizeButton = true;
            this.nightControlBox1.EnableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMinimizeButton = true;
            this.nightControlBox1.EnableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.Location = new System.Drawing.Point(1712, 0);
            this.nightControlBox1.MaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MaximizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.MinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MinimizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Name = "nightControlBox1";
            this.nightControlBox1.Size = new System.Drawing.Size(139, 31);
            this.nightControlBox1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.panel1.Controls.Add(this.nightControlBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1851, 38);
            this.panel1.TabIndex = 7;
            // 
            // adminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1851, 1038);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "adminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "adminForm";
            this.pnl1.ResumeLayout(false);
            this.pnl3.ResumeLayout(false);
            this.sidebar.ResumeLayout(false);
            this.pnl4.ResumeLayout(false);
            this.pnlAccount.ResumeLayout(false);
            this.pnlAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pfpBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer sidebarTransistion;
        private RoundPictureBox pfpBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Button x;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl3;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel pnl4;
        private System.Windows.Forms.Panel bigPanel;
        private System.Windows.Forms.Panel pnlAccount;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
    }
}