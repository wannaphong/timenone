using LiteDB;
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
        string file = "";
        public home()
        {
            var db = new db();
            file = new db().file_db().ToString();
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
            var day=s.DayOfWeek.ToString();
            var time = new db.Notifications();
            using (var db2 = new LiteDatabase(file))
            {
                var orders = db2.GetCollection<db.Notifications>("Notifications");

                // When query Order, includes references
                var query = orders
                    .Find(x => x.H == timeOfDay.Hours.ToString() && x.M == timeOfDay.Minutes.ToString() && x.S == timeOfDay.Seconds.ToString() && x.Sunday&& x.Monday && x.Tuesday&&x.Wednesday&&x.Thursday&&x.Friday&&x.Saturday&&x.IsActive);
                //.Find(x => x.S == timeOfDay.Seconds.ToString());
                //.Include(S => timeOfDay.Seconds.ToString());
                // .Find(x => x.OrderDate <= DateTime.Now);
                foreach (var order in query)
                {
                    //order.
                }
                    MessageBox.Show(day.ToString()+query.ToArray().Length.ToString());            }
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
