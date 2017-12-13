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
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            firstCustomControl1.BringToFront();
        }
        Point mousedownpoint = Point.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            firstCustomControl1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            mySecondCustmControl1.BringToFront();

            //Thanks for watching Friends...
            //Please dont forget to Subscribe... :) :) :) 
        }
        
        private void home_Load(object sender, EventArgs e)
        {

        }
        // ย้ายหน้าต่าง
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void home_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void home_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void home_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void index_Click(object sender, EventArgs e)
        {
            //SidePanel.Height =index.Height;
            SidePanel.Top = index.Top;
            firstCustomControl1.BringToFront();
        }

        private void opencountdown_Click(object sender, EventArgs e)
        {
            //SidePanel.Height = index.Height;
            SidePanel.Top = index.Top;
            mySecondCustmControl1.BringToFront();
        }
    }
}
