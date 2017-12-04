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
    public partial class add_alert : Form
    {
        public add_alert()
        {
            InitializeComponent();
        }

        private void clean_Click(object sender, EventArgs e)
        {
            h.Refresh();
            m.Refresh();
            note.Text = "";
        }

        private void add_alert_Load(object sender, EventArgs e)
        {
            h.DropDownStyle = ComboBoxStyle.DropDownList; // ล็อค ไม่ให้กรอกข้อความได้
            m.DropDownStyle = ComboBoxStyle.DropDownList; // ล็อค ไม่ให้กรอกข้อความได้
        }
    }
}
