using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.PropertyGridInternal;


using System.Resources;

namespace TrafficLightProject.Views.Controls
{
    public partial class TraffickLightSection : UserControl
    {
        private Color _lightColor;
        private readonly Color _borderColor = Color.Gray;
        private readonly Color _backgroundColor = Color.Black;
        private readonly Image _sectionImage;
        public TraffickLightSection(Color color)
        {
            InitializeComponent();
            _lightColor = color;
            _sectionImage = Image.FromFile(Constants.SECTION_OFF_IMAGE);
            this.BackgroundImage = _sectionImage;
        }
               
    }
}
