using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLightProject.Views.Controls
{
    public partial class TrafficLightGreed : UserControl
    {
        private Point[,] _locations;
        private TraffickLightSection[] _mainSections = new TraffickLightSection[] { 
          new TraffickLightSection(Color.Red), new TraffickLightSection(Color.Yellow), new TraffickLightSection(Color.Green),
        };
        public TrafficLightGreed()
        {
            InitializeComponent();
            InitLocations();
            AddMainSectionsToGrid();
        }

        private void InitLocations()
        {
            _locations = new Point[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _locations[i, j] = new Point(j * Constants.SECTION_WIDTH, i * Constants.SECTION_WIDTH);
                }
            }    
        }

        private void AddMainSectionsToGrid()
        { 
           for (int i = 0; i < 3; i++)
           {
               _mainSections[i].Location = new Point(Constants.SECTION_WIDTH, i * 100);
                this.Controls.Add(_mainSections[i]);   
                
           }
        }
    }
}
