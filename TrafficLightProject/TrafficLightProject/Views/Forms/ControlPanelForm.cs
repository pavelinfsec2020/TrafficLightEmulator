using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using TrafficLightProject.Views;
using Constants = TrafficLightProject.Views.Controls.Constants;

namespace TrafficLightProject.Views.Forms
{
    public partial class ControlPanelForm : NoResizibleForm
    {
        public Button[] _buttons;
        private Size _buttonSize = Constants.BUTTON_CONTROL_PANEL_SIZE;
        public ControlPanelForm()
        {
            InitializeComponent();
            _buttons = new Button[]
             {
                 new Button { Text = "Активировать режим Нон-Стоп", Size = _buttonSize},
                 new Button { Text = "Активировать стандартный режим", Size = _buttonSize, Location = new Point(0, _buttonSize.Height)},
                 new Button { Text = "Выключить светофор", Size = _buttonSize, Location = new Point(0, _buttonSize.Height * 2)}
             };

            foreach (var button in _buttons)
               this.Controls.Add(button);  
        }

        private void ControlPanelForm_Load(object sender, EventArgs e)
        {
            var size = new Size(_buttonSize.Width,  _buttonSize.Height * (_buttons.Length + 1));
            this.Size = size;   
        }
    }
}
