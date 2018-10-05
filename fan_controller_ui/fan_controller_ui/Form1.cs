using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fan_controller_ui_window
{
    public partial class ui_form : Form
    {
        public ui_form()
        {
            InitializeComponent();
            Console.WriteLine("hello");
            tempULabel.Text = "Temperature Unit";
            rbCels.Text = "Celsius";
            rbFahr.Text = "Fahrenheit";
            fanSpeedLabel.Text = "Fan Speed";
            fanSpeedBar.Value = 5;
            sendButton.Text = "Send";
            statusLabel.Text = "Status Good";

            sendButton.Click += new System.EventHandler(this.send_click);
        }

        private void send_click(object sender, EventArgs e)
        {
            Console.WriteLine("got clicked");
        }
    }
}
