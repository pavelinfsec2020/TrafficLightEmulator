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
            _offImage = Constants.SECTION_OFF_IMAGE;
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
                    return Constants.SECTION_ON_RED;
                case Color.Yellow:
                    return Constants.SECTION_ON_YELLOW;
                case Color.Green:
                    return Constants.SECTION_ON_GREEN;
                case Color.Green_Left_Arrow:
                    return Constants.SECTION_TURN_LEFT;
                case Color.Green_Right_Arrow:
                    return Constants.SECTION_TURN_RIGHT;
                default:
                    return Constants.SECTION_OFF_IMAGE;
            }
        }

    }
}
