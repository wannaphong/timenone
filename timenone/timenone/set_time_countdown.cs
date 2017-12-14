using System;
using System.Windows.Forms;

namespace timenone
{
    public partial class set_time_countdown : Form
    {
        public set_time_countdown()
        {
            InitializeComponent();
        }
        private void buOK_Click(object sender, EventArgs e) { // เมื่อคลิกปุ่ม OK
            Countdown cd = new Countdown(); // ประกาศตัวแปร cd แทน Countdown
            Countdown.settime=0; // กำหนดค่า settime ใน Countdown ให้เป็น 0 เป็นค่าเริ่มต้น
            if (m.Text == "" && s.Text == "") MessageBox.Show("กรุณากรอกข้อมูล"); // เช็คกรณีที่ข้อมูลใน m และ s ว่างเปล่า ให้ขึ้น MessageBox ให้โชว์ "กรุณากรอกข้อมูล"
            else // กรณีไม่เข้าเงื่อนไขข้างบน
            {
                if (m.Text == "") m.Text = "0"; // ถ้า m ว่างเปล่าให้มีค่าเป็น "0"
                else if (s.Text == "") s.Text = "0"; // ถ้า s ว่างเปล่าให้มีค่าเป็น "0"
                Countdown.settime = int.Parse(m.Text) * 60 + int.Parse(s.Text); // กำหนดค่า settime ใน Countdown ให้เป็นเวลาวินาที นำค่านาทีของ m มาคูณ 60 แล้วบวกกับวินาทีของตัวแปร s
                MessageBox.Show("เวลาที่จะนับถอยหลัง : "+(Countdown.settime).ToString()+" วินาที"); // ให้ขึ้น MessageBox โชว์วินาทีที่กำหนด
                this.Hide(); // ให้ซ่อนหน้าต่างนี้
                cd.Show(); // โชว์หน้าต่าง Countdown
            }
        }

        private void set_time_countdown_Load(object sender, EventArgs e)
        {

        }

        private void m_TextChanged(object sender, EventArgs e) // ถ้ามีการเปลี่ยนแปลงข้อความใน m
        {
            if (tools.check_num(m.Text) == false) // เรียกใช้ tools.check_num() ให้กับเช็คว่าเป็นตัวเลขหรือไม่ ถ้าไม่
            {
                MessageBox.Show("กรูณากรอกตัวเลขเท่านั้น"); // ขึ้น MessageBox ให้โชว์ "กรูณากรอกตัวเลขเท่านั้น"
            }
        }

        private void s_TextChanged(object sender, EventArgs e) // ถ้ามีการเปลี่ยนแปลงข้อความใน s
        {
            if (tools.check_num(s.Text) == false) // เรียกใช้ tools.check_num() ให้กับเช็คว่าเป็นตัวเลขหรือไม่ ถ้าไม่
            {
                MessageBox.Show("กรูณากรอกตัวเลขเท่านั้น"); // ขึ้น MessageBox ให้โชว์ "กรูณากรอกตัวเลขเท่านั้น"
            }
        }
    }
}
