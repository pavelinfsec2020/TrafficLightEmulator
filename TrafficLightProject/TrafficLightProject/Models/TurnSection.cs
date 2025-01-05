using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightProject.Models
{
    internal class TurnSection : Section
    {
        public TurnSection(int interval, ArrowTurn arrowTurn) : base(interval)
        { 
           ArrowTurn = arrowTurn;
           Position = GetPosition();
        }

        public ArrowTurn ArrowTurn { get; private set; }

        protected override TrafficLightPosition GetPosition()
        {
            switch (ArrowTurn)
            {
                case ArrowTurn.Left:
                    return TrafficLightPosition.Left;
                case ArrowTurn.Right:
                    return TrafficLightPosition.Right;
                default: return base.GetPosition();
            }
        }
    }
}
