using TrafficLightProject.Controllers;
using TrafficLightProject.Views.Forms;

namespace TrafficLightProject
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var trafficLightForm = new TrafficLightForm();
            //получаем ссылку на созданный в форме светофор через метод с паролем
            var trafficLight = trafficLightForm.ConnectToTrafficLight("Qwerty123456");
            var controller = new ControlPanelController(trafficLight);
            Application.Run(trafficLightForm);
        }
    }
}