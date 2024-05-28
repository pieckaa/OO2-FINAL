using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace OOP2
{
    internal class TransparentCornersGroupBox : GroupBox
    {
        public TransparentCornersGroupBox()
        {
            // Set the control to redraw when resized
            this.ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a rounded rectangle path
            GraphicsPath path = new GraphicsPath();
            int radius = 15; // Adjust this value to change the corner roundness
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(rect.X + rect.Width - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(rect.X + rect.Width - radius * 2, rect.Y + rect.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();

            // Set the clipping region of the graphics object to the custom shape
            e.Graphics.SetClip(path);

            // Fill the background with the control's BackColor
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), rect);

            // Reset the clipping region
            e.Graphics.ResetClip();

            // Dispose of the GraphicsPath object
            path.Dispose();
        }
    }
}
