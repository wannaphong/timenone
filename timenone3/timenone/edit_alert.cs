using LiteDB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace timenone
{
    public partial class edit_alert : Form
    {
        int ID; // ประกาศตัวแปรข้อมูลชนิด int ชื่อ ID
        string file = new db().file_db().ToString(); // ประกาศตัวแปร file ซึ่งเป็นตัวแปรชนิดข้อมูล string เก็บ file_db() จาก db แล้วแปลงเป็นสตริง
        public edit_alert()
        {
            InitializeComponent();
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) // เมื่อมีการคลิกแถวใดแถวหนึ่งทั้งแถว
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); // ให้นำค่า ID ไปเก็บในตัวแปร ID
        }
        public void DisplayData() // ประกาศ method ชื่อ DisplayData แบบ public โดยไม่มีคืนค่า
        {
            List<MyStruct> list = new List<MyStruct> { }; // ประกาศ List ชื่อ list ใช้เก็บวัตถุของ class ชื่อ MyStruct
            var source = new BindingSource(); // ประกาศ source แทน BindingSource เพื่อสำหรับไว้เพิ่มข้อมูลลงใน dataGridView1
            using (var db2 = new LiteDatabase(file)) // เรียกใช้งานฐานจาก LiteDatabase(ที่ตั้งไฟล์) แล้วเก็บวัตถุไว้ในตัวแปร db2
            {
                var orders = db2.GetCollection<db.Notifications>("Notifications"); // ประกาศตัวแปร orders แทนการประกาศการอ้างอิง Collection ชื่อ Notifications จากฐานข้อมูล

                // ทำการ query กับ Order, เรียกใช้แทนการอ้างอิง
                var query = orders
                    .Include(x => x.Id)
                    .Include(x => x.Title)
                    .Include(x => x.H)
                    .Include(x => x.M)
                    .Include(x => x.IsActive)
                    .Include(x => x.Sunday)
                    .Include(x => x.Monday)
                    .Include(x => x.Tuesday)
                    .Include(x => x.Wednesday)
                    .Include(x => x.Thursday)
                    .Include(x => x.Friday)
                    .Include(x => x.Saturday)
                 .Find(x => x.IsActive == true || x.IsActive == false); // ค้นหาข้อมูล ถ้า IsActive เป็น true หรือ false
                foreach (var c in query) // ลูปข้อมูลทีละตัวใน query เก้บไว้ใน c
                {
                    list.Add(new MyStruct(c.Id, c.Title, c.H, c.M, c.IsActive,c.Sunday,c.Monday,c.Tuesday,c.Wednesday,c.Thursday,c.Friday,c.Saturday)); // เพิ่มข้อมูลลง list
                }
            }
            source.DataSource = list; // กำหนดแหล่งข้อมูลของ source คือ list
            dataGridView1.DataSource = source; // กำหนดแหล่งข้อมูลของ dataGridView1 ให้เป็นตัวแปร source
            dataGridView1.Columns[0].ReadOnly = true; // กำหนดให้ Columns แรก (ID) ให้อ่านได้อย่างเดียว
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // กำหนดให้ปรับขนาด dataGridView1 แบบ Auto

            dataGridView1.BorderStyle = BorderStyle.None; // กำหนด dataGridView1 ไม่มีกรอบ
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249); // กำหนดสี AlternatingRowsDefaultCellStyle ตามรหัส RGB
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // กำหนดรูปแบบกรอบของ Cell ให้เป็นรูปแบบ SingleHorizontal
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise; // กำหนดสีข้างหลังให้เป็นสี DarkTurquoise
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;  // กำหนดสีข้างหน้าให้เป็นสี  WhiteSmoke
            dataGridView1.BackgroundColor = Color.White; // กำหนดสีพื้นหลังใน dataGridView1 เป็น White
            dataGridView1.EnableHeadersVisualStyles = false; // ให้ปิดการทำงาน HeadersVisualStyles
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None; // กำหนดรูปแบบกรอกของหัว Column ให้ว่างเปล่า
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72); // กำหนดสี ColumnHeadersDefaultCellStyle ตามรหัส RGB
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // กำหนดสีหัว Column เป็นสีขาว
        }

        private void edit_alert_Load(object sender, EventArgs e) // เมื่อ Form นี้ถูกโหลดขึ้นมา
        {
            DisplayData(); // เรียกใช้ method ชื่อ DisplayData
        }
        class MyStruct // ประกาศ class ชื่อ MyStruct
        {
            public int ID { get; set; } // ประกาศ ID
            public string Title { get; set; } // ประกาศ Title
            public string H { get; set; } // ประกาศ H
            public string M { get; set; } // ประกาศ M
            public bool IsActive { get; set; } // ประกาศ IsActive
            public bool Sunday { get; set; } // ประกาศ Sunday
            public bool Monday { get; set; } // ประกาศ Monday
            public bool Tuesday { get; set; } // ประกาศ Tuesday
            public bool Wednesday { get; set; } // ประกาศ Wednesday
            public bool Thursday { get; set; } // ประกาศ Thursday
            public bool Friday { get; set; } // ประกาศ Friday
            public bool Saturday { get; set; } // ประกาศ Saturday

            public MyStruct(int Id, string title, string h, string m, bool isActive,bool sunday,bool monday,bool tuesday,bool wednesday,bool thursday,bool friday,bool saturday) // ประกาศ method ชื่อ  MyStruct ชื่อเดียวกับ class ที่ประกาศ
            {
                ID = Id; // ให้ ID = Id
                Title = title; // ให้ Title = title
                H = h; // ให้ H = h
                M = m; // ให้ M = m
                IsActive = isActive; // ให้ IsActive = isActive
                Sunday = sunday; // ให้ Sunday = sunday
                Monday = monday; // ให้ Monday = monday
                Tuesday = tuesday; // ให้ Tuesday = tuesday
                Wednesday = wednesday; // ให้ Wednesday = wednesday
                Thursday = thursday; // ให้ Thursday = thursday
                Friday = friday; // ให้ Friday = friday
                Saturday = saturday; // ให้ Saturday = saturday
            }
        }

        private void update_Click(object sender, EventArgs e) // เมื่อกดปุ่ม update
        {
            using (var db2 = new LiteDatabase(file)) // เรียกใช้งานฐานจาก LiteDatabase(ที่ตั้งไฟล์) แล้วเก็บวัตถุไว้ในตัวแปร db2
            {
                foreach (DataGridViewRow row in dataGridView1.Rows) // ลูปข้อมูลจาก dataGridView1.Rows ทีละตัวเก็บไว้ใน row
                {
                    var productsDb = db2.GetCollection<db.Notifications>("Notifications"); // ประกาศตัวแปร productsDb แทนการประกาศการอ้างอิง Collection ชื่อ Notifications จากฐานข้อมูล
                    var productToUpdate = productsDb.Find(p => p.Id == int.Parse(row.Cells[0].Value.ToString())).First(); // ค้นหาและดึงข้อมูลโดยอ้างอิงตาม ID แล้วเก็บข้อมูลไว้ใน productToUpdate
                    productToUpdate.Title = row.Cells[1].Value.ToString(); // Title
                    productToUpdate.H= row.Cells[2].Value.ToString(); // H
                    productToUpdate.M=row.Cells[3].Value.ToString();// M
                    productToUpdate.IsActive= bool.Parse(row.Cells[4].Value.ToString()); // IsActive
                    productToUpdate.Sunday = bool.Parse(row.Cells[5].Value.ToString());// Sunday
                    productToUpdate.Monday = bool.Parse(row.Cells[6].Value.ToString());// Monday
                    productToUpdate.Tuesday = bool.Parse(row.Cells[7].Value.ToString());// Tuesday
                    productToUpdate.Wednesday = bool.Parse(row.Cells[8].Value.ToString());// Wednesday
                    productToUpdate.Thursday = bool.Parse(row.Cells[9].Value.ToString()); //Thursday
                    productToUpdate.Friday = bool.Parse(row.Cells[10].Value.ToString());//Friday
                    productToUpdate.Saturday = bool.Parse(row.Cells[11].Value.ToString());//Saturday
                    productsDb.Update(productToUpdate); // อัพเดตข้อมูล
                }
                MessageBox.Show("อัพเดตข้อมูลเรียบร้อย"); // โชว์ MessageBox ว่า "อัพเดตข้อมูลเรียบร้อย"
                DisplayData(); // เรียกใช้ method ชื่อ DisplayData
            }
        }

        private void del_Click(object sender, EventArgs e) // เมื่อคลิกปุ่ม del
        {
            using (var db2 = new LiteDatabase(file)) // เรียกใช้ฐานข้อมูล LiteDatabase โดยใช้ path ที่ได้จากตัวแปร file
            {
                var orders = db2.GetCollection<db.Notifications>("Notifications"); // ประกาศตัวแปร orders แทนการประกาศการอ้างอิง Collection ชื่อ Notifications จากฐานข้อมูล

                // ทำการ query กับ Order, เรียกใช้แทนการอ้างอิง
                var query = orders
                    .Include(x => x.IsActive)
                 .Find(x => x.IsActive == true || x.IsActive == false); // ค้นหาข้อมูล IsActive ถ้าเป็น true หรือ false
                orders.Delete(Query.EQ("_id", ID)); // ลบข้อมูลตาม ID ที่อ้างอิง
            }
            DisplayData(); // เรียกใช้ method ชื่อ DisplayData
        }

        private void add_alert_bn_Click(object sender, EventArgs e) // เมื่อคลิกปุ่ม
        {
            add_alert a = new add_alert(); // ประกาศตัวแปร a แทนวัตถุ add_alert
            a.ShowDialog(); // กำหนดให้โชว์แบบ ShowDialog คือ โชว์ได้หน้าต่างเดียวและใช้งานโปรแกรมได้เฉพาะหน้าต่างที่โชว์อยู่
            DisplayData(); // เรียกใช้ method ชื่อ DisplayData
        }
    }
}