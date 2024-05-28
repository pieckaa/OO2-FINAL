namespace midterm
{
    partial class formBucketlist
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
            this.label1 = new System.Windows.Forms.Label();
            this.createList = new Guna.UI2.WinForms.Guna2Button();
            this.holderFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(745, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 130);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your\r\nBucketList\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // createList
            // 
            this.createList.AutoRoundedCorners = true;
            this.createList.BorderRadius = 15;
            this.createList.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.createList.BorderThickness = 2;
            this.createList.DefaultAutoSize = true;
            this.createList.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.createList.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.createList.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.createList.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.createList.FillColor = System.Drawing.Color.Transparent;
            this.createList.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createList.ForeColor = System.Drawing.Color.Black;
            this.createList.Location = new System.Drawing.Point(767, 167);
            this.createList.Name = "createList";
            this.createList.Size = new System.Drawing.Size(216, 33);
            this.createList.TabIndex = 4;
            this.createList.Text = "CREATE NEW BUCKETLIST";
            this.createList.Click += new System.EventHandler(this.createList_Click);
            // 
            // holderFlowLayout
            // 
            this.holderFlowLayout.AutoScroll = true;
            this.holderFlowLayout.Location = new System.Drawing.Point(60, 244);
            this.holderFlowLayout.Name = "holderFlowLayout";
            this.holderFlowLayout.Size = new System.Drawing.Size(1631, 682);
            this.holderFlowLayout.TabIndex = 5;
            // 
            // formBucketlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(202)))), ((int)(((byte)(196)))));
            this.ClientSize = new System.Drawing.Size(1751, 938);
            this.Controls.Add(this.holderFlowLayout);
            this.Controls.Add(this.createList);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formBucketlist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bucketlist";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button createList;
        private System.Windows.Forms.FlowLayoutPanel holderFlowLayout;
    }
}