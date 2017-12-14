using LiteDB; // เรียกใช้ LiteDB ซึ่งเป็นไลบารีฐานข้อมูล
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace timenone
{
    public partial class home : Form
    {
        string file = "",now; // ประกาศตัวแปร file และ now เป็นข้อมูลชนิด string โดย file มีค่าเริ่มต้นว่างเปล่า
        Task task1=null; // ประกาศตัวแปร task1 เป็นวัตถุ Task โดยมีค่าเริ่มต้น null
        public home()
        {
            var db = new db(); // ประกาศตัวแปร db แทนวัตถุ db
            file = new db().file_db().ToString(); // ดึงข้อมูลจาก db().file_db() แล้วเก็บไว้ใน file
            InitializeComponent();
            timer1.Start(); // ให้เริ่มต้นการทำงาน timer1
        }
        private void Form1_Resize(object sender, EventArgs e) // เมื่อ Form นี้มีการปรับขนาด
        {
            if (WindowState == FormWindowState.Minimized) // ถ้ากดปุ่มย่อหน้าจอ
            {
                this.ShowInTaskbar = false; // กำหนดไม่ให้โชว์ใน Taskbar
                this.Hide(); // ซ่อน Form นี้
            }
        }
        private void notifyIcon_Click(object sender, EventArgs e) // เมื่อคลิก notifyIcon
        {
            this.Show(); // ให้โชว์หน้าต่าง
            this.WindowState = FormWindowState.Normal; // ให้หน้าต่างปกติ
        }
        private void timer1_Tick(object sender, EventArgs e) // เหตุการณ์เมื่อ timer1 มีการขยับเวลา
        {
            DateTime timenow1 = DateTime.Now; // ประกาศตัวแปร timenow1 แทน DateTime.Now
            timenow.Text = timenow1.ToString("HH:mm:ss"); // ให้แปลง timenow1 เป็น ชั่วโมง:นาที:วินาที แล้วนำไปแสดงผลที่ timenow
            now = timenow1.ToString("HH:mm");// ให้แปลง timenow1 เป็น ชั่วโมง:นาที แล้วเก็บไว้ใน now
            this.Text = "ขณะนี้เป็นเวลา "+ timenow1.ToString("HH:mm:ss"); // แสดงที่ข้อมูลที่ชื่อโปรแกรมโดยเป็น "ขณะนี้เป็นเวลา " ตามด้วย ชั่วโมง:นาที:วินาที
            day_time.Text = DateTime.Now.ToString("d/M/yyyy"); // ให้โชว์ วัน/เดือน/ปี ใน day_time
            try // ทดลองโค้ด
            {
                
                        task1 = Task.Factory.StartNew(() => check_time(timenow1)); // ให้รัน method check_time() อีก thread หนึ่ง
                
            }
            catch(Exception x) // ถ้า error ให้เก็บรายละเอียดไว้ใน e
            {
                MessageBox.Show(x.ToString()); // แสดง MessageBox โชว์รายละเอียดที่ error
            }
        }
        TimeSpan timeold= DateTime.Now.TimeOfDay; // ประกาศตัวแปร timeold แทนวัตถุ DateTime.Now.TimeOfDay
        List<string> name_5=new List<string> (); // ประกาศตัวแปร name_5 เป็นข้อมูลชนิด List<string>
        public bool Check_Notifications(TimeSpan timeinday, string name) // ประกาศ method ชื่อ Check_Notifications โดยรับค่า TimeSpan และ string ใช้เช็คการแจ้งเตือน
        {
            bool v = true; // ประกาศตัวแปร v เป็นข้อมูลชนิด bool มีค่าเริ่มต้นเป็น true
            if ((timeold.TotalSeconds == timeinday.TotalSeconds) != false) // กรณีที่เวลา timeold ไม่เท่ากับ timeinday
            {
                timeold = timeinday; // ให้ timeold เก็บค่า  timeinday
                name_5 = new List<string>(); // ให้แทนที่ข้อมูล name_5 ด้วย List<string>()
                v = true; // ให้ v เป็น true
            }
            else // กรณีไม่เข้าเงื่อนไขข้างบน
            {
                if (name_5.ToArray().Length != 0) // ถ้า name_5 พอแปลงเป็น Array ยาวไม่เท่ากับ 0
                {
                    int i = 0; // ประกาศตัวแปร i เป็นข้อมูลชนิด int มีค่าเริ่มต้น 0
                    string[] name_51 = name_5.ToArray();// name_5 พอแปลงเป็น Array แล้วเก็บไว้ใน name_51
                    while (i < name_51.Length) // ถ้า i น้อยกว่าความยาวของ name_51
                    {
                        if (name_51[i] == name) // ถ้า name_51 ที่ i เท่ากับ name
                        {
                            v = false; // ให้ v เป็น false
                            break; // ออกจากการลูป
                        }
                        i++; // เพิ่มค่า i อีก 1
                    }
                    name_5.Add(name); // เพิ่มข้อมูลลงใน name_5
                }
                else // กรณีไม่เข้าเงื่อนไขข้างบน
                {
                    v = true; // ให้ v เป็น true
                    name_5.Add(name); // เพิ่มข้อมูลลงใน name_5
                }
            }
            return v; // คืนค่า v
        }
        static string[] SplitWords(string s,string rule) // ประกาศ method ชื่อ SplitWords เป็น static โดยมีการรับค่าสตริง 2 ค่า คือ s และ rule
        {
            return Regex.Split(s, rule); // ใช้ Regex ในการแบ่งข้อความด้วยคำสั่ง Regex.Split โดย s คือ ข้อความ ส่วน rule คือ กฎในการแบ่งข้อความ
        }
        private void show_Notifications(TimeSpan timeinday, string name) // ประกาศ method ชื่อ show_Notifications โดยไม่มีการคืนค่ากลับ โดยรับข้อมูล TimeSpan timeinday และ string name
        {
            if (Check_Notifications(timeinday, name) == true) // เรียกใช้ method ชื่อ Check_Notifications โดยส่งข้อมูล timeinday และ name คืนค่า boolean แล้วเช็คว่าเป็น true หรือไม่ ถ้าเป็น ให้ทำตามคำสั่งในนี้
            {
                string[] list = SplitWords(name, @",code123 "); // เรียกใช้ method SplitWords ในการแบ่งข้อความ เป็น string[] เก็บไว้ใน list
                string[] list2 = SplitWords(name, @",code123none "); // เรียกใช้ method SplitWords ในการแบ่งข้อความ เป็น string[] เก็บไว้ใน list2
                string code = "";// ประกาศตัวแปร code ชนิดข้อมูล string มีค่าเริ่มต้นเป็น ""
                if (list.Length == 2 || list2.Length == 2) // ถ้า list ยาวเท่ากับ 2 หรือ list2 ยาวเท่ากับ 2
                {
                    if (list2.Length == 2) // ถ้า list2 ยาวเท่ากับ 2
                    {
                        Process proc = new Process(); // ประกาศตัวแปร proc แทนวัตถุ Process
                        proc.StartInfo.FileName = "CMD.exe"; // กำหนดไฟล์คำสั่งที่จะทำงาน คือ CMD
                        proc.StartInfo.Arguments = "/c " + list2[1]; // กำหนดคำสั่งสำหรับสั่งงาน
                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;  // ให้ซ่อนหน้าต่างการทำงาน
                        proc.Start(); // ให้เริ่มการทำงาน proc
                        name = list2[0]; // ให้ name เก็บ list2[0]
                        code = list2[1];// ให้ code เก็บ list2[1]
                    }
                    else if (list.Length == 2) // ถ้า list ยาวเท่ากับ 2
                    {
                        string strCmdText = "/c " + list[1];// กำหนดคำสั่งสำหรับสั่งงาน
                        Process.Start("CMD.exe", strCmdText); // สั่งงาน
                        name = list[0]; // ให้ name เก็บ list2[0]
                        code = list[1];// ให้ code เก็บ list2[1]
                    }
                    name += "\r\n" + "คำสั่งพิเศษ : " + code; // เพิ่ม "คำสั่งพิเศษ :  code" เข้าไปใน name
                }
                String timenow = new DateTime(timeinday.Ticks).ToString("HH:mm"); // แปลงเวลาจาก timeinday.Ticks ให้เป็น string ชั่วโมง:นาที แล้วเก็บไว้ในตัวแปร timenow ซึ่งเป็นตัวแปรชนิด string
                NotifyIcon notifyIcon2 = new NotifyIcon(); // ประกาศตัวแปร notifyIcon แทนวัตถุ NotifyIcon
                notifyIcon2.Icon = new System.Drawing.Icon(Application.StartupPath+ @"\fzap_clock_sportstudio_design_Xaa_icon.ico"); // กำหนด Icon ที่จะแสดงของ notifyIcon
                notifyIcon2.Text = "แจ้งเตือนเวลา " + timenow + " น."; // ให้ข้อความใน notifyIcon เป็น แจ้งเตือนเวลา ...
                notifyIcon2.Visible = true; // เปิดการมองเห็นของ notifyIcon
                notifyIcon2.ShowBalloonTip(16000, "แจ้งเตือนเวลา " + timenow + " น.", name, ToolTipIcon.Warning); // ให้แสดง notifyIcon โดยโชว์ข้อมูล แจ้งเตือนเวลา ... แบบ Warning โดยโชว์เป็นเวลา 16000 มิลลิวินาที
               
                SoundPlayer my_wave_file = new SoundPlayer(Application.StartupPath + @"\funky-breakbeat_102bpm_F_major.wav"); // กำหนด path ที่จะเล่นไฟล์เสียงแจ้งเตือน
                my_wave_file.PlaySync(); // ให้เล่นไฟล์เสียง
                MessageBox.Show(name, "แจ้งเตือนเวลา " + timenow + " น.", MessageBoxButtons.OK, MessageBoxIcon.Warning); // โชว์ MessageBox ขึ้น  แจ้งเตือนเวลา ...
                notifyIcon2.Dispose(); // ปิดการทำงาน notifyIcon2
                task1.Dispose();// ทิ้งข้อมูล task1
            }
        }
        public TimeSpan timeOfDayOld = new TimeSpan(0, 0, 0); // ประกาศตัวแปร timeOfDayOld เป็นข้อมูลชนิด TimeSpan โดยเก็บข้อมูล TimeSpan เวลา 00:00:00
        public void check_time(DateTime s) // ประกาศ method ชื่อ check_time โดยรับข้อมูล DateTime
        {
            TimeSpan timeOfDay = DateTime.Now.TimeOfDay; // ประกาศตัวแปร timeOfDay แทน DateTime.Now.TimeOfDay
           if (timeOfDayOld.ToString(@"hh\:mm") != timeOfDay.ToString(@"hh\:mm")) // ให้เปรียบเทียบ timeOfDayOld กับ timeOfDay ถ้าไม่เท่ากัน
            {
                timeOfDayOld = timeOfDay; // ให้ timeOfDayOld เท่ากับ  timeOfDay
                var day = s.DayOfWeek.ToString();// ประกาศตัวแปร day แทน s.DayOfWeek
                var time = new db.Notifications(); // ประกาศตัวแปร time แทน db.Notifications
                using (var db2 = new LiteDatabase(file)) // เรียกใช้ข้อมูลจากฐานข้อมูล
                {
                    var orders = db2.GetCollection<db.Notifications>("Notifications"); // ประกาศตัวแปร orders แทน db.GetCollection<Notifications>("Notifications")

                    // ทำการ query กับ Order, เรียกใช้แทนการอ้างอิง
                    var query = orders
                        .Find(x => x.H == timeOfDay.Hours.ToString() && x.M == timeOfDay.Minutes.ToString()); // ค้นหาข้อมูลถ้า H ตรงกับ timeOfDay.Hours และ M ตรงกับ timeOfDay.Minutes
                    if (query.ToArray().Length != 0) // ถ้า query.ToArray() แล้วยาวไม่เท่ากับ 0
                    {
                        foreach (var order in query) // ลูป query ทีละตัวเก็บไว้ใน order
                        {
                            if (order.IsActive == true) // ถ้า IsActive เป็น true
                            {
                                switch (day) // เช็คเงื่อนไขวันโดยใช้ตัวแปร day ด้วย switch case
                                {
                                    case "Sunday": // กรณีเป็นวันอาทิตย์
                                        if (order.Sunday == true) show_Notifications(timeOfDay, order.Title); // ถ้า order.Sunday เป็นจริง (คือเปิดใช้งาน) ให้ใช้ method  show_Notifications ส่งค่า timeOfDay, order.Title
                                        break; // ออก
                                    case "Monday": // กรณีเป็นวันจันทร์
                                        if (order.Monday == true) show_Notifications(timeOfDay, order.Title);// ถ้า order.Monday เป็นจริง (คือเปิดใช้งาน) ให้ใช้ method  show_Notifications ส่งค่า timeOfDay, order.Title
                                        break;// ออก
                                    case "Tuesday": // กรณีเป็นวันอังคาร
                                        if (order.Tuesday == true) show_Notifications(timeOfDay, order.Title);// ถ้า order.Tuesday เป็นจริง (คือเปิดใช้งาน) ให้ใช้ method  show_Notifications ส่งค่า timeOfDay, order.Title
                                        break;// ออก
                                    case "Wednesday": // กรณีเป็นวันพุธ
                                        if (order.Wednesday == true) show_Notifications(timeOfDay, order.Title);// ถ้า order.Wednesday เป็นจริง (คือเปิดใช้งาน) ให้ใช้ method  show_Notifications ส่งค่า timeOfDay, order.Title
                                        break;// ออก
                                    case "Thursday":// กรณีเป็นวันพฤหัสบดี
                                        if (order.Thursday == true) show_Notifications(timeOfDay, order.Title);// ถ้า order.Thursday เป็นจริง (คือเปิดใช้งาน) ให้ใช้ method  show_Notifications ส่งค่า timeOfDay, order.Title
                                        break;// ออก
                                    case "Friday":// กรณีเป็นวันศุกร์
                                        if (order.Friday == true) show_Notifications(timeOfDay, order.Title);// ถ้า order.Friday เป็นจริง (คือเปิดใช้งาน) ให้ใช้ method  show_Notifications ส่งค่า timeOfDay, order.Title
                                        break;// ออก
                                    case "Saturday":// กรณีเป็นวันเสาร์
                                        if (order.Saturday == true) show_Notifications(timeOfDay, order.Title);// ถ้า order.Saturday เป็นจริง (คือเปิดใช้งาน) ให้ใช้ method  show_Notifications ส่งค่า timeOfDay, order.Title
                                        break;// ออก
                                }
                            }
                        }
                    }
                }
            }
            else // กรณีไม่เข้าเงื่อนไขข้างบน
            {
                name_5.Clear(); // ล้างข้อมูลใน name_5*
                
            }
        }


        private void Form1_Load(object sender, EventArgs e) // เมื่อ Form นี้เริ่มทำงาน
        {
            this.ShowInTaskbar = true; // กำหนดให้โชว์ใน Taskbar ได้
            timenow.Text = DateTime.Now.ToLongTimeString(); // กำหนดข้อความใน timenow เป็น DateTime.Now.ToLongTimeString() เวลา ณ ขณะนี้
        }

        private void ออกจากโปรแกรมToolStripMenuItem_Click(object sender, EventArgs e) // เมื่อคลิก ออกจากโปรแกรม ใน ToolStripMenuItem
        {
            notifyIcon1.Visible = false; // ปิดการมองเห็น notifyIcon ในแถบ taskbar
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
            a.Show();// แสดง Timer_system
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
            notifyIcon1.Visible = false; // ปิดการมองเห็น notifyIcon ในแถบ taskbar
            Environment.Exit(0); // ออกจากโปรแกรม
        }
    }
}