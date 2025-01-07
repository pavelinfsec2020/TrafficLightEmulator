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
        public static TrafficLightGreed _trafficLightControl = new TrafficLightGreed();
        public TrafficLightForm()
        {
            InitializeComponent();
            this.Controls.Add(_trafficLightControl);
        }

        private void TrafficLightForm_Load(object sender, EventArgs e)
        {
            var size = new Size(Constants.GREED_WITH + 10, Constants.GREED_WITH + 30);
            this.Size = size;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }
    }
}
