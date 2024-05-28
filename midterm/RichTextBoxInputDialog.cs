using System;
using System.Windows.Forms;

namespace OOP2
{
    public partial class RichTextBoxInputDialog : Form
    {
        public string InputText { get; private set; }

        private RichTextBox richTextBoxInput;
        private Button btnOK;

        public RichTextBoxInputDialog()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            richTextBoxInput = new RichTextBox();
            btnOK = new Button();

            SuspendLayout();

            richTextBoxInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right; 
            richTextBoxInput.Location = new System.Drawing.Point(12, 12);
            richTextBoxInput.Name = "richTextBoxInput";
            richTextBoxInput.Size = new System.Drawing.Size(800, 400);
            richTextBoxInput.TabIndex = 0;
            Controls.Add(richTextBoxInput);

            btnOK.Anchor = AnchorStyles.Bottom;
            btnOK.Location = new System.Drawing.Point(365, 428);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(75, 23);
            btnOK.TabIndex = 1;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += new EventHandler(btnOK_Click);
            Controls.Add(btnOK);

            ClientSize = new System.Drawing.Size(820, 463);
            Name = "RichTextBoxInputDialog";
            Text = "Enter your comment";

            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            ResumeLayout(false);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            InputText = richTextBoxInput.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
