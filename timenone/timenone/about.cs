using System;
using System.Windows.Forms;

namespace timenone
{
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
        }

        private void about_Load(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/wannaphongcom/timenone"); // เปิดหน้าเว็บ
        }
    }
}
