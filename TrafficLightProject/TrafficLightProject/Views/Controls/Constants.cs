﻿using System;
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
        public static readonly int GREED_WITH;

        static Constants()
        {
            RESOURCES = GetResourcesPath();
            SECTION_OFF_IMAGE = RESOURCES + "SectionOffImage.png";
            GREED_WITH = SECTION_WIDTH * 3;
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
