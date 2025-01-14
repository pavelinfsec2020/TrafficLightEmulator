﻿using System.ComponentModel;

namespace TrafficLightProject.Models
{
    public abstract class Section : INotifyPropertyChanged
    {
        private bool _isEnabled;
        public Section(int timeInterval)
        { 
           TimeIntervalSeconds = timeInterval;
        }
        public Color SectionColor { get; protected set; }
        public bool IsEnabled 
        { 
            get { return _isEnabled; } 
            set 
            { 
                _isEnabled = value; 
                OnPropertyChanged(nameof(IsEnabled)); 
            } 
        }

        public int TimeIntervalSeconds { get; set; }
        public TrafficLightPosition Position { get; protected set; }

        protected virtual TrafficLightPosition GetPosition()
        { 
           return TrafficLightPosition.None;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
