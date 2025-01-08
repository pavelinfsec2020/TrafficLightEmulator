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
        public static readonly string SECTION_OFF_IMAGE;
        public static readonly string SECTION_ON_RED;
        public static readonly string SECTION_ON_YELLOW;
        public static readonly string SECTION_ON_GREEN;
        public static readonly string SECTION_ON_BLUE;
        public static readonly Size BUTTON_CONTROL_PANEL_SIZE;
        public static readonly int GREED_WITH;

        static Constants()
        {
            RESOURCES = GetResourcesPath();
            SECTION_OFF_IMAGE = RESOURCES + "SectionOffImage.png";
            SECTION_ON_RED = RESOURCES + "SectionOnRed.png";
            SECTION_ON_YELLOW = RESOURCES + "SectionOnYellow.png";
            SECTION_ON_GREEN = RESOURCES + "SectionOnGreen.png";
            GREED_WITH = SECTION_WIDTH * 3;
            BUTTON_CONTROL_PANEL_SIZE = new Size(400,40);
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
