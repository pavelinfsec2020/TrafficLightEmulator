using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLightProject.Views.Forms
{
    public partial class NoResizibleForm : Form
    {
        public NoResizibleForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void NoResizibleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
