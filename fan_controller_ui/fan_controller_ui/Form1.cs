﻿using System;
using System.Linq;
using System.Management;
using OpenHardwareMonitor.Collections;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml;
using System.ServiceModel.Syndication;

namespace fan_controller_ui_window
{
    public partial class ui_form : Form
    {
        // Create the serial port with basic settings
        private SerialPort port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
        private readonly Mutex m = new Mutex();

        public ui_form()
        {
            InitializeComponent();
            tempULabel.Text = "Temperature Unit";
            rbCels.Text = "Celsius";
            rbFahr.Text = "Fahrenheit";
            fanSpeedLabel.Text = "Fan Speed";
            fanSpeedBar.Value = 4;
            sendButton.Text = "Send";
            statusLabel.Text = "Status Good";

            sendButton.Click += new System.EventHandler(this.send_click);
            rbCels.Click += new System.EventHandler(this.handle_rb_click);
            rbFahr.Click += new System.EventHandler(this.handle_rb_click);


            ThreadStart timer_start = new ThreadStart(timer_thread);
            Thread timer_child = new Thread(timer_start);
            timer_child.Start();

            string url = "http://rss.cnn.com/rss/cnn_world.rss";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach (SyndicationItem item in feed.Items)
            {
                String subject = item.Title.Text;
                send_serial_data(subject, '#');
                break;
                String summary = item.Summary.Text;
                //Console.WriteLine("subj: ");
                Console.WriteLine(subject);
            }
        }

        public void timer_thread()
        {
            while (true)
            {
                m.WaitOne();
                var current_time = get_time();
                Console.WriteLine(current_time + "");
                send_serial_data(current_time + "", '%');
                m.ReleaseMutex();
                Thread.Sleep(60000);
            }
        }

        private void handle_rb_click(object sender, EventArgs e)
        {
            Console.WriteLine(sender.ToString());
            if (rbCels.Checked)
            {
                Console.WriteLine("cels is clicked");
                send_serial_data("C", '^');
            }
            else if (rbFahr.Checked)
            {
                Console.WriteLine("fahr is clicked");
                send_serial_data("F", '^');
            }
        }

        private string get_time()
        {
            return DateTime.Now.ToString("h:mm");
        }

        private void send_click(object sender, EventArgs e)
        {
            Console.WriteLine(fanSpeedBar.Value + "");
            send_serial_data(fanSpeedBar.Value + "", ';');
        }

        private void send_serial_data(String serial_data, char delim)
        {
            port.Open();
            port.Write(serial_data + delim);
            port.Close();
        }
    }
}
