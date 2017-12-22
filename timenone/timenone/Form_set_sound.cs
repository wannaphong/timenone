using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timenone
{
    public partial class Form_set_sound : Form
    {
        public string file = "";
        public Form_set_sound()
        {
            InitializeComponent();
        }

        private void select_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string fullPath = openFileDialog1.FileName;
                string fileName = openFileDialog1.SafeFileName;
                string path = fullPath.Replace(fileName, "");
                file = openFileDialog1.FileName;
            }
        }

        private void save_file_Click(object sender, EventArgs e)
        {
            new db().set_sound(file);
            MessageBox.Show("บันทึกเรียบร้อย");
            this.Hide();
        }
    }
}
