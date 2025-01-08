using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightProject.Views.Controls
{
    internal static class Constants
    {
        public const int SECTION_WIDTH = 105;
        public static readonly string RESOURCES;
        public static readonly Image SECTION_OFF_IMAGE;
        public static readonly Image SECTION_ON_RED;
        public static readonly Image SECTION_ON_YELLOW;
        public static readonly Image SECTION_ON_GREEN;
        public static readonly string SECTION_ON_BLUE;
        public static readonly Size BUTTON_CONTROL_PANEL_SIZE;
        public static readonly int GREED_WITH;
        public static readonly Image SECTION_TURN_LEFT;
        public static readonly Image SECTION_TURN_RIGHT;

        static Constants()
        {
            RESOURCES = GetResourcesPath();
            SECTION_OFF_IMAGE = Image.FromFile(RESOURCES + "SectionOffImage.png");
            SECTION_ON_RED = Image.FromFile(RESOURCES + "SectionOnRed.png");
            SECTION_ON_YELLOW = Image.FromFile(RESOURCES + "SectionOnYellow.png");
            SECTION_ON_GREEN = Image.FromFile(RESOURCES + "SectionOnGreen.png");
            GREED_WITH = SECTION_WIDTH * 3;
            BUTTON_CONTROL_PANEL_SIZE = new Size(400,40);
            SECTION_TURN_LEFT = Image.FromFile(RESOURCES + "SectionTurnLeft.png");
            SECTION_TURN_LEFT = Image.FromFile(RESOURCES + "SectionTurnRight.png");
        }

        private static string GetResourcesPath()
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var resources = Path.Combine(projectDirectory + "\\Resources\\");

            return resources;
        }
    }
}
