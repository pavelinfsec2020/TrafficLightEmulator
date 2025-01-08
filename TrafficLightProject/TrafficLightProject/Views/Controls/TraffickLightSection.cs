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
using TrafficLightProject.Models;
using Color = TrafficLightProject.Models.Color;

namespace TrafficLightProject.Views.Controls
{
    public partial class TraffickLightSection : UserControl
    {
        private readonly Image _offImage;
        private readonly Image _onImage;
        private bool _isEnabled;
        public TraffickLightSection(Color color)
        {
            InitializeComponent();
            _offImage = Image.FromFile(Constants.SECTION_OFF_IMAGE);
            _onImage = GetImageFormColor(color);
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                this.BackgroundImage = value ? _onImage : _offImage;
            }
        }

        private Image GetImageFormColor(Color color)
        {
            switch (color)
            {
                case Color.Red:
                    return Image.FromFile(Constants.SECTION_ON_RED);
                case Color.Yellow:
                    return Image.FromFile(Constants.SECTION_ON_YELLOW);
                case Color.Green:
                    return Image.FromFile(Constants.SECTION_ON_GREEN);
                default:
                    return Image.FromFile(Constants.SECTION_OFF_IMAGE);
            }
        }

    }
}
