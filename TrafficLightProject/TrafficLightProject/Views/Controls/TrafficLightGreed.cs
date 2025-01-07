using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrafficLightProject.Models;

namespace TrafficLightProject.Views.Controls
{
    public partial class TrafficLightGreed : UserControl
    {
        private TrafficLight _trafficLight;
        private Point[,] _locations;
        private Dictionary<MainSection, TraffickLightSection> _sectionControls;
        public TrafficLightGreed(TrafficLight trafficLight)
        {
            _trafficLight = trafficLight;
            MatchVievAndModelSections();
            InitializeComponent();
        }

        private void MatchVievAndModelSections()
        {
            var redSection = new TraffickLightSection(System.Drawing.Color.Red);
            redSection.Location = new Point(Constants.SECTION_WIDTH, 0);
            this.Controls.Add(redSection);

            var yellowSection = new TraffickLightSection(System.Drawing.Color.Yellow);
            yellowSection.Location = new Point(Constants.SECTION_WIDTH, Constants.SECTION_WIDTH);
            this.Controls.Add(yellowSection);

            var greenSection = new TraffickLightSection(System.Drawing.Color.Green);
            greenSection.Location = new Point(Constants.SECTION_WIDTH, Constants.SECTION_WIDTH * 2);
            this.Controls.Add(greenSection);

            _sectionControls = new Dictionary<MainSection, TraffickLightSection>()
            {
                { _trafficLight.MainSections.FirstOrDefault(s => s.Position == TrafficLightPosition.Up), redSection},
                { _trafficLight.MainSections.FirstOrDefault(s => s.Position == TrafficLightPosition.Middle), yellowSection },
                { _trafficLight.MainSections.FirstOrDefault(s => s.Position == TrafficLightPosition.Down), greenSection}
            };
        }
    }
}
