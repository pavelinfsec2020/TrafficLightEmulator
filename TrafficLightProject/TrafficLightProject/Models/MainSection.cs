using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightProject.Models
{
    internal class MainSection : Section
    {
        public MainSection(Color sectionColor, int interval) : base (interval) 
        { 
           SectionColor = sectionColor;
           Position = GetPosition(); 
        }

        public bool HasTimerDisplay { get; set; }

        protected override TrafficLightPosition GetPosition()
        { 
           switch (SectionColor) 
           {
                case Color.Red:
                    return TrafficLightPosition.Up;
                case Color.Yellow: 
                    return TrafficLightPosition.Middle;
                case Color.Green:
                    return TrafficLightPosition.Down;
                default: return base.GetPosition();
           }
        }
    }
}
