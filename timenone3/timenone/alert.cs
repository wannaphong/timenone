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
    public partial class alert : Form
    {
        public static string h = "";
        public static string time = "";
        public alert()
        {
            InitializeComponent();
        }

        private void alert_Load(object sender, EventArgs e)
        {
            timeok.Text = time;
            n.Text = h;
        }
    }
}
