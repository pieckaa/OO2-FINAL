using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace OOP2
{
    internal class RoundCornerTextBox : Control
    {
        private char passwordChar = '\0'; // Default no password character
        private string text = string.Empty;
        private int cornerRadius = 10;

        public RoundCornerTextBox()
        {
            this.BackColor = Color.White;
            this.Padding = new Padding(5);
            this.AutoSize = false;
            this.Size = new Size(150, 25); // Adjust size as needed
        }

        public char PasswordChar
        {
            get { return passwordChar; }
            set
            {
                passwordChar = value;
                this.Refresh();
            }
        }

        public override string Text
        {
            get { return text; }
            set
            {
                text = value;
                this.Refresh();
            }
        }

        public int CornerRadius
        {
            get { return cornerRadius; }
            set
            {
                cornerRadius = value;
                this.Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw rounded rectangle
            using (var path = GetRoundRectanglePath(ClientRectangle, cornerRadius))
            using (var brush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillPath(brush, path);
                using (var pen = new Pen(this.ForeColor, 1.5f))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }

            // Draw text
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
            if (passwordChar == '\0')
            {
                TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, flags);
            }
            else
            {
                string passwordText = new string(passwordChar, this.Text.Length);
                TextRenderer.DrawText(e.Graphics, passwordText, this.Font, this.ClientRectangle, this.ForeColor, flags);
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Refresh();
        }

        private GraphicsPath GetRoundRectanglePath(Rectangle rectangle, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();

            // Top left corner
            path.AddArc(rectangle.Left, rectangle.Top, radius * 2, radius * 2, 180, 90);
            // Top edge
            path.AddLine(rectangle.Left + radius, rectangle.Top, rectangle.Right - radius, rectangle.Top);
            // Top right corner
            path.AddArc(rectangle.Right - radius * 2, rectangle.Top, radius * 2, radius * 2, 270, 90);
            // Right edge
            path.AddLine(rectangle.Right, rectangle.Top + radius, rectangle.Right, rectangle.Bottom - radius);
            // Bottom right corner
            path.AddArc(rectangle.Right - radius * 2, rectangle.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            // Bottom edge
            path.AddLine(rectangle.Right - radius, rectangle.Bottom, rectangle.Left + radius, rectangle.Bottom);
            // Bottom left corner
            path.AddArc(rectangle.Left, rectangle.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            // Left edge
            path.AddLine(rectangle.Left, rectangle.Bottom - radius, rectangle.Left, rectangle.Top + radius);

            path.CloseFigure();

            return path;
        }
    }
}
