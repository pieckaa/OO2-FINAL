namespace midterm
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label4 = new System.Windows.Forms.Label();
            this.clearBtn = new System.Windows.Forms.Button();
            this.registerTxt = new System.Windows.Forms.Button();
            this.showpassChkbx = new System.Windows.Forms.CheckBox();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.Label();
            this.clearPicBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.clearPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(84, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 21);
            this.label4.TabIndex = 21;
            this.label4.Text = "Create an Account";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.BackColor = System.Drawing.Color.White;
            this.clearBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.clearBtn.Location = new System.Drawing.Point(47, 273);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(216, 35);
            this.clearBtn.TabIndex = 20;
            this.clearBtn.Text = "CLEAR";
            this.clearBtn.UseVisualStyleBackColor = false;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // registerTxt
            // 
            this.registerTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.registerTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registerTxt.FlatAppearance.BorderSize = 0;
            this.registerTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerTxt.ForeColor = System.Drawing.Color.White;
            this.registerTxt.Location = new System.Drawing.Point(47, 228);
            this.registerTxt.Name = "registerTxt";
            this.registerTxt.Size = new System.Drawing.Size(216, 35);
            this.registerTxt.TabIndex = 19;
            this.registerTxt.Text = "LOGIN";
            this.registerTxt.UseVisualStyleBackColor = false;
            this.registerTxt.Click += new System.EventHandler(this.registerTxt_Click);
            // 
            // showpassChkbx
            // 
            this.showpassChkbx.AutoSize = true;
            this.showpassChkbx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showpassChkbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showpassChkbx.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showpassChkbx.ForeColor = System.Drawing.Color.Gray;
            this.showpassChkbx.Location = new System.Drawing.Point(119, 193);
            this.showpassChkbx.Name = "showpassChkbx";
            this.showpassChkbx.Size = new System.Drawing.Size(144, 25);
            this.showpassChkbx.TabIndex = 18;
            this.showpassChkbx.Text = "Show password";
            this.showpassChkbx.UseVisualStyleBackColor = true;
            this.showpassChkbx.CheckedChanged += new System.EventHandler(this.showpassChkbx_CheckedChanged);
            // 
            // passwordTxt
            // 
            this.passwordTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.passwordTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTxt.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTxt.Location = new System.Drawing.Point(47, 159);
            this.passwordTxt.Multiline = true;
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.PasswordChar = '*';
            this.passwordTxt.Size = new System.Drawing.Size(216, 24);
            this.passwordTxt.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(44, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = "Password";
            // 
            // usernameTxt
            // 
            this.usernameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.usernameTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameTxt.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTxt.Location = new System.Drawing.Point(47, 94);
            this.usernameTxt.Multiline = true;
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(216, 24);
            this.usernameTxt.TabIndex = 13;
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.ForeColor = System.Drawing.Color.Gray;
            this.user.Location = new System.Drawing.Point(44, 63);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(87, 21);
            this.user.TabIndex = 12;
            this.user.Text = "Username";
            // 
            // clearPicBox
            // 
            this.clearPicBox.BackColor = System.Drawing.Color.Transparent;
            this.clearPicBox.Image = ((System.Drawing.Image)(resources.GetObject("clearPicBox.Image")));
            this.clearPicBox.Location = new System.Drawing.Point(280, 1);
            this.clearPicBox.Name = "clearPicBox";
            this.clearPicBox.Size = new System.Drawing.Size(25, 25);
            this.clearPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.clearPicBox.TabIndex = 32;
            this.clearPicBox.TabStop = false;
            this.clearPicBox.Click += new System.EventHandler(this.clearPicBox_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(307, 387);
            this.Controls.Add(this.clearPicBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.registerTxt);
            this.Controls.Add(this.showpassChkbx);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usernameTxt);
            this.Controls.Add(this.user);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.clearPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button registerTxt;
        private System.Windows.Forms.CheckBox showpassChkbx;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usernameTxt;
        private System.Windows.Forms.Label user;
        private System.Windows.Forms.PictureBox clearPicBox;
    }
}