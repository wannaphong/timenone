﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Countdown : Form
    {
        public static double settime=0;
        public static bool run = false;
        public Countdown()
        {
            InitializeComponent();
        }
        
        private void Countdown_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (run!=false && settime>0)
            {
                settime--;
                label2.Text =  Math.Ceiling(settime / 60) + ":" + ((settime % 60) >= 10 ? (settime % 60).ToString() : "0" + settime % 60);
                //label2.Text = new DateTime().AddSeconds(settime).ToString("HH:mm:ss");
                if (label2.Text == "00:00:00")
                {
                    button1.Text = "เริ่มใหม่";
                    timer1.Enabled = false;
                    run = false;
                }
                //
            }
            else
                {
                    label2.Text = "00:00:00";
                    run = false;
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            run = true;
            if (settime != 0)
            {
                timer1 = new System.Windows.Forms.Timer();
                timer1.Interval = 1;//int.Parse(settime.ToString());
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Enabled = true;
                //timer1.Start();
            }
            else
            {
                label2.Text = "00:00:00";
                MessageBox.Show("กรุณาตั้งค่าเวลานับถอยหลัง");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "00:00:00";
            timer1.Stop();
            settime = 0;
            run = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            set_time_countdown settimebox = new set_time_countdown();
            settimebox.ShowDialog();
        }
    }
}
