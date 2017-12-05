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
    public partial class home : Form
    {
        public List<string> h = new List<string>();
        public List<string> m = new List<string>();
        public List<string> note = new List<string>();
        public home()
        {
            var db = new db();
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime timenow1 = DateTime.Now;
            timenow.Text = timenow1.ToString("HH:mm:ss");
            this.Text = "ขณะนี้เป็นเวลา "+ timenow1.ToString("HH:mm:ss");
            try
            {

            }
            catch
            {

            }
            timer1.Start();
        }
        private void check_time(DateTime s)
        {
            TimeSpan timeOfDay = s.TimeOfDay;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timenow.Text = DateTime.Now.ToLongTimeString();
            check_time(DateTime.Now);
        }

        private void ออกจากโปรแกรมToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);// ออกจากโปรแกรม
        }

        private void เกยวกบโปรแกรมToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about about = new about();
            about.ShowDialog();
        }

        private void นาฬกานบถอยหลงToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Countdown cd = new Countdown();
            cd.Show();
        }

        private void add_Click(object sender, EventArgs e)
        {
            add_alert a = new add_alert();
            a.ShowDialog();
        }

        private void นาฬกาจบเวลาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Timer_system a = new Timer_system();
            a.ShowDialog();
        }
    }
}
