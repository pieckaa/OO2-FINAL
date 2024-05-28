using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2
{
    public class ComboBoxWithPillShape : ComboBox
    {
        private const int WM_PAINT = 0xF;
        private const int WM_NC_PAINT = 0x85;
        private const int WM_ERASEBKGND = 0x14;
        private const int EM_SETCUEBANNER = 0x1501;

        private Color borderColor = Color.Gray;
        private int borderRadius = 15; // Adjust this value to change the roundness of the corners

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }

        public int BorderRadius
        {
            get { return borderRadius; }
            set { borderRadius = value; Invalidate(); }
        }

        public ComboBoxWithPillShape()
        {
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT || m.Msg == WM_NC_PAINT || m.Msg == WM_ERASEBKGND)
            {
                using (var g = Graphics.FromHwnd(Handle))
                {
                    using (var borderPen = new Pen(borderColor, 2))
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.DrawRoundedRectangle(borderPen, ClientRectangle, borderRadius);
                    }
                }
            }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            SetCueBanner("Search...");
        }

        public void SetCueBanner(string cue)
        {
            SendMessage(this.Handle, EM_SETCUEBANNER, 0, cue);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
    }

    public static class GraphicsExtensions
    {
        public static void DrawRoundedRectangle(this Graphics g, Pen pen, Rectangle bounds, int borderRadius)
        {
            int diameter = borderRadius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);

            // Top left arc
            g.DrawArc(pen, arc, 180, 90);

            // Top right arc
            arc.X = bounds.Right - diameter;
            g.DrawArc(pen, arc, 270, 90);

            // Bottom right arc
            arc.Y = bounds.Bottom - diameter;
            g.DrawArc(pen, arc, 0, 90);

            // Bottom left arc
            arc.X = bounds.Left;
            g.DrawArc(pen, arc, 90, 90);

            // Draw lines
            g.DrawLine(pen, bounds.Left + borderRadius, bounds.Top, bounds.Right - borderRadius, bounds.Top); // Top
            g.DrawLine(pen, bounds.Left + borderRadius, bounds.Bottom, bounds.Right - borderRadius, bounds.Bottom); // Bottom
            g.DrawLine(pen, bounds.Left, bounds.Top + borderRadius, bounds.Left, bounds.Bottom - borderRadius); // Left
            g.DrawLine(pen, bounds.Right, bounds.Top + borderRadius, bounds.Right, bounds.Bottom - borderRadius); // Right
        }
    }
}
