using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public partial class home : Form
    {
        public List<string> h = new List<string>();
        public List<string> m = new List<string>();
        public List<string> note = new List<string>();
        string file = "",now;
        Task task1;
        public home()
        {
            var db = new db();
            file = new db().file_db().ToString();
            InitializeComponent();
            timer1.Start();
        }
        private void Form1_Resize(object sender, EventArgs e) // เมื่อ Form นี้มีการปรับขนาด
        {

            if (WindowState == FormWindowState.Minimized) // ถ้ากดปุ่มย่อหน้าจอ
            {
                this.ShowInTaskbar = false; // กำหนดไม่ให้โชว์ใน Taskbar
                this.Hide(); // ซ่อน Form นี้
            }
        }
        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime timenow1 = DateTime.Now;
            timenow.Text = timenow1.ToString("HH:mm:ss");
            now= timenow1.ToString("HH:mm");
            this.Text = "ขณะนี้เป็นเวลา "+ timenow1.ToString("HH:mm:ss");
            try
            {
               task1 = Task.Factory.StartNew(() => check_time(timenow1));
            }
            catch
            {

            }
            //timer1.Start();
        }
        TimeSpan timeold= DateTime.Now.TimeOfDay;
        List<string> name_5=new List<string> ();
        bool v = true;
        public bool Check_Notifications(TimeSpan timeinday, string name)
        {
            bool v = true;
            if ((timeold.TotalSeconds == timeinday.TotalSeconds) != false)
            {
                timeold = timeinday;
                name_5 = new List<string>();
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
        static string[] SplitWords(string s,string rule) // ประกาศ method ชื่อ SplitWords เป็น static โดยมีการรับค่าสตริง 2 ค่า คือ s และ rule
        {
            return Regex.Split(s, rule); // ใช้ Regex ในการแบ่งข้อความด้วยคำสั่ง Regex.Split โดย s คือ ข้อความ ส่วน rule คือ กฎในการแบ่งข้อความ
        }
        NotifyIcon notifyIcon = new NotifyIcon(); // ประกาศตัวแปร notifyIcon แทนวัตถุ NotifyIcon
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
                NotifyIcon notifyIcon = new NotifyIcon();
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
        public TimeSpan timeOfDayOld = new TimeSpan(0, 0, 0);
        public void check_time(DateTime s)
        {
            TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
            if (timeOfDayOld.ToString(@"hh\:mm") != timeOfDay.ToString(@"hh\:mm"))
            {
                timeOfDayOld = timeOfDay;
                var day = s.DayOfWeek.ToString();
                var time = new db.Notifications();
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
            else
            {
                name_5.Clear();
            }

        }


        private void Form1_Load(object sender, EventArgs e) // เมื่อ Form นี้เริ่มทำงาน
        {
            this.ShowInTaskbar = true; // กำหนดให้โชว์ใน Taskbar ได้
            timenow.Text = DateTime.Now.ToLongTimeString(); // กำหนดข้อความใน timenow เป็น DateTime.Now.ToLongTimeString() เวลา ณ ขณะนี้
            //check_time(DateTime.Now); // เรียกใช้ check_time โดยใช้ค่า DateTime.Now
        }

        private void ออกจากโปรแกรมToolStripMenuItem_Click(object sender, EventArgs e) // เมื่อคลิก ออกจากโปรแกรม ใน ToolStripMenuItem
        {
            notifyIcon.Visible = false; // ปิดการมองเห็น notifyIcon ในแถบ taskbar
            Environment.Exit(0);// ออกจากโปรแกรม
        }

        private void เกยวกบโปรแกรมToolStripMenuItem_Click(object sender, EventArgs e)  // เมื่อคลิก เกี่ยวกับโปรแกรม ใน ToolStripMenuItem
        {
            about about = new about(); // ประกาศตัวแปร about แทนวัตถุ about
            about.ShowDialog(); // แสดง about
        }

        private void นาฬกานบถอยหลงToolStripMenuItem_Click(object sender, EventArgs e) // เมื่อคลิก นาฬิกานับถอยหลัง ใน ToolStripMenuItem
        {
            Countdown cd = new Countdown(); // ประกาศตัวแปร cd แทนวัตถุ Countdown
            cd.Show(); // แสดง Countdown
        }

        private void add_Click(object sender, EventArgs e) // เมื่อคลิกปุ่ม add
        {
            home a1 = new home(); // ประกาศตัวแปร a1 แทนวัตถุ home
            add_alert a = new add_alert();// ประกาศตัวแปร a แทนวัตถุ add_alert
            a.Show(); // แสดง add_alert
            a1.Close(); // ปิด home
        }

        private void นาฬกาจบเวลาToolStripMenuItem_Click(object sender, EventArgs e) // เมื่อคลิก นาฬิกาจับเวลา ใน ToolStripMenuItem
        {
            Timer_system a = new Timer_system(); // ประกาศตัวแปร a แทนวัตถุ Timer_system
            a.ShowDialog();// แสดง Timer_system
        }

        private void เปดแอพToolStripMenuItem_Click(object sender, EventArgs e) // เมื่อคลิก เปิดแอพ ใน ToolStripMenuItem
        {
            this.ShowInTaskbar = true; // กำหนดให้โชว์ใน Taskbar ได้
            this.Show(); // โชว์ home
           this.WindowState = FormWindowState.Normal; // กำหนดหน้าต่างปกติ
        }

        private void timenow_Click(object sender, EventArgs e)
        {

        }

        private void เพมการแจงเตอนToolStripMenuItem_Click(object sender, EventArgs e) // เมื่อคลิก เพิ่มการแจ้งเตือน ใน ToolStripMenuItem
        {
            add_alert a = new add_alert(); // ประกาศตัวแปร a แทนวัตถุ add_alert
            a.Show(); // แสดง add_alert
        }

        private void นาฬกาจบเวลาToolStripMenuItem1_Click(object sender, EventArgs e) // เมื่อคลิก นาฬิกาจับเวลา ใน ToolStripMenuItem1
        {
            Timer_system a = new Timer_system(); // ประกาศตัวแปร a แทนวัตถุ
            a.Show();
        }

        private void เกยวกบโปรแกรมToolStripMenuItem1_Click(object sender, EventArgs e) // เมื่อคลิก เกี่ยวกับโปรแกรม ใน ToolStripMenuItem1
        {
            about a = new about(); // ประกาศตัวแปร a แทนวัตถุ about
            a.Show(); // แสดง about
        }

        private void นาฬกานบถอยหลงToolStripMenuItem1_Click(object sender, EventArgs e) // เมื่อคลิก นาฬิกานับถอยหลัง ใน ToolStripMenuItem1
        {
            Countdown a = new Countdown(); // ประกาศตัวแปร a แทนวัตถุ Countdown
            a.Show(); // แสดง Countdown
        }

        private void ลบการแจงเตอนToolStripMenuItem_Click(object sender, EventArgs e) // เมื่อคลิก แก้ไขการแจ้งเตือน ใน ToolStripMenuItem
        {
            edit_alert a = new edit_alert(); // ประกาศตัวแปร a แทนวัตถุ edit_alert
            a.Show(); // แสดง edit_alert
        }

        private void เพมการแจงเตอนToolStripMenuItem1_Click(object sender, EventArgs e) // เมื่อคลิก แก้ไขการแจ้งเตือน ใน ToolStripMenuItem1
        {
            add_alert a = new add_alert(); // ประกาศตัวแปร a แทนวัตถุ add_alert
            a.Show(); // แสดง add_alert
        }

        private void แกไขการแจงเตอนToolStripMenuItem_Click(object sender, EventArgs e) // เมื่อคลิก แก้ไขการแจ้งเตือน ใน ToolStripMenuItem
        {
            edit_alert a = new edit_alert(); // ประกาศตัวแปร a แทนวัตถุ edit_alert
            a.Show(); // แสดง edit_alert
        }

        private void ออกจากโปรแกรมToolStripMenuItem1_Click(object sender, EventArgs e) // เมื่อคลิก ออกจากโปรแกรม ใน ToolStripMenuItem1
        {
            notifyIcon.Visible = false; // ปิดการมองเห็น notifyIcon ในแถบ taskbar
            Environment.Exit(0); // ออกจากโปรแกรม
        }
    }
}
