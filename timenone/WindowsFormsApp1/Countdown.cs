using System;
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
        DateTime dt = new DateTime();
        private void Countdown_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (settime != 0&& run!=false)
            {
                settime-= 50;
                label2.Text = dt.AddMilliseconds(settime).ToString("HH:mm:ss");
                //label2.Text = settime / 60 + ":" + ((settime % 60) >= 10 ? (settime % 60).ToString() : "0" + settime % 60);
            }
                else
                {
                    label2.Text = "00:00:00";
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            run = true;
            if (settime != 0)
            {
                //timer1.Interval = 1000;
                timer1.Start();
                timer1.Tick += new EventHandler(timer1_Tick);
            }
            else
            {
                label2.Text = "00:00:00";
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
