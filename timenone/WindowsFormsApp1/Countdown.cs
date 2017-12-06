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
        int time;
       // public
        int OrigTime = 18000;
        public Countdown()
        {
            InitializeComponent();
        }

        private void Countdown_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            OrigTime--;
            label1.Text = OrigTime / 60 + ":" + ((OrigTime % 60) >= 10 ? (OrigTime % 60).ToString() : "0" + OrigTime % 60);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Timer timeX = new Timer();
            //timeX.Interval = 1800000;
            timeX.Tick += new EventHandler(timer1_Tick);
        }
    }
}
