using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrafficLightProject.Models;
using Color = TrafficLightProject.Models.Color;

namespace TrafficLightProject.Views.Controls
{
    public partial class TrafficLightGreed : UserControl
    {
        private TrafficLight _trafficLight;
        private Point[,] _locations;
        private List<TurnSection> _turnSections;
        public TrafficLightGreed(TrafficLight trafficLight)
        {
            _trafficLight = trafficLight;
            this.DataBindings.Add("TurnSections", _trafficLight, "TurnSections", true, DataSourceUpdateMode.OnPropertyChanged);
            MatchVievAndModelSections();
            InitializeComponent();
        }

        public List<TurnSection> TurnSections
        { 
           get { return _turnSections; }
            set { _turnSections = value; RenderTurnSections(); }
        }

        private void RenderTurnSections()
        {
            foreach (var turnSectionModel in _turnSections)
            {
                var isLeftTurn = turnSectionModel.ArrowTurn == ArrowTurn.Left;
                var turnSectionView = new TraffickLightSection(isLeftTurn ? Color.Green_Left_Arrow :
                                                                            Color.Green_Right_Arrow);
                turnSectionView.Location = new Point( isLeftTurn ? 0:  Constants.SECTION_WIDTH * 2, Constants.SECTION_WIDTH * 2);
                turnSectionView.DataBindings.Add("IsEnabled", turnSectionView, "IsEnabled", true, DataSourceUpdateMode.OnPropertyChanged);
                this.Controls.Add(turnSectionView);
            }
        }

        /// <summary>
        /// MVVM Паттерн для динамического отображения секвтора в Winforms в зависимости от состояния модельки.
        /// </summary>
        private void MatchVievAndModelSections()
        {
            var redSectionView = new TraffickLightSection(Color.Red);
            var redSectionModel = _trafficLight.MainSections.FirstOrDefault(s => s.Position == TrafficLightPosition.Up);
            redSectionView.Location = new Point(Constants.SECTION_WIDTH, 0);
            redSectionView.DataBindings.Add("IsEnabled", redSectionModel, "IsEnabled", true, DataSourceUpdateMode.OnPropertyChanged);
            this.Controls.Add(redSectionView);

            var yellowSectionView = new TraffickLightSection(Color.Yellow);
            var yellowSectionModel = _trafficLight.MainSections.FirstOrDefault(s => s.Position == TrafficLightPosition.Middle);
            yellowSectionView.Location = new Point(Constants.SECTION_WIDTH, Constants.SECTION_WIDTH);
            yellowSectionView.DataBindings.Add("IsEnabled", yellowSectionModel, "IsEnabled", true, DataSourceUpdateMode.OnPropertyChanged);
            this.Controls.Add(yellowSectionView);

            var greenSectionView = new TraffickLightSection(Color.Green);
            var greenSectionModel = _trafficLight.MainSections.FirstOrDefault(s => s.Position == TrafficLightPosition.Down);
            greenSectionView.Location = new Point(Constants.SECTION_WIDTH, Constants.SECTION_WIDTH * 2);
            greenSectionView.DataBindings.Add("IsEnabled", greenSectionModel, "IsEnabled", true, DataSourceUpdateMode.OnPropertyChanged);
            this.Controls.Add(greenSectionView);
        }
    }
}
