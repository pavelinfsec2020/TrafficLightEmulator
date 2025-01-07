using System.Runtime.CompilerServices;
using TrafficLightProject.Models;
using TrafficLightProject.Views.Controls;


namespace TrafficLightProject.Views.Forms
{
    public partial class TrafficLightForm : Form
    {
        private TrafficLight _trafficLight;
        private TrafficLightGreed _trafficLightControl;
        public TrafficLightForm()
        {
            InitializeComponent();
            _trafficLight = new TrafficLight();
            _trafficLightControl = new TrafficLightGreed(_trafficLight);
            this.Controls.Add(_trafficLightControl);
        }

        private void TrafficLightForm_Load(object sender, EventArgs e)
        {
            var size = new Size(Constants.GREED_WITH + 10, Constants.GREED_WITH + 30);
            this.Size = size;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        public TrafficLight ConnectToTrafficLight (string password)
        {
            //Можно заморочиться с хешированием пароля и хранить в ресурсах его, но не стал заморачиваться, просто для примера
            if (password == "Qwerty123456")
            { 
               return _trafficLight;
            }

            return null;
        }
    }
}
