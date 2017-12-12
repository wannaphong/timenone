using System;
using System.Windows.Forms;

namespace timenone
{
    public partial class Countdown : Form
    {
        public static double settime=0;
        public static bool run = false;
        public Countdown()
        {
            InitializeComponent();
        }
        
        private void Countdown_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (run!=false && settime>0) // กรณี run ไม่เป็น false และ settime มากกว่า 0
            {
                settime--; // ให้ลบค่า 1 ค่าใน settime
                label2.Text = new DateTime().AddSeconds(settime).ToString("HH:mm:ss"); // นำ settime ซึ่งเป็นวินาที มาแปลงเป็น string เป็น ชั่วโมง:นาที:วินาที
                if (settime == 0) // กรณี settime เท่ากับ 0
                {
                    button1.Text = "เริ่มใหม่"; // ให้ข้อความใน button1 เป็น "เริ่มใหม่"
                    timer1.Stop(); // ให้หยุดการทำงาน timer1
                    run = false; // ให้ run เป็น false
                    timer1.Enabled = false; // ให้ปิดการใช้งาน timer1
                }
            }
            else // กรณีไม่เข้าเงื่อนไขข้างบน
            {
                label2.Text = "00:00:00"; //ให้ข้อความของ label2 เป็น  "00:00:00"
                run = false; // ให้ run เป็น false
            }
        }
        private void button1_Click(object sender, EventArgs e) // เมื่อคลิก button1
        {
            run = true; // ให้ run เป็น true
            if (settime != 0) // ถ้า settime ไม่เป็น 0
            {
                button1.Text = "กำลังนับถอยหลัง..."; // ให้ข้อความใน button1 เป็น "กำลังนับถอยหลัง..."
                timer1.Enabled = true; // ให้เปิดการใช้งาน timer1
                timer1.Start(); // ให้เริ่มการทำงาน timer1
            }
            else // กรณีไม่เข้าเงื่อนไขข้างบน
            {
                label2.Text = "00:00:00";// ให้ข้อความของ label2 เป็น "00:00:00"
                MessageBox.Show("กรุณาตั้งค่าเวลานับถอยหลัง");// ขึ้น MessageBox โดยมีข้อความ "กรุณาตั้งค่าเวลานับถอยหลัง"
            }
           
        }

        private void button2_Click(object sender, EventArgs e) // เมื่อคลิก button2 หรือปุ่ม ยกเลิก
        {
            label2.Text = "00:00:00"; // ให้ข้อความของ label2 เป็น "00:00:00"
            timer1.Stop(); // ให้หยุดการทำงาน timer1
            settime = 0; // ให้ settime เป็น 0
            run = false; // ให้ run เป็น false
        }

        private void button3_Click(object sender, EventArgs e) // เมื่อคลิก button3 หรือ ปุ่ม ตั้งค่าเวลา
        {
            set_time_countdown settimebox = new set_time_countdown(); // ประกาศตัวแปร settimebox แทน set_time_countdown
            settimebox.ShowDialog(); // แสดง set_time_countdown
        }
    }
}
