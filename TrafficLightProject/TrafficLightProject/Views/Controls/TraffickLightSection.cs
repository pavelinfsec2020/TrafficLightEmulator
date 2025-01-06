using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLightProject.Views.Controls
{
    public partial class TraffickLightSection : UserControl
    {
        private Color _lightColor;
        private readonly Color _borderColor = Color.Gray;
        private readonly Color _backgroundColor = Color.Black;
        public TraffickLightSection(Color color)
        {
            InitializeComponent();
            _lightColor = color;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            var borderPen = new Pen(_borderColor, 10);
            var backGroundBrush = new SolidBrush(_backgroundColor);
            var border = new Rectangle(this.Location,this.Size);
            var backGround = new Rectangle(new Point (this.Location.X + 4, this.Location.Y + 4), new Size (this.Width - 8, this.Height - 8));
            pe.Graphics.DrawRectangle(borderPen, border);
            pe.Graphics.FillRectangle(backGroundBrush, backGround);
        }

    }
}
