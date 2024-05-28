namespace midterm
{
    partial class register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(register));
            this.label1 = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.Label();
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.compasswordTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.showpassChkbx = new System.Windows.Forms.CheckBox();
            this.registerTxt = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.clearPicBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.clearPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "REGISTER";
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Location = new System.Drawing.Point(74, 140);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(69, 17);
            this.user.TabIndex = 1;
            this.user.Text = "Username";
            // 
            // usernameTxt
            // 
            this.usernameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.usernameTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameTxt.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTxt.Location = new System.Drawing.Point(77, 160);
            this.usernameTxt.Multiline = true;
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(216, 24);
            this.usernameTxt.TabIndex = 2;
            // 
            // passwordTxt
            // 
            this.passwordTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.passwordTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTxt.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTxt.Location = new System.Drawing.Point(77, 213);
            this.passwordTxt.Multiline = true;
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.PasswordChar = '*';
            this.passwordTxt.Size = new System.Drawing.Size(216, 24);
            this.passwordTxt.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // compasswordTxt
            // 
            this.compasswordTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.compasswordTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compasswordTxt.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compasswordTxt.Location = new System.Drawing.Point(77, 266);
            this.compasswordTxt.Multiline = true;
            this.compasswordTxt.Name = "compasswordTxt";
            this.compasswordTxt.PasswordChar = '*';
            this.compasswordTxt.Size = new System.Drawing.Size(216, 24);
            this.compasswordTxt.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Confirm password";
            // 
            // showpassChkbx
            // 
            this.showpassChkbx.AutoSize = true;
            this.showpassChkbx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showpassChkbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showpassChkbx.Location = new System.Drawing.Point(171, 299);
            this.showpassChkbx.Name = "showpassChkbx";
            this.showpassChkbx.Size = new System.Drawing.Size(119, 21);
            this.showpassChkbx.TabIndex = 7;
            this.showpassChkbx.Text = "Show password";
            this.showpassChkbx.UseVisualStyleBackColor = true;
            this.showpassChkbx.CheckedChanged += new System.EventHandler(this.showpassChkbx_CheckedChanged);
            // 
            // registerTxt
            // 
            this.registerTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.registerTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registerTxt.FlatAppearance.BorderSize = 0;
            this.registerTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerTxt.ForeColor = System.Drawing.Color.White;
            this.registerTxt.Location = new System.Drawing.Point(75, 329);
            this.registerTxt.Name = "registerTxt";
            this.registerTxt.Size = new System.Drawing.Size(216, 35);
            this.registerTxt.TabIndex = 8;
            this.registerTxt.Text = "REGISTER";
            this.registerTxt.UseVisualStyleBackColor = false;
            this.registerTxt.Click += new System.EventHandler(this.registerTxt_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.BackColor = System.Drawing.Color.White;
            this.clearBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.clearBtn.Location = new System.Drawing.Point(74, 373);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(216, 35);
            this.clearBtn.TabIndex = 9;
            this.clearBtn.Text = "CLEAR";
            this.clearBtn.UseVisualStyleBackColor = false;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.label4.Location = new System.Drawing.Point(135, 423);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Back to LOGIN";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // clearPicBox
            // 
            this.clearPicBox.Image = ((System.Drawing.Image)(resources.GetObject("clearPicBox.Image")));
            this.clearPicBox.Location = new System.Drawing.Point(337, 4);
            this.clearPicBox.Name = "clearPicBox";
            this.clearPicBox.Size = new System.Drawing.Size(25, 25);
            this.clearPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.clearPicBox.TabIndex = 31;
            this.clearPicBox.TabStop = false;
            this.clearPicBox.Click += new System.EventHandler(this.clearPicBox_Click);
            // 
            // register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(366, 467);
            this.Controls.Add(this.clearPicBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.registerTxt);
            this.Controls.Add(this.showpassChkbx);
            this.Controls.Add(this.compasswordTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usernameTxt);
            this.Controls.Add(this.user);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.clearPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label user;
        private System.Windows.Forms.TextBox usernameTxt;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox compasswordTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox showpassChkbx;
        private System.Windows.Forms.Button registerTxt;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox clearPicBox;
    }
}

