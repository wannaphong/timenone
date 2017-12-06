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
            Countdown.settime = TimeSpan.FromMinutes(int.Parse(m.Text)).TotalMilliseconds + TimeSpan.FromSeconds(int.Parse(s.Text)).TotalMilliseconds;
            MessageBox.Show((TimeSpan.FromMinutes(int.Parse(m.Text)).TotalMilliseconds + TimeSpan.FromSeconds(int.Parse(s.Text)).TotalMilliseconds).ToString());
        }

        private void set_time_countdown_Load(object sender, EventArgs e)
        {

        }
    }
}
