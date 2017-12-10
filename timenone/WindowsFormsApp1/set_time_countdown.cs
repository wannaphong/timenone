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
    public partial class set_time_countdown : Form
    {
        public set_time_countdown()
        {
            InitializeComponent();
        }
        private void buOK_Click(object sender, EventArgs e) {
            Countdown.settime=0;
            if (m.Text == "" && s.Text == "") MessageBox.Show("กรุณากรอกข้อมูล");
            else
            {
                if (m.Text == "") m.Text = "0";
                else if (s.Text == "") s.Text = "0";
                Countdown.settime = int.Parse(m.Text) * 60 + int.Parse(s.Text);
               // MessageBox.Show((TimeSpan.FromMinutes(int.Parse(m.Text)).TotalMilliseconds + TimeSpan.FromSeconds(int.Parse(s.Text)).TotalMilliseconds).ToString());
            }
        }

        private void set_time_countdown_Load(object sender, EventArgs e)
        {

        }

        private void m_TextChanged(object sender, EventArgs e)
        {
            if (tools.check_num(m.Text) == false)
            {
                MessageBox.Show("กรูณากรอกตัวเลขเท่านั้น");
            }
        }

        private void s_TextChanged(object sender, EventArgs e)
        {
            if (tools.check_num(s.Text) == false)
            {
                MessageBox.Show("กรูณากรอกตัวเลขเท่านั้น");
            }
        }
    }
}
