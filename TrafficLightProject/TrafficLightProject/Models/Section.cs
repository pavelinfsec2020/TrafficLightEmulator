using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightProject.Models
{
    internal abstract class Section
    {

        public Section(int timeInterval)
        { 
           TimeInterval = timeInterval;
        }
        public Color SectionColor { get; protected set; }
        public bool IsEnabled { get; set; }

        public int TimeInterval { get; private set; }
        public TrafficLightPosition Position { get; protected set; }

        protected virtual TrafficLightPosition GetPosition()
        { 
           return TrafficLightPosition.None;
        }
    }
}
