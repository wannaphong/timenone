using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Timer_system : Form
    {
        bool start = false;
        System.Timers.Timer t;
        int h, m, s;
        public Timer_system()
        {
            InitializeComponent();
        }

        private void Timer_system_Load(object sender, EventArgs e)
        {
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent1;
        }

        private void bnStart_Click(object sender, EventArgs e)
        {
            if (start == false) { t.Start(); bnStart.Text = "เริ่มใหม่"; }
            else { t.Stop(); t.Enabled = false; t.Enabled = true ; t.Start(); }
        }

        private void bnP_Click(object sender, EventArgs e)
        {
            t.Stop();
        }

        private void bnStop_Click(object sender, EventArgs e)
        {
            t.Enabled = false;
            show_time.Text = "00:00:00";
        }

        private void time_now_save_Click(object sender, EventArgs e)
        {
            timebox.Text += string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'))+"\r\n";
        }

        private void OnTimeEvent1(object sender,System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                s += 1;
                if (s == 60)
                {
                    s = 0;
                    m++;
                }
                if (m == 60)
                {
                    m = 0;
                    h++;
                }
                show_time.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            }
            ));
        }




        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
