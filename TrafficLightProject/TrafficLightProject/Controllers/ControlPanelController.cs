using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightProject.Models;
using TrafficLightProject.Views.Forms;

namespace TrafficLightProject.Controllers
{
    internal class ControlPanelController
    {
        private TrafficLight _trafficLight;
        public ControlPanelController(TrafficLight trafficLight) 
        { 
            _trafficLight = trafficLight;
            var form = new ControlPanelForm();

            form._buttons[0].Click += (s, e) =>
            {
                _trafficLight.ActivateNonStopMode();
            };

            form._buttons[1].Click += (s, e) =>
            {
                _trafficLight.ActivateStandartMode();
            };

            form._buttons[2].Click += (s, e) =>
            {
                _trafficLight.TurnOffTrafficLight();
            };

            form.Show();
        }
    }
}
