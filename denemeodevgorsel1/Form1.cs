using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace denemeodevgorsel1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }
        Graphics g;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen = SystemPens.ControlText;

        private void button1_Click(object sender, EventArgs e)
        {
         

            {
                Graphics gr = this.CreateGraphics();
                gr.DrawRectangle(new Pen(Color.Green), new Rectangle(200, 50, 126, 112));
            }

        }




        private void button2_Click_1(object sender, EventArgs e)
        {
            
                Graphics gr = this.CreateGraphics();

                string drawString = "Brush komutu kullanılıyor.";

                Font drawFont = new Font("Comic Sans MS", 20, FontStyle.Bold | FontStyle.Italic);

                SolidBrush drawBrush = new SolidBrush(Color.Blue);

                gr.DrawString(drawString, drawFont, drawBrush, 180, 200);

                drawFont.Dispose();
                drawBrush.Dispose();
                gr.Dispose();
           
        }

        private void kalemrengisec(object sender, EventArgs e)
        {
            pen = new Pen(Color.Black, 1);
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
                pen.Color = c.Color;

            var b = sender as Button;
            b.BackColor = pen.Color;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
            panel1.Cursor = Cursors.Cross;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving && x!=-1 & y != -1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
            panel1.Cursor = Cursors.Default;
        }
    }
}
