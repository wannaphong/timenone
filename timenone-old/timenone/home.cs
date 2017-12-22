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
            
        }
        Point mousedownpoint = Point.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            

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
        private void r(RadioButton a,RadioButton b, RadioButton c , RadioButton d)
        {
           int aa, bb, cc, dd;
            int aa1, bb1, cc1, dd1;

            aa = a.Location.Y;
            bb = b.Location.Y;
            cc = c.Location.Y;
            dd = d.Location.Y;
            aa1 = a.Location.X;
            bb1 = b.Location.X;
            cc1 = c.Location.X;
            dd1 = d.Location.X;
            a.Left = bb;
            b.Left = aa;
            c.Left = dd;
            d.Left = cc;
            a.Top = aa1;
            b.Top = bb1;
            c.Top = cc1;
            d.Top = dd1;
        }
        private void index_Click(object sender, EventArgs e)
        {
            //SidePanel.Height =index.Height;
            SidePanel.Top = index.Top;
        }

        private void opencountdown_Click(object sender, EventArgs e)
        {
            //SidePanel.Height = index.Height;
            SidePanel.Top = index.Top;

            button8.Left =opencountdown.Location.X;
            string a = "5";
            Math.Round(Convert.ToDouble((double.Parse(a.ToString()) / 30) * 100), 2);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            r(radioButton1, radioButton2, radioButton3, radioButton4);
        }
    }
}
