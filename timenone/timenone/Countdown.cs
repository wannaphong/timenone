using swxben.Windows.Forms.Dialogs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace timenone
{
    public partial class Countdown : Form
    {
        public static double settime=0; // ประกาศตัวแปรชื่อ settime ชนิด double เป็น public และเป็น static
        public double last_time;//เส้นตาย
        public static bool run = false; // ประกาศตัวแปรชื่อ run ชนิด bool เป็น public และเป็น static
        public Countdown()
        {
            InitializeComponent();
        }
        
        private void Countdown_Load(object sender, EventArgs e)
        {

        }
        bool ok2 = true;
        private void timer1_Tick(object sender, EventArgs e) // กรณี timer1 มีเลื่อนเวลา
        {
            if (run!=false && settime>0) // กรณี run ไม่เป็น false และ settime มากกว่า 0
            {
                settime--; // ให้ลบค่า 1 ค่าใน settime
                label2.Text = new DateTime().AddSeconds(settime).ToString("HH:mm:ss"); // นำ settime ซึ่งเป็นวินาที มาแปลงเป็น string เป็น ชั่วโมง:นาที:วินาที
                if (settime <= last_time)
                {
                    if (ok2 == true)
                    {
                        label2.BackColor = Color.Red;
                        ok2 = false;
                    }
                    else
                    {
                        label2.BackColor = Color.White;
                        ok2 = true;
                    }
                }
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
            button1.Text = "นับถอยหลัง";
        }

        private void button3_Click(object sender, EventArgs e) // เมื่อคลิก button3 หรือ ปุ่ม ตั้งค่าเวลา
        {
            this.Hide(); // ซ่อนหน้าต่าง
            set_time_countdown settimebox = new set_time_countdown(); // ประกาศตัวแปร settimebox แทน set_time_countdown
            settimebox.ShowDialog(); // แสดง set_time_countdown
        }

        private void buOK_Click(object sender, EventArgs e)
        {
            settime = 0; // กำหนดค่า settime ใน Countdown ให้เป็น 0 เป็นค่าเริ่มต้น
            if (m.Text == "" && s.Text == "") MessageBox.Show("กรุณากรอกข้อมูล"); // เช็คกรณีที่ข้อมูลใน m และ s ว่างเปล่า ให้ขึ้น MessageBox ให้โชว์ "กรุณากรอกข้อมูล"
            else // กรณีไม่เข้าเงื่อนไขข้างบน
            {
                if (m.Text == "") m.Text = "0"; // ถ้า m ว่างเปล่าให้มีค่าเป็น "0"
                else if (s.Text == "") s.Text = "0"; // ถ้า s ว่างเปล่าให้มีค่าเป็น "0"
                string mm, ss;
                settime = int.Parse(m.Text) * 60 + int.Parse(s.Text); // กำหนดค่า settime ใน Countdown ให้เป็นเวลาวินาที นำค่านาทีของ m มาคูณ 60 แล้วบวกกับวินาทีของตัวแปร s
                if (int.Parse(m.Text) > 9)
                {
                    mm = m.Text.ToString();
                }
                else
                {
                    mm="0"+ m.Text.ToString();
                }
                if (int.Parse(s.Text) > 9)
                {
                    ss = s.Text.ToString();
                }
                else
                {
                    ss = "0" + s.Text.ToString();
                }
                label2.Text = mm + ":" + ss;
                MessageBox.Show("เวลาที่จะนับถอยหลัง : " + (Countdown.settime).ToString() + " วินาที"); // ให้ขึ้น MessageBox โชว์วินาทีที่กำหนด
                run = true; // ให้ run เป็น true
                // ส่วนกำหนดเวลาเส้นตาย
                DialogResult dialogResult = MessageBox.Show("คุณต้องการตั้งค่าเวลาเส้นตายใช่หรือไม่", "ตั้งค่าเวลาแจ้งเตือนก่อนเส้นตาย", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var prompt = new TextPromptDialog("ตั้งค่านาทีเส้นตาย :", "นาทีเส้นตาย", "");
                    prompt.ShowDialog();
                    if (prompt.Value != ""){
                        if (tools.check_num(prompt.Value) == false) // เรียกใช้ tools.check_num() ให้กับเช็คว่าเป็นตัวเลขหรือไม่ ถ้าไม่
                        {
                            prompt.Value = "0";
                        }
                    }
                    else
                    {
                        prompt.Value = "0";
                    }
                    var prompt2 = new TextPromptDialog("ตั้งค่าวินาทีเส้นตาย :", "วินาทีเส้นตาย", "");
                    prompt2.ShowDialog();
                    if (prompt2.Value != "")
                    {
                        if (tools.check_num(prompt2.Value) == false) // เรียกใช้ tools.check_num() ให้กับเช็คว่าเป็นตัวเลขหรือไม่ ถ้าไม่
                        {
                            prompt2.Value = "0";
                        }
                    }
                    else
                    {
                        prompt2.Value = "0";
                    }
                    last_time = double.Parse(prompt.Value) * 60 + double.Parse(prompt2.Value);
                }
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
        }

        private void m_TextChanged(object sender, EventArgs e)
        {
            if (tools.check_num(m.Text) == false) // เรียกใช้ tools.check_num() ให้กับเช็คว่าเป็นตัวเลขหรือไม่ ถ้าไม่
            {
                MessageBox.Show("กรูณากรอกตัวเลขเท่านั้น"); // ขึ้น MessageBox ให้โชว์ "กรูณากรอกตัวเลขเท่านั้น"
            }
        }

        private void s_TextChanged(object sender, EventArgs e)
        {
            if (tools.check_num(s.Text) == false) // เรียกใช้ tools.check_num() ให้กับเช็คว่าเป็นตัวเลขหรือไม่ ถ้าไม่
            {
                MessageBox.Show("กรูณากรอกตัวเลขเท่านั้น"); // ขึ้น MessageBox ให้โชว์ "กรูณากรอกตัวเลขเท่านั้น"
            }
        }
    }
}
