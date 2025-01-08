using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightProject.Models
{
    public class TrafficLight : INotifyPropertyChanged
    {
        private List<TurnSection> _turnSections;
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
        public bool IsMainActivated { get; set; }
        public bool IsTurnActivated { get; set; }
        public MainSection[] MainSections { get; set; }
        public List<TurnSection> TurnSections 
        { 
            get { return _turnSections; }
            set 
            {
                _turnSections = value;
                OnPropertyChanged(nameof(TurnSections)); 
            } 
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool AddTurnSection(ArrowTurn arrow, int interval)
        {
            if (TurnSections.Any(s => s.ArrowTurn == arrow))
                return false;

            TurnSections.Add(new TurnSection(interval, arrow));
           //Делаю лишнее присвоение для принудительного вызова set свойства, так как привязка databinding настроена с ее представлением.
            TurnSections = TurnSections;

            return true;
        }

        public bool RemoveTurnSection(ArrowTurn arrow)
        {
            if (TurnSections.Any(s => s.ArrowTurn != arrow))
                return false;

            TurnSections.Remove(
                TurnSections.FirstOrDefault(s => s.ArrowTurn == arrow));

            IsTurnActivated = TurnSections.Any();

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
            IsMainActivated = true;

            while (IsMainActivated)
            {
                var delay = MainSections[1].TimeIntervalSeconds * 1000;
                MainSections[1].IsEnabled = true;
                await Task.Delay(delay);
                MainSections[1].IsEnabled = false;
                await Task.Delay(delay);
            }
        }

        public async void ActivateStandartMode()
        {
            TurnOffTrafficLight();
            IsMainActivated = true;

            while (IsMainActivated)
            {
                var blinkingDelay = 700;

                //красный - желтый синий поочередно загораются

                for (int i = 0; i < MainSections.Length; i++)
                {
                    if (!IsMainActivated)
                        return;

                    MainSections[i].IsEnabled = true;
                    await Task.Delay(MainSections[i].TimeIntervalSeconds * 1000);

                    MainSections[i].IsEnabled = false;
                    await Task.Delay(blinkingDelay);

                    //для желтого сигнала светофора мигания не нужны, он гормт всего 2 секунды
                    if (i == 1)
                        continue;

                    MainSections[i].IsEnabled = true;
                    await Task.Delay(blinkingDelay);

                    MainSections[i].IsEnabled = false;
                    await Task.Delay(blinkingDelay);
                }

                //опять желтый и по новому цикл с красного сигнала светофора идет
                MainSections[1].IsEnabled = true;
                await Task.Delay(MainSections[1].TimeIntervalSeconds * 1000);

                MainSections[1].IsEnabled = false;
                await Task.Delay(blinkingDelay);
            }
        }

        public async Task<bool> ActivateTurnSection()
        {
            if (!TurnSections.Any()) 
                return false;
           
            IsTurnActivated = true;

            while (IsTurnActivated)
            {
                foreach (var section in TurnSections)
                {
                    section.IsEnabled = true;
                    await Task.Delay(section.TimeIntervalSeconds * 1000);              
                    var turnDelay = (MainSections[0].TimeIntervalSeconds * 1000 ) / 2;
                    section.IsEnabled = false;
                    await Task.Delay(turnDelay);
                }
            }

            return true;
        }

        private async void StartSection(int sectionIndex, int mainDelay)
        {
            MainSections[sectionIndex].IsEnabled = true;
            await Task.Delay(mainDelay);
            MainSections[sectionIndex].IsEnabled = false;
        }

        public void TurnOffTrafficLight()
        {
            IsMainActivated = false;
            IsTurnActivated = false;   

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
