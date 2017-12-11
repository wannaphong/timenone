using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using LiteDB;
using System.Diagnostics;
using System.Media;

namespace timenone
{
    public partial class FirstCustomControl : UserControl
    {
        public List<string> h = new List<string>();
        public List<string> m = new List<string>();
        public List<string> note = new List<string>();
        string file = "", now;
        Task task1;
        public FirstCustomControl()
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
            now = timenow1.ToString("HH:mm");
            this.Text = "ขณะนี้เป็นเวลา " + timenow1.ToString("HH:mm:ss");
            try
            {
                task1 = Task.Factory.StartNew(() => check_time(timenow1));

            }
            catch
            {

            }
            timer1.Start();
        }
        TimeSpan timeold = DateTime.Now.TimeOfDay;
        List<string> name_5 = new List<string>();// string[] name_5;
        public bool Check_Notifications(TimeSpan timeinday, string name)
        {
            bool v = true;
            if (timeold.Equals(timeinday) != false)
            {
                timeold = timeinday;
                name_5.Clear();
                v = true;
            }
            else
            {
                if (name_5.ToArray().Length != 0)
                {
                    int i = 0;
                    string[] name_51 = name_5.ToArray();
                    while (i < name_51.Length)
                    {
                        if (name_51[i] == name)
                        {
                            v = false;
                            break;
                        }
                        i++;
                    }
                    name_5.Add(name);
                }
                else
                {
                    v = true;
                    name_5.Add(name);
                }
            }
            return v;
        }
        static string[] SplitWords(string s, string rule)
        {
            return Regex.Split(s, rule);
        }
        NotifyIcon notifyIcon = new NotifyIcon();
        private void show_Notifications(TimeSpan timeinday, string name)
        {
            if (Check_Notifications(timeinday, name) == true)
            {
                string[] list = SplitWords(name, @",code123 ");
                string[] list2 = SplitWords(name, @",code123none ");
                string code = "";
                if (list.Length == 2 || list2.Length == 2)
                {
                    if (list2.Length == 2)
                    {
                        Process proc = new Process();
                        proc.StartInfo.FileName = "CMD.exe";
                        proc.StartInfo.Arguments = "/c " + list2[1];
                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc.Start();
                        name = list2[0];
                        code = list2[1];
                    }
                    else if (list.Length == 2)
                    {
                        string strCmdText = "/c " + list[1];
                        System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                        name = list[0];
                        code = list[1];
                    }
                    name += "\r\n" + "คำสั่งพิเศษ : " + code;
                }
                else if (Regex.IsMatch(name, @"\,code123 ") || Regex.IsMatch(name, @"\,code123none "))
                {

                    if (Regex.IsMatch(name, @"\,code123 "))
                    {
                        string strCmdText = "/c " + SplitWords(name, @",code123 ")[0];
                        System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                        code = SplitWords(name, @",code123 ")[0];
                    }
                    else if (Regex.IsMatch(name, @"\,code123none "))
                    {
                        Process proc = new Process();
                        proc.StartInfo.FileName = "CMD.exe";
                        proc.StartInfo.Arguments = "/c " + SplitWords(name, @",code123none ")[0];
                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc.Start();
                        code = SplitWords(name, @",code123none ")[0];
                    }
                    name = "\r\n" + "คำสั่งพิเศษ : " + code;
                }
                String timenow = new DateTime(timeinday.Ticks).ToString("HH:mm");

                notifyIcon.Icon = new System.Drawing.Icon(@"C:\Users\wannaphong\Documents\timenone\fzap_clock_sportstudio_design_Xaa_icon.ico");
                notifyIcon.Text = "สวัสดี";//string.Format(Properties.Resources.InstantNoteAppName, Constants.Application_Name);
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(16000, "แจ้งเตือนเวลา " + timenow + " น.", name, ToolTipIcon.Warning);
                SoundPlayer my_wave_file = new SoundPlayer(@"C:\Users\wannaphong\Documents\timenone\timenone\funky-breakbeat_102bpm_F_major.wav");
                my_wave_file.PlaySync();
                notifyIcon.Visible = false;
                MessageBox.Show(name, "แจ้งเตือนเวลา " + timenow + " น.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                notifyIcon.Dispose();
                task1.Dispose();
            }
        }

        private void FirstCustomControl_Load(object sender, EventArgs e)
        {
            timenow.Text = DateTime.Now.ToLongTimeString();
            check_time(DateTime.Now);
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
                    .Find(x => x.H == timeOfDay.Hours.ToString() && x.M == timeOfDay.Minutes.ToString());
                if (query.ToArray().Length != 0)
                {
                    foreach (var order in query)
                    {
                        if (order.IsActive == true)
                        {
                            switch (day)
                            {
                                case "Sunday":
                                    if (order.Sunday == true) show_Notifications(timeOfDay, order.Title);
                                    break;
                                case "Monday":
                                    if (order.Monday == true) show_Notifications(timeOfDay, order.Title);
                                    break;
                                case "Tuesday":
                                    if (order.Tuesday == true) show_Notifications(timeOfDay, order.Title);
                                    break;
                                case "Wednesday":
                                    if (order.Wednesday == true) show_Notifications(timeOfDay, order.Title);
                                    break;
                                case "Thursday":
                                    if (order.Thursday == true) show_Notifications(timeOfDay, order.Title);
                                    break;
                                case "Friday":
                                    if (order.Friday == true) show_Notifications(timeOfDay, order.Title);
                                    break;
                                case "Saturday":
                                    if (order.Saturday == true) show_Notifications(timeOfDay, order.Title);
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
