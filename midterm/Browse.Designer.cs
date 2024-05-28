namespace midterm
{
    partial class Browse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Browse));
            this.Pictures = new System.Windows.Forms.GroupBox();
            this.searchBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.vietnamBtn = new OOP2.RoundCornerButton();
            this.vietnam = new OOP2.RoundCornerPictureBox();
            this.timorBtn = new OOP2.RoundCornerButton();
            this.timorLeste = new OOP2.RoundCornerPictureBox();
            this.thailandBtn = new OOP2.RoundCornerButton();
            this.thailand = new OOP2.RoundCornerPictureBox();
            this.singaporeBtn = new OOP2.RoundCornerButton();
            this.singapore = new OOP2.RoundCornerPictureBox();
            this.philippineBtn = new OOP2.RoundCornerButton();
            this.philippines = new OOP2.RoundCornerPictureBox();
            this.indonesiaBtn = new OOP2.RoundCornerButton();
            this.indonesia = new OOP2.RoundCornerPictureBox();
            this.cambodiaBtn = new OOP2.RoundCornerButton();
            this.cambodia = new OOP2.RoundCornerPictureBox();
            this.myanmarBtn = new OOP2.RoundCornerButton();
            this.myanmar = new OOP2.RoundCornerPictureBox();
            this.malaysiaBtn = new OOP2.RoundCornerButton();
            this.malaysia = new OOP2.RoundCornerPictureBox();
            this.laosBtn = new OOP2.RoundCornerButton();
            this.laos = new OOP2.RoundCornerPictureBox();
            this.bruneiBtn = new OOP2.RoundCornerButton();
            this.brunei = new OOP2.RoundCornerPictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Pictures.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vietnam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timorLeste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thailand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.singapore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.philippines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indonesia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cambodia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myanmar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.malaysia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brunei)).BeginInit();
            this.SuspendLayout();
            // 
            // Pictures
            // 
            this.Pictures.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Pictures.BackgroundImage")));
            this.Pictures.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Pictures.Controls.Add(this.searchBox);
            this.Pictures.Controls.Add(this.label1);
            this.Pictures.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pictures.Location = new System.Drawing.Point(0, 0);
            this.Pictures.Name = "Pictures";
            this.Pictures.Size = new System.Drawing.Size(1923, 940);
            this.Pictures.TabIndex = 0;
            this.Pictures.TabStop = false;
            // 
            // searchBox
            // 
            this.searchBox.AutoRoundedCorners = true;
            this.searchBox.BackColor = System.Drawing.Color.Transparent;
            this.searchBox.BorderRadius = 17;
            this.searchBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.searchBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.searchBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.searchBox.Font = new System.Drawing.Font("Nirmala UI", 11.25F);
            this.searchBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.searchBox.ItemHeight = 30;
            this.searchBox.Items.AddRange(new object[] {
            "Search a Country",
            "Brunei",
            "Cambodia",
            "Indonesia",
            "Laos",
            "Malaysia",
            "Myanmar ",
            "Philippines",
            "Singapore",
            "Thailand",
            "Timor-Leste",
            "Vietnam"});
            this.searchBox.Location = new System.Drawing.Point(665, 779);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(592, 36);
            this.searchBox.StartIndex = 1;
            this.searchBox.TabIndex = 51;
            this.searchBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.searchBox.SelectedIndexChanged += new System.EventHandler(this.searchBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(819, 711);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 37);
            this.label1.TabIndex = 49;
            this.label1.Text = "Visit a Country?";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(213)))), ((int)(((byte)(208)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.Pictures);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1923, 3000);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.vietnamBtn);
            this.panel2.Controls.Add(this.vietnam);
            this.panel2.Controls.Add(this.timorBtn);
            this.panel2.Controls.Add(this.timorLeste);
            this.panel2.Controls.Add(this.thailandBtn);
            this.panel2.Controls.Add(this.thailand);
            this.panel2.Controls.Add(this.singaporeBtn);
            this.panel2.Controls.Add(this.singapore);
            this.panel2.Controls.Add(this.philippineBtn);
            this.panel2.Controls.Add(this.philippines);
            this.panel2.Controls.Add(this.indonesiaBtn);
            this.panel2.Controls.Add(this.indonesia);
            this.panel2.Controls.Add(this.cambodiaBtn);
            this.panel2.Controls.Add(this.cambodia);
            this.panel2.Controls.Add(this.myanmarBtn);
            this.panel2.Controls.Add(this.myanmar);
            this.panel2.Controls.Add(this.malaysiaBtn);
            this.panel2.Controls.Add(this.malaysia);
            this.panel2.Controls.Add(this.laosBtn);
            this.panel2.Controls.Add(this.laos);
            this.panel2.Controls.Add(this.bruneiBtn);
            this.panel2.Controls.Add(this.brunei);
            this.panel2.Location = new System.Drawing.Point(274, 1007);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1280, 1758);
            this.panel2.TabIndex = 53;
            // 
            // vietnamBtn
            // 
            this.vietnamBtn.BackColor = System.Drawing.Color.LightGray;
            this.vietnamBtn.FlatAppearance.BorderSize = 0;
            this.vietnamBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vietnamBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.vietnamBtn.ForeColor = System.Drawing.Color.Black;
            this.vietnamBtn.Location = new System.Drawing.Point(573, 1698);
            this.vietnamBtn.Name = "vietnamBtn";
            this.vietnamBtn.Size = new System.Drawing.Size(143, 40);
            this.vietnamBtn.TabIndex = 120;
            this.vietnamBtn.Text = "Vietnam";
            this.vietnamBtn.UseVisualStyleBackColor = false;
            this.vietnamBtn.Click += new System.EventHandler(this.vietnamBtn_Click);
            // 
            // vietnam
            // 
            this.vietnam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.vietnam.Image = ((System.Drawing.Image)(resources.GetObject("vietnam.Image")));
            this.vietnam.Location = new System.Drawing.Point(470, 1383);
            this.vietnam.Name = "vietnam";
            this.vietnam.Size = new System.Drawing.Size(342, 342);
            this.vietnam.TabIndex = 119;
            this.vietnam.TabStop = false;
            // 
            // timorBtn
            // 
            this.timorBtn.BackColor = System.Drawing.Color.LightGray;
            this.timorBtn.FlatAppearance.BorderSize = 0;
            this.timorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timorBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.timorBtn.ForeColor = System.Drawing.Color.Black;
            this.timorBtn.Location = new System.Drawing.Point(108, 1698);
            this.timorBtn.Name = "timorBtn";
            this.timorBtn.Size = new System.Drawing.Size(143, 40);
            this.timorBtn.TabIndex = 118;
            this.timorBtn.Text = "Timor-Leste";
            this.timorBtn.UseVisualStyleBackColor = false;
            this.timorBtn.Click += new System.EventHandler(this.timorBtn_Click);
            // 
            // timorLeste
            // 
            this.timorLeste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.timorLeste.Image = ((System.Drawing.Image)(resources.GetObject("timorLeste.Image")));
            this.timorLeste.Location = new System.Drawing.Point(5, 1383);
            this.timorLeste.Name = "timorLeste";
            this.timorLeste.Size = new System.Drawing.Size(342, 342);
            this.timorLeste.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.timorLeste.TabIndex = 117;
            this.timorLeste.TabStop = false;
            // 
            // thailandBtn
            // 
            this.thailandBtn.BackColor = System.Drawing.Color.LightGray;
            this.thailandBtn.FlatAppearance.BorderSize = 0;
            this.thailandBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thailandBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.thailandBtn.ForeColor = System.Drawing.Color.Black;
            this.thailandBtn.Location = new System.Drawing.Point(1036, 1244);
            this.thailandBtn.Name = "thailandBtn";
            this.thailandBtn.Size = new System.Drawing.Size(143, 40);
            this.thailandBtn.TabIndex = 116;
            this.thailandBtn.Text = "Thailand";
            this.thailandBtn.UseVisualStyleBackColor = false;
            this.thailandBtn.Click += new System.EventHandler(this.thailandBtn_Click);
            // 
            // thailand
            // 
            this.thailand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.thailand.Image = ((System.Drawing.Image)(resources.GetObject("thailand.Image")));
            this.thailand.Location = new System.Drawing.Point(933, 929);
            this.thailand.Name = "thailand";
            this.thailand.Size = new System.Drawing.Size(342, 342);
            this.thailand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.thailand.TabIndex = 115;
            this.thailand.TabStop = false;
            // 
            // singaporeBtn
            // 
            this.singaporeBtn.BackColor = System.Drawing.Color.LightGray;
            this.singaporeBtn.FlatAppearance.BorderSize = 0;
            this.singaporeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.singaporeBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.singaporeBtn.ForeColor = System.Drawing.Color.Black;
            this.singaporeBtn.Location = new System.Drawing.Point(569, 1244);
            this.singaporeBtn.Name = "singaporeBtn";
            this.singaporeBtn.Size = new System.Drawing.Size(143, 40);
            this.singaporeBtn.TabIndex = 114;
            this.singaporeBtn.Text = "Singapore";
            this.singaporeBtn.UseVisualStyleBackColor = false;
            this.singaporeBtn.Click += new System.EventHandler(this.singaporeBtn_Click);
            // 
            // singapore
            // 
            this.singapore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.singapore.Image = ((System.Drawing.Image)(resources.GetObject("singapore.Image")));
            this.singapore.Location = new System.Drawing.Point(466, 929);
            this.singapore.Name = "singapore";
            this.singapore.Size = new System.Drawing.Size(342, 342);
            this.singapore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.singapore.TabIndex = 113;
            this.singapore.TabStop = false;
            // 
            // philippineBtn
            // 
            this.philippineBtn.BackColor = System.Drawing.Color.LightGray;
            this.philippineBtn.FlatAppearance.BorderSize = 0;
            this.philippineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.philippineBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.philippineBtn.ForeColor = System.Drawing.Color.Black;
            this.philippineBtn.Location = new System.Drawing.Point(104, 1244);
            this.philippineBtn.Name = "philippineBtn";
            this.philippineBtn.Size = new System.Drawing.Size(143, 40);
            this.philippineBtn.TabIndex = 112;
            this.philippineBtn.Text = "Philippines";
            this.philippineBtn.UseVisualStyleBackColor = false;
            this.philippineBtn.Click += new System.EventHandler(this.philippineBtn_Click);
            // 
            // philippines
            // 
            this.philippines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.philippines.Image = ((System.Drawing.Image)(resources.GetObject("philippines.Image")));
            this.philippines.Location = new System.Drawing.Point(1, 929);
            this.philippines.Name = "philippines";
            this.philippines.Size = new System.Drawing.Size(342, 342);
            this.philippines.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.philippines.TabIndex = 111;
            this.philippines.TabStop = false;
            // 
            // indonesiaBtn
            // 
            this.indonesiaBtn.BackColor = System.Drawing.Color.LightGray;
            this.indonesiaBtn.FlatAppearance.BorderSize = 0;
            this.indonesiaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.indonesiaBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.indonesiaBtn.ForeColor = System.Drawing.Color.Black;
            this.indonesiaBtn.Location = new System.Drawing.Point(1040, 335);
            this.indonesiaBtn.Name = "indonesiaBtn";
            this.indonesiaBtn.Size = new System.Drawing.Size(143, 40);
            this.indonesiaBtn.TabIndex = 110;
            this.indonesiaBtn.Text = "Indonesia";
            this.indonesiaBtn.UseVisualStyleBackColor = false;
            this.indonesiaBtn.Click += new System.EventHandler(this.indonesiaBtn_Click);
            // 
            // indonesia
            // 
            this.indonesia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.indonesia.Image = ((System.Drawing.Image)(resources.GetObject("indonesia.Image")));
            this.indonesia.Location = new System.Drawing.Point(937, 20);
            this.indonesia.Name = "indonesia";
            this.indonesia.Size = new System.Drawing.Size(342, 343);
            this.indonesia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.indonesia.TabIndex = 109;
            this.indonesia.TabStop = false;
            // 
            // cambodiaBtn
            // 
            this.cambodiaBtn.BackColor = System.Drawing.Color.LightGray;
            this.cambodiaBtn.FlatAppearance.BorderSize = 0;
            this.cambodiaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cambodiaBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.cambodiaBtn.ForeColor = System.Drawing.Color.Black;
            this.cambodiaBtn.Location = new System.Drawing.Point(573, 336);
            this.cambodiaBtn.Name = "cambodiaBtn";
            this.cambodiaBtn.Size = new System.Drawing.Size(143, 40);
            this.cambodiaBtn.TabIndex = 108;
            this.cambodiaBtn.Text = "Cambodia";
            this.cambodiaBtn.UseVisualStyleBackColor = false;
            this.cambodiaBtn.Click += new System.EventHandler(this.cambodiaBtn_Click);
            // 
            // cambodia
            // 
            this.cambodia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cambodia.Image = ((System.Drawing.Image)(resources.GetObject("cambodia.Image")));
            this.cambodia.Location = new System.Drawing.Point(470, 21);
            this.cambodia.Name = "cambodia";
            this.cambodia.Size = new System.Drawing.Size(342, 342);
            this.cambodia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cambodia.TabIndex = 107;
            this.cambodia.TabStop = false;
            // 
            // myanmarBtn
            // 
            this.myanmarBtn.BackColor = System.Drawing.Color.LightGray;
            this.myanmarBtn.FlatAppearance.BorderSize = 0;
            this.myanmarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myanmarBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.myanmarBtn.ForeColor = System.Drawing.Color.Black;
            this.myanmarBtn.Location = new System.Drawing.Point(1040, 790);
            this.myanmarBtn.Name = "myanmarBtn";
            this.myanmarBtn.Size = new System.Drawing.Size(143, 40);
            this.myanmarBtn.TabIndex = 106;
            this.myanmarBtn.Text = "Myanmar";
            this.myanmarBtn.UseVisualStyleBackColor = false;
            this.myanmarBtn.Click += new System.EventHandler(this.myanmarBtn_Click);
            // 
            // myanmar
            // 
            this.myanmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.myanmar.Image = ((System.Drawing.Image)(resources.GetObject("myanmar.Image")));
            this.myanmar.Location = new System.Drawing.Point(937, 475);
            this.myanmar.Name = "myanmar";
            this.myanmar.Size = new System.Drawing.Size(342, 342);
            this.myanmar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.myanmar.TabIndex = 105;
            this.myanmar.TabStop = false;
            // 
            // malaysiaBtn
            // 
            this.malaysiaBtn.BackColor = System.Drawing.Color.LightGray;
            this.malaysiaBtn.FlatAppearance.BorderSize = 0;
            this.malaysiaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.malaysiaBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.malaysiaBtn.ForeColor = System.Drawing.Color.Black;
            this.malaysiaBtn.Location = new System.Drawing.Point(573, 790);
            this.malaysiaBtn.Name = "malaysiaBtn";
            this.malaysiaBtn.Size = new System.Drawing.Size(143, 40);
            this.malaysiaBtn.TabIndex = 104;
            this.malaysiaBtn.Text = "Malaysia";
            this.malaysiaBtn.UseVisualStyleBackColor = false;
            this.malaysiaBtn.Click += new System.EventHandler(this.malaysiaBtn_Click);
            // 
            // malaysia
            // 
            this.malaysia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.malaysia.Image = ((System.Drawing.Image)(resources.GetObject("malaysia.Image")));
            this.malaysia.Location = new System.Drawing.Point(470, 475);
            this.malaysia.Name = "malaysia";
            this.malaysia.Size = new System.Drawing.Size(342, 342);
            this.malaysia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.malaysia.TabIndex = 103;
            this.malaysia.TabStop = false;
            // 
            // laosBtn
            // 
            this.laosBtn.BackColor = System.Drawing.Color.LightGray;
            this.laosBtn.FlatAppearance.BorderSize = 0;
            this.laosBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.laosBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.laosBtn.ForeColor = System.Drawing.Color.Black;
            this.laosBtn.Location = new System.Drawing.Point(108, 790);
            this.laosBtn.Name = "laosBtn";
            this.laosBtn.Size = new System.Drawing.Size(143, 40);
            this.laosBtn.TabIndex = 102;
            this.laosBtn.Text = "Laos";
            this.laosBtn.UseVisualStyleBackColor = false;
            this.laosBtn.Click += new System.EventHandler(this.laosBtn_Click);
            // 
            // laos
            // 
            this.laos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.laos.Image = ((System.Drawing.Image)(resources.GetObject("laos.Image")));
            this.laos.Location = new System.Drawing.Point(5, 475);
            this.laos.Name = "laos";
            this.laos.Size = new System.Drawing.Size(342, 342);
            this.laos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.laos.TabIndex = 101;
            this.laos.TabStop = false;
            // 
            // bruneiBtn
            // 
            this.bruneiBtn.BackColor = System.Drawing.Color.LightGray;
            this.bruneiBtn.FlatAppearance.BorderSize = 0;
            this.bruneiBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bruneiBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.bruneiBtn.ForeColor = System.Drawing.Color.Black;
            this.bruneiBtn.Location = new System.Drawing.Point(104, 336);
            this.bruneiBtn.Name = "bruneiBtn";
            this.bruneiBtn.Size = new System.Drawing.Size(143, 40);
            this.bruneiBtn.TabIndex = 100;
            this.bruneiBtn.Text = "Brunei";
            this.bruneiBtn.UseVisualStyleBackColor = false;
            this.bruneiBtn.Click += new System.EventHandler(this.bruneiBtn_Click);
            // 
            // brunei
            // 
            this.brunei.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.brunei.Image = ((System.Drawing.Image)(resources.GetObject("brunei.Image")));
            this.brunei.Location = new System.Drawing.Point(1, 21);
            this.brunei.Name = "brunei";
            this.brunei.Size = new System.Drawing.Size(342, 342);
            this.brunei.TabIndex = 99;
            this.brunei.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Browse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1940, 1038);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Browse";
            this.Text = "Browse";
            this.Load += new System.EventHandler(this.Browse_Load_2);
            this.Pictures.ResumeLayout(false);
            this.Pictures.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vietnam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timorLeste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thailand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.singapore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.philippines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indonesia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cambodia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myanmar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.malaysia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brunei)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Pictures;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private OOP2.RoundCornerButton vietnamBtn;
        private OOP2.RoundCornerPictureBox vietnam;
        private OOP2.RoundCornerButton timorBtn;
        private OOP2.RoundCornerPictureBox timorLeste;
        private OOP2.RoundCornerButton thailandBtn;
        private OOP2.RoundCornerPictureBox thailand;
        private OOP2.RoundCornerButton singaporeBtn;
        private OOP2.RoundCornerPictureBox singapore;
        private OOP2.RoundCornerButton philippineBtn;
        private OOP2.RoundCornerPictureBox philippines;
        private OOP2.RoundCornerButton indonesiaBtn;
        private OOP2.RoundCornerPictureBox indonesia;
        private OOP2.RoundCornerPictureBox brunei;
        private System.Windows.Forms.Timer timer1;
        private OOP2.RoundCornerButton cambodiaBtn;
        private OOP2.RoundCornerPictureBox cambodia;
        private OOP2.RoundCornerButton myanmarBtn;
        private OOP2.RoundCornerPictureBox myanmar;
        private OOP2.RoundCornerButton malaysiaBtn;
        private OOP2.RoundCornerPictureBox malaysia;
        private OOP2.RoundCornerButton laosBtn;
        private OOP2.RoundCornerPictureBox laos;
        private OOP2.RoundCornerButton bruneiBtn;
        private Guna.UI2.WinForms.Guna2ComboBox searchBox;
    }
}