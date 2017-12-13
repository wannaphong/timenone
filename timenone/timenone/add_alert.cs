using System;
using System.Windows.Forms;

namespace timenone
{
    public partial class add_alert : Form
    {
        
        public add_alert()
        {
            InitializeComponent();
         }

        private void clean_Click(object sender, EventArgs e) // เมื่อคลิกปุ่ม clean
        {
            h.SelectedIndex = 0; // ให้ h เลือกที่ 0
            m.SelectedIndex = 0; // ให้ m เลือกที่ 0
            note.Text = ""; // กำหนดให้ข้อความใน note ให้ว่างเปล่า
            foreach (int i in days.CheckedIndices) // ลูปค่าจำนวนใน days แต่ละตัวเลือก
            {
                days.SetItemCheckState(i, CheckState.Unchecked); // ให้ยกเลิกการเลือก
            }
            Enable.Checked = false; // ให้ยกเลิกการเลือกของ Enable
        }
        private void add_alert_Load(object sender, EventArgs e) // เมื่อ Form นี้ถูกโหลดขึ้นมา
        {
            h.SelectedIndex = 0; // ประกาศค่าเริ่มต้นของ h ให้เลือกตำแหน่งที่ 0
            m.SelectedIndex = 0; // ประกาศค่าเริ่มต้นของ m ให้เลือกตำแหน่งที่ 0
            h.DropDownStyle = ComboBoxStyle.DropDownList; // ล็อค ไม่ให้กรอกข้อความได้
            m.DropDownStyle = ComboBoxStyle.DropDownList; // ล็อค ไม่ให้กรอกข้อความได้
        }

        private void save_Click(object sender, EventArgs e) // เมื่อกดปุ่ม save
        {
            var db = new db();
            string[] d = {"วันอาทิตย์","วันจันทร์","วันอังคาร","วันพุธ","วันพฤหัสบดี","วันศุกร์","วันเสาร์"}; // ประกาศ string[] ชื่อ d แทนวันทั้ง 7 วันในภาษาไทย
            bool d1=false, d2 = false, d3 = false, d4 = false, d5 = false, d6 = false, d7 = false; // ประกาศตัวแปรชนิด bool ชื่อ d1 - d7 ให้มีค่าเริ่มต้นเป็น false
            foreach (string item in days.CheckedItems) // ลูปเอาค่า string ทีละตัวจาก days.CheckedItems เก็บไว้ใน item
            {
                int i = 0; // ประกาศตัวแปรชนิด int ชื่อ i มีค่าเริ่มต้นเป็น 0
                while (i < d.Length) // ลูป while ถ้า i น้อยกว่าความยาวของ d
                {
                    if (d[i] == item) // ถ้า d ที่ i เท่ากับ item
                    {
                        if (i == 0) d1 = true; // ถ้า i เท่ากับ 0 ให้ d1 เป็น true
                        else if (i == 1) d2 = true; // ถ้า i เท่ากับ 1 ให้ d2 เป็น true
                        else if (i == 2) d3 = true; // ถ้า i เท่ากับ 2 ให้ d3 เป็น true
                        else if (i == 3) d4 = true; // ถ้า i เท่ากับ 3 ให้ d4 เป็น true
                        else if (i == 4) d5 = true; // ถ้า i เท่ากับ 4 ให้ d5 เป็น true
                        else if (i == 5) d6 = true; // ถ้า i เท่ากับ 5 ให้ d6 เป็น true
                        else if (i == 6) d7 = true; // ถ้า i เท่ากับ 6 ให้ d7 เป็น true
                    }
                    i++; // บวกค่า i เพิ่มขึ้นอีก 1
                }

            }
           db.add_data(note.Text,h.Text,m.Text,d1,d2,d3,d4,d5,d6,d7, Enable.Checked); // เพิ่มข้อมูลลงฐานข้อมูล
           MessageBox.Show("Ok"); // โชว์ MessageBox ว่า "Ok"
        }

        private void open_f1_Click(object sender, EventArgs e) // เมื่อคลิก open_f1
        {
            home h = new home(); // ประกาศตัวแปร h แทนวัตถุ home
            h.Show();// โชว์ home 
        }
    }
}
