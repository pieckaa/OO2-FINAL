using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace OOP2
{
    internal class RoundCornerPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 20; // Adjust this value to change the roundness of the corners
                path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                path.AddArc(Width - (radius * 2), 0, radius * 2, radius * 2, 270, 90);
                path.AddArc(Width - (radius * 2), Height - (radius * 2), radius * 2, radius * 2, 0, 90);
                path.AddArc(0, Height - (radius * 2), radius * 2, radius * 2, 90, 90);
                path.CloseFigure();

                this.Region = new Region(path);
            }
        }
    }
}
