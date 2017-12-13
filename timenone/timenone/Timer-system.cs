using System;
using System.Windows.Forms;

namespace timenone
{
    public partial class Timer_system : Form
    {
        bool start = false,P=false; // ประกาศตัวแปรชนิด bool ชื่อ  start และ P โดย start = false ส่วน P=false
        System.Timers.Timer t; // ประกาศตัวแปร t แทนวัตถุ System.Timers.Timer
        int h, m, s,num=1; // ประกาศตัวแปรชนิด int ชื่อ  h, m, s และ num โดย num มีค่าเริ่มต้นเท่ากับ 1
        public Timer_system()
        {
            InitializeComponent();
        }

        private void Timer_system_Load(object sender, EventArgs e) // เมื่อ Form นี้ถูกโหลดขึ้นมา
        {
            t = new System.Timers.Timer(); // ให้ t แทน System.Timers.Timer()
            t.Interval = 1000; // กำหนดช่วงของ t ให้เท่ากับ 1000 มิลลิวินาที หรือ 1 วินาที
            t.Elapsed += OnTimeEvent1;// กำหนด Elapsed ให้เป็นเหตุการณ์ใน OnTimeEvent1
        }

        private void bnStart_Click(object sender, EventArgs e) // กรณีคลิก bnStart
        {
            if (start == false) // ถ้า start เป็น false
            {
                timebox.Text = "";// ให้ข้อความของ timebox ว่างเปล่า
                h = 0; // ให้ h เป้น 0
                m = 0; // ให้ m เป็น 0
                s = 0; // ให้ s เป็น 0
                t.Start(); // ให้เริ่มการทำงานของ t
                bnStart.Text = "หยุด";// ให้ข้อความของ bnStart เป็น "หยุด"
                start = true;//ให้ start เป็น true
            }
            else { // กรณีไม่เข้าเงื่อนไขข้างบน
                t.Stop(); // ให้หยุดการทำงาน t
                start = false; // ให้ start เป็น false
                P = false; // ให้ P เป็น false
                bnP.Text = "หยุดชั่วคราว"; // ให้ข้อความของ bnP เป็น "หยุดชั่วคราว"
                show_time.Text = "00:00:00"; // ให้ข้อความใน show_time เป็น "00:00:00"
                bnStart.Text = "เริ่ม"; // ให้ข้อความของ bnStart เป็น "เริ่ม"
                num = 1; // ให้ num เท่ากับ 1
            }
        }
        private void bnP_Click(object sender, EventArgs e) // เมื่อคลิกปุ่ม bnP
        {
            if (P == false) { // กรณี P เป็น false
                t.Stop(); // ให้หยุดการทำงานของ t
                bnP.Text = "ดำเนินการต่อ"; // เปลี่ยนข้อความของ bnP ให้เป็น ดำเนินการต่อ
                P = true; // ให้ P เป็น True
            }
            else // กรณีไม่เข้าเงื่อนไขข้างบน
            {
                bnP.Text = "หยุดชั่วคราว";// เปลี่ยนข้อความของ bnP ให้เป็น หยุดชั่วคราว
                P = false;// ให้ P เป็น false
                t.Start();// เริ่มการทำงาน t
            }
        }
        private void bnStop_Click(object sender, EventArgs e) // เมื่อคลิกปุ่ม bnStop
        {
            t.Enabled = false; // กำหนดให้ปิดการทำงาน t
            show_time.Text = "00:00:00"; // set ค่าข้อความใน show_time ให้เป็น 00:00:00
        }
        private void time_now_save_Click(object sender, EventArgs e) // เมื่อคลิกปุ่ม time_now_save
        {
            timebox.Text += string.Format("รอบที่ {3} : {0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'),num.ToString())+"\r\n"; //เพิ่มข้อความใน timebox ให้เป็น รอบที่ รอบ : ชั่วโมง:นาที:วินาที โดยให้ข้อมูลมี 2 หลัก เช่น 01 เป็นต้น
            num++; // เพิ่มค่า num อีก 1
        }
        private void OnTimeEvent1(object sender,System.Timers.ElapsedEventArgs e) // ประกาศ method ชื่อ OnTimeEvent1
        {
            Invoke(new Action(() => // ให้เรียกใช้งานการดำเนินการในคำสั่งนี้
            {
                s++; // บวกค่า s เพิ่มอีก 1
                if (s == 60) // ถ้า s เท่ากับ 60
                {
                    s = 0;// ให้ s เท่ากับ 0
                    m++;//เพิ่มค่า m อีก 1
                }
                if (m == 60) // ถ้า m เท่ากับ 60
                {
                    m = 0; // ให้ m เท่ากับ 0
                    h++; // ให้ h เพิ่มค่าอีก 1
                }
                show_time.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0')); //กำหนดข้อความใน show_time ให้เป็น ชั่วโมง:นาที:วินาที โดยให้ข้อมูลมี 2 หลัก เช่น 01 เป็นต้น
            }
            ));
        }
    }
}