using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class edit_alert : Form
    {
        int ID;
        string file = new db().file_db().ToString();
        public edit_alert()
        {
            InitializeComponent();
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }
        public void DisplayData()
        {
            
            List<MyStruct> list = new List<MyStruct> { };
            var source = new BindingSource();
            using (var db2 = new LiteDatabase(file))
            {
                var orders = db2.GetCollection<db.Notifications>("Notifications");

                // When query Order, includes references
                var query = orders//.Include(S => timeOfDay.Seconds.ToString())
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
            dataGridView1.DataSource = source;
            dataGridView1.Columns[0].ReadOnly = true;
        }

        private void edit_alert_Load(object sender, EventArgs e)
        {
           // update.Visible = false;
            DisplayData();
        }
        class MyStruct
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
            using (var db2 = new LiteDatabase(file))
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
            DisplayData();
        }

        private void add_alert_bn_Click(object sender, EventArgs e)
        {
            add_alert a = new add_alert();
            a.ShowDialog();
            DisplayData();
        }
    }
}
