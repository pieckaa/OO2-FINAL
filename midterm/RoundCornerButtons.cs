using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace OOP2
{
    internal class RoundCornerButton : Button
    {
        public RoundCornerButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.LightGray;
            ForeColor = Color.Black;
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            Size = new Size(100, 40);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 20; // Adjust this value to change the roundness of the button
                path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                path.AddArc(Width - (radius * 2), 0, radius * 2, radius * 2, 270, 90);
                path.AddArc(Width - (radius * 2), Height - (radius * 2), radius * 2, radius * 2, 0, 90);
                path.AddArc(0, Height - (radius * 2), radius * 2, radius * 2, 90, 90);
                path.CloseFigure();

                Region = new Region(path);
            }
        }
    }
}
