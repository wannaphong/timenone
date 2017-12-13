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
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }
        public void DisplayData() // ประกาศ method ชื่อ DisplayData แบบ public โดยไม่มีคืนค่า
        {
            List<MyStruct> list = new List<MyStruct> { }; // ประกาศ List ชื่อ list ใช้เก็บวัตถุของ class ชื่อ MyStruct
            var source = new BindingSource();
            using (var db2 = new LiteDatabase(file)) // เรียกใช้งานฐานจาก LiteDatabase(ที่ตั้งไฟล์) แล้วเก็บวัตถุไว้ในตัวแปร db2
            {
                var orders = db2.GetCollection<db.Notifications>("Notifications");

                // When query Order, includes references
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
                 .Find(x => x.IsActive == true || x.IsActive == false);
                foreach (var c in query)
                {
                    list.Add(new MyStruct(c.Id, c.Title, c.H, c.M, c.IsActive,c.Sunday,c.Monday,c.Tuesday,c.Wednesday,c.Thursday,c.Friday,c.Saturday));                }
            }
            source.DataSource = list;
            dataGridView1.DataSource = source; // กำหนดแหล่งข้อมูลของ dataGridView1 ให้เป็นตัวแปร source
            dataGridView1.Columns[0].ReadOnly = true; // กำหนดให้ Columns แรก (ID) ให้อ่านได้อย่างเดียว
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // กำหนดให้ปรับขนาด dataGridView1 แบบ Auto

            dataGridView1.BorderStyle = BorderStyle.None; // กำหนด dataGridView1 ไม่มีกรอบ
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White; // กำหนดสีพื้นหลังใน dataGridView1 เป็น White
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // กำหนดสีหัว Column เป็นสีขาว
        }

        private void edit_alert_Load(object sender, EventArgs e) // เมื่อ Form นี้ถูกโหลดขึ้นมา
        {
            DisplayData(); // เรียกใช้ method ชื่อ DisplayData
        }
        class MyStruct // ประกาศ class ชื่อ MyStruct
        {
            public int ID { get; set; }
            public string Title { get; set; }
            public string H { get; set; }
            public string M { get; set; }
            public bool IsActive { get; set; }
            public bool Sunday { get; set; }
            public bool Monday { get; set; }
            public bool Tuesday { get; set; }
            public bool Wednesday { get; set; }
            public bool Thursday { get; set; }
            public bool Friday { get; set; }
            public bool Saturday { get; set; }

            public MyStruct(int Id, string title, string h, string m, bool isActive,bool sunday,bool monday,bool tuesday,bool wednesday,bool thursday,bool friday,bool saturday)
            {
                ID = Id;
                Title = title;
                H = h;
                M = m;
                IsActive = isActive;
                Sunday = sunday;
                Monday = monday;
                Tuesday = tuesday;
                Wednesday = wednesday;
                Thursday = thursday;
                Friday = friday;
                Saturday = saturday;
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            using (var db2 = new LiteDatabase(file)) // เรียกใช้งานฐานจาก LiteDatabase(ที่ตั้งไฟล์) แล้วเก็บวัตถุไว้ในตัวแปร db2
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var productsDb = db2.GetCollection<db.Notifications>("Notifications");
                    var productToUpdate = productsDb.Find(p => p.Id == int.Parse(row.Cells[0].Value.ToString())).First();
                    productToUpdate.Title = row.Cells[1].Value.ToString(); // Title
                    productToUpdate.H= row.Cells[2].Value.ToString();
                    productToUpdate.M=row.Cells[3].Value.ToString();
                    productToUpdate.IsActive= bool.Parse(row.Cells[4].Value.ToString());
                    productToUpdate.Sunday = bool.Parse(row.Cells[5].Value.ToString());
                    productToUpdate.Monday = bool.Parse(row.Cells[6].Value.ToString());
                    productToUpdate.Tuesday = bool.Parse(row.Cells[7].Value.ToString());
                    productToUpdate.Wednesday = bool.Parse(row.Cells[8].Value.ToString());
                    productToUpdate.Thursday = bool.Parse(row.Cells[9].Value.ToString());
                    productToUpdate.Friday = bool.Parse(row.Cells[10].Value.ToString());
                    productToUpdate.Saturday = bool.Parse(row.Cells[11].Value.ToString());
                    productsDb.Update(productToUpdate);
                }
                MessageBox.Show("อัพเดตข้อมูลเรียบร้อย");
                DisplayData(); // เรียกใช้ method ชื่อ DisplayData
            }
        }

        private void del_Click(object sender, EventArgs e)
        {
            using (var db2 = new LiteDatabase(file))
            {
                var orders = db2.GetCollection<db.Notifications>("Notifications");

                // When query Order, includes references
                var query = orders//.Include(S => timeOfDay.Seconds.ToString())
                    .Include(x => x.IsActive)
                 .Find(x => x.IsActive == true || x.IsActive == false);
                orders.Delete(Query.EQ("_id", ID));
            }
            DisplayData(); // เรียกใช้ method ชื่อ DisplayData
        }

        private void add_alert_bn_Click(object sender, EventArgs e)
        {
            add_alert a = new add_alert(); // ประกาศตัวแปร a แทนวัตถุ add_alert
            a.ShowDialog(); // กำหนดให้โชว์แบบ ShowDialog คือ โชว์ได้หน้าต่างเดียวและใช้งานโปรแกรมได้เฉพาะหน้าต่างที่โชว์อยู่
            DisplayData(); // เรียกใช้ method ชื่อ DisplayData
        }
    }
}