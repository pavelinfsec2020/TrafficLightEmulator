using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrafficLightProject.Views.Controls;

namespace TrafficLightProject.Views.Forms
{
    public partial class TrafficLightForm : Form
    {
        public TrafficLightForm()
        {
            InitializeComponent();
            this.Controls.Add(new TraffickLightSection(Color.Red));
            this.Controls.Add(new TraffickLightSection(Color.Yellow));
            this.Controls.Add(new TraffickLightSection(Color.Green));
        }
    }
}
