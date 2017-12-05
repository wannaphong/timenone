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
                check_time(timenow1);

            }
            catch
            {

            }
            timer1.Start();
        }
        private void a(TimeSpan timeinday,string name)
        {
            MessageBox.Show(name);
        }
        private void check_time(DateTime s)
        {
            TimeSpan timeOfDay = s.TimeOfDay;
            var day = s.DayOfWeek.ToString();
            var time = new db.Notifications();
           //MessageBox.Show(day+timeOfDay.Hours.ToString() + timeOfDay.Minutes.ToString() + timeOfDay.Seconds.ToString());
            using (var db2 = new LiteDatabase(file))
            {
                var orders = db2.GetCollection<db.Notifications>("Notifications");

                // When query Order, includes references
                var query = orders//.Include(S => timeOfDay.Seconds.ToString())
                    .Find(x => x.H == timeOfDay.Hours.ToString() && x.M == timeOfDay.Minutes.ToString() && x.S == timeOfDay.Seconds.ToString());
                //.Find(x => x.S == timeOfDay.Seconds.ToString());
                //.Include(S => timeOfDay.Seconds.ToString());
                // .Find(x => x.OrderDate <= DateTime.Now);
                if (query.ToArray().Length != 0)
                {
                    foreach (var order in query)
                    {
                        if (order.IsActive == true)
                        {
                            switch (day)
                            {
                                case "Sunday":
                                    if (order.Sunday == true) a(timeOfDay, order.Title);
                                    break;
                                case "Monday":
                                    if (order.Monday == true) a(timeOfDay, order.Title);
                                    break;
                                case "Tuesday":
                                    if (order.Tuesday == true) a(timeOfDay, order.Title);
                                    break;
                                case "Wednesday":
                                    if (order.Wednesday == true) a(timeOfDay, order.Title);
                                    break;
                                case "Thursday":
                                    if (order.Thursday == true) a(timeOfDay, order.Title);
                                    break;
                                case "Friday":
                                    if (order.Friday == true) a(timeOfDay, order.Title);
                                    break;
                                case "Saturday":
                                    if (order.Saturday == true) a(timeOfDay, order.Title);
                                    break;
                            }

                        }
                    }
                }
                
                // MessageBox.Show(day.ToString()+query.ToArray().Length.ToString());            }
            }
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
            home a1 = new home();
            add_alert a = new add_alert();
            a.Show();
            a1.Close();
        }

        private void นาฬกาจบเวลาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Timer_system a = new Timer_system();
            a.ShowDialog();
        }
    }
}
