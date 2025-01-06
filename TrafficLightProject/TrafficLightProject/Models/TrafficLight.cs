using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightProject.Models
{
    internal class TrafficLight
    {
        public TrafficLight()
        {
            TurnSections = new List<TurnSection>();
            MainSections = new MainSection[]
            {
                new MainSection (Color.Red, 5),
                new MainSection (Color.Yellow, 1),
                new MainSection (Color.Green, 10),
            };
        }
        public bool IsActivated { get; set; }
        public MainSection[] MainSections { get; set; }
        public List<TurnSection> TurnSections { get; set; }

        public bool AddTurnSection(ArrowTurn arrow, int interval)
        {
            if (TurnSections.Any(s => s.ArrowTurn == arrow))
                return false;

            TurnSections.Add(new TurnSection(interval, arrow));

            return true;
        }

        public bool RemoveTurnSection(ArrowTurn arrow)
        {
            if (TurnSections.Any(s => s.ArrowTurn != arrow))
                return false;

            TurnSections.Remove(
                TurnSections.FirstOrDefault(s => s.ArrowTurn == arrow));

            return true;
        }

        public void EnableTimerDisplay()
        {
            MainSections[0].HasTimerDisplay = true;
            MainSections[2].HasTimerDisplay = true;
        }

        public void DisableTimerDisplay()
        {
            MainSections[0].HasTimerDisplay = false;
            MainSections[2].HasTimerDisplay = false;
        }

        public async void ActivateNonStopMode()
        {
            TurnOffTrafficLight();
           
            while (IsActivated)
            {
                var delay = MainSections[1].TimeIntervalSeconds * 1000;
                MainSections[1].IsEnabled = true;
                await Task.Delay(delay);
                MainSections[1].IsEnabled = false;
                await Task.Delay(delay);
            }
        }

        public void TurnOffTrafficLight()
        { 
           foreach (var section in MainSections)
                section.IsEnabled = false;

            if (TurnSections.Any())
            {
                foreach (var section in TurnSections)
                    section.IsEnabled = false;
            }
        }
    }
}
