namespace TrafficLightProject.Models
{
    public class MainSection : Section
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
