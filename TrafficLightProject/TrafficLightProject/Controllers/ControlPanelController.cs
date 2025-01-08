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

            form._buttons[3].Click += (s, e) =>
            {
                _trafficLight.AddTurnSection(ArrowTurn.Left, 5);
            };

            form._buttons[4].Click += (s, e) =>
            {
                _trafficLight.AddTurnSection(ArrowTurn.Right, 5);
            };

            form._buttons[5].Click += (s, e) =>
            {
                _trafficLight.RemoveTurnSection(ArrowTurn.Left);
            };

            form._buttons[6].Click += (s, e) =>
            {
                _trafficLight.RemoveTurnSection(ArrowTurn.Right);
            };

            form._buttons[7].Click += (s, e) =>
            {
                _trafficLight.ActivateTurnSection();
            };

            form._buttons[8].Click += (s, e) =>
            {
                _trafficLight.IsTurnActivated = false;
            };

            form.Show();
        }
    }
}
