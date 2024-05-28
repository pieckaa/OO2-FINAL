namespace midterm
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.sidebarTransistion = new System.Windows.Forms.Timer(this.components);
            this.pnlList = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlBrowse = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.x = new System.Windows.Forms.Button();
            this.nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlAccount = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlLogout = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.bigPanel = new System.Windows.Forms.Panel();
            this.pfpBox = new OOP2.RoundPictureBox();
            this.pnlList.SuspendLayout();
            this.pnlBrowse.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlAccount.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.pnlLogout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pfpBox)).BeginInit();
            this.SuspendLayout();
            // 
            // sidebarTransistion
            // 
            this.sidebarTransistion.Interval = 10;
            this.sidebarTransistion.Tick += new System.EventHandler(this.sidebarTransistion_Tick);
            // 
            // pnlList
            // 
            this.pnlList.BackColor = System.Drawing.Color.SaddleBrown;
            this.pnlList.Controls.Add(this.button2);
            this.pnlList.ForeColor = System.Drawing.Color.Black;
            this.pnlList.Location = new System.Drawing.Point(3, 55);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(197, 46);
            this.pnlList.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(-11, -9);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(222, 64);
            this.button2.TabIndex = 9;
            this.button2.Text = "List";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pnlBrowse
            // 
            this.pnlBrowse.BackColor = System.Drawing.Color.SaddleBrown;
            this.pnlBrowse.Controls.Add(this.button1);
            this.pnlBrowse.ForeColor = System.Drawing.Color.Black;
            this.pnlBrowse.Location = new System.Drawing.Point(3, 3);
            this.pnlBrowse.Name = "pnlBrowse";
            this.pnlBrowse.Size = new System.Drawing.Size(197, 46);
            this.pnlBrowse.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(-11, -9);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(222, 64);
            this.button1.TabIndex = 9;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.SaddleBrown;
            this.pnlMenu.Controls.Add(this.x);
            this.pnlMenu.ForeColor = System.Drawing.Color.Black;
            this.pnlMenu.Location = new System.Drawing.Point(3, 107);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(197, 46);
            this.pnlMenu.TabIndex = 7;
            // 
            // x
            // 
            this.x.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.x.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.x.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.x.Image = ((System.Drawing.Image)(resources.GetObject("x.Image")));
            this.x.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.x.Location = new System.Drawing.Point(-14, -9);
            this.x.Name = "x";
            this.x.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.x.Size = new System.Drawing.Size(222, 64);
            this.x.TabIndex = 9;
            this.x.Text = "Feedback";
            this.x.UseVisualStyleBackColor = false;
            this.x.Click += new System.EventHandler(this.MENU_Click);
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
            this.nightControlBox1.EnableCloseColor = System.Drawing.Color.Red;
            this.nightControlBox1.EnableMaximizeButton = true;
            this.nightControlBox1.EnableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.nightControlBox1.EnableMinimizeButton = true;
            this.nightControlBox1.EnableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
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
            this.panel1.Size = new System.Drawing.Size(1851, 47);
            this.panel1.TabIndex = 4;
            // 
            // pnlAccount
            // 
            this.pnlAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.pnlAccount.Controls.Add(this.pfpBox);
            this.pnlAccount.Controls.Add(this.label1);
            this.pnlAccount.ForeColor = System.Drawing.Color.Black;
            this.pnlAccount.Location = new System.Drawing.Point(3, 871);
            this.pnlAccount.Name = "pnlAccount";
            this.pnlAccount.Size = new System.Drawing.Size(197, 125);
            this.pnlAccount.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.label1.Location = new System.Drawing.Point(64, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "username";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.sidebar.Controls.Add(this.pnlBrowse);
            this.sidebar.Controls.Add(this.pnlList);
            this.sidebar.Controls.Add(this.pnlMenu);
            this.sidebar.Controls.Add(this.pnlLogout);
            this.sidebar.Controls.Add(this.bigPanel);
            this.sidebar.Controls.Add(this.pnlAccount);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 47);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(200, 991);
            this.sidebar.TabIndex = 6;
            this.sidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.sidebar_Paint);
            // 
            // pnlLogout
            // 
            this.pnlLogout.BackColor = System.Drawing.Color.SaddleBrown;
            this.pnlLogout.Controls.Add(this.button4);
            this.pnlLogout.ForeColor = System.Drawing.Color.Black;
            this.pnlLogout.Location = new System.Drawing.Point(3, 159);
            this.pnlLogout.Name = "pnlLogout";
            this.pnlLogout.Size = new System.Drawing.Size(197, 46);
            this.pnlLogout.TabIndex = 16;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(-11, -9);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.button4.Size = new System.Drawing.Size(227, 64);
            this.button4.TabIndex = 9;
            this.button4.Text = "Logout";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // bigPanel
            // 
            this.bigPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bigPanel.BackColor = System.Drawing.Color.Transparent;
            this.bigPanel.ForeColor = System.Drawing.Color.Black;
            this.bigPanel.Location = new System.Drawing.Point(3, 211);
            this.bigPanel.Name = "bigPanel";
            this.bigPanel.Size = new System.Drawing.Size(197, 654);
            this.bigPanel.TabIndex = 13;
            // 
            // pfpBox
            // 
            this.pfpBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pfpBox.Image = ((System.Drawing.Image)(resources.GetObject("pfpBox.Image")));
            this.pfpBox.Location = new System.Drawing.Point(7, 37);
            this.pfpBox.Name = "pfpBox";
            this.pfpBox.Size = new System.Drawing.Size(50, 50);
            this.pfpBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pfpBox.TabIndex = 9;
            this.pfpBox.TabStop = false;
            this.pfpBox.Click += new System.EventHandler(this.pfpBox_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.ClientSize = new System.Drawing.Size(1851, 1038);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mainManu";
            this.pnlList.ResumeLayout(false);
            this.pnlBrowse.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlAccount.ResumeLayout(false);
            this.pnlAccount.PerformLayout();
            this.sidebar.ResumeLayout(false);
            this.pnlLogout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pfpBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer sidebarTransistion;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnlBrowse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button x;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlAccount;
        private OOP2.RoundPictureBox pfpBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel pnlLogout;
        private System.Windows.Forms.Panel bigPanel;
    }
}