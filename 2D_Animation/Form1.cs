using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace _2D_Animation
{

    public partial class Form1 : Form
    {
        static public Point Center;
        static public int d1 = 250, d2 = 100;
        static public double omega = 0.5;
        static public Pen p;
        private double t = 0;
        Graphics g = null;
        bool fl = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(0, menuStrip1.Top + menuStrip1.Height);
            pictureBox1.Width = this.ClientSize.Width;
            pictureBox1.Height = this.ClientSize.Height;

            Center.X = pictureBox1.Width / 5;
            Center.Y = pictureBox1.Height / 10;
            g = pictureBox1.CreateGraphics();
        }

        private void Picture(bool cl, Graphics g)
        {
            HatchBrush Br = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Black, Color.White);
            SolidBrush SBr = new SolidBrush(Color.White);
            Pen p = new Pen(Color.Black);
            g.Clear(Color.White);
            g.FillEllipse(SBr, Center.X, Center.Y, d1, d1);
            g.DrawEllipse(p, Center.X, Center.Y, d1, d1);
            //рисование подшипника
            p.DashStyle = DashStyle.Solid;
            // линии подшипника
            Point A = new Point(Center.X + d1 / 2, Center.Y + d1 / 2);
            Point B = new Point(Center.X + d1 / 2 - 5, Center.Y + d1 / 2 + 10);
            g.DrawLine(p, B, A);
            B.X = Center.X + d1 / 2 + 5;
            g.DrawLine(p, B, A);
            //  подшипник
            SBr.Color = Color.White;
            g.FillEllipse(SBr, A.X - 2, A.Y - 2, 5, 5);
            g.DrawEllipse(p, A.X - 2, A.Y - 2, 5, 5);
            Br.Dispose();
            // его линии
            double f1 = t * omega;
            p.DashStyle = DashStyle.DashDot;
            Point l1 = new Point(Convert.ToInt32(Center.X + d1 / 2 - (d1 / 2) * Math.Sin(f1)),
                Convert.ToInt32(Center.Y + d1 / 2 - (d1 / 2) * Math.Cos(f1)));
            Point l2 = new Point(Convert.ToInt32(Center.X + d1/ 2 + (d1 / 2) * Math.Sin(f1)),
                Convert.ToInt32(Center.Y + d1 / 2 + (d1 / 2) * Math.Cos(f1)));
            g.DrawLine(p, l1, l2);
            l1.X = Convert.ToInt32(Center.X + d1 / 2 - (d1 / 2) * Math.Cos(f1));
            l1.Y = Convert.ToInt32(Center.Y + d1 / 2 + (d1 / 2) * Math.Sin(f1));
            l2.X = Convert.ToInt32(Center.X + d1 / 2 + (d1 / 2) * Math.Cos(f1));
            l2.Y = Convert.ToInt32(Center.Y + d1 / 2 - (d1 / 2) * Math.Sin(f1));
            g.DrawLine(p, l1, l2);   
            // второе колесо         
            p.DashStyle = DashStyle.Solid;
            Point O2 = new Point(Center.X + d1 - d2, Center.Y + d1 / 2 - d2 / 2);
            Rectangle Rect = new Rectangle(O2.X, O2.Y, d2, d2);
            //g.FillEllipse(SBr, Rect);
            g.DrawEllipse(p, Rect);
            // его линии 
            p.DashStyle = DashStyle.DashDot;
            double f2 = omega * d1 * t / d2;
            Point t1 = new Point(Convert.ToInt32(O2.X + d2 / 2 - (d2 / 2) * Math.Sin(f2)), 
                Convert.ToInt32(O2.Y + d2 / 2 - (d2 / 2) * Math.Cos(f2)));
            Point t2 = new Point(Convert.ToInt32(O2.X + d2 / 2 + (d2 / 2) * Math.Sin(f2)), 
                Convert.ToInt32(O2.Y + d2 / 2 + (d2 / 2)* Math.Cos(f2)));
            g.DrawLine(p, t1, t2);
            t1.X = Convert.ToInt32(O2.X + d2 / 2 - (d2 / 2) * Math.Cos(f2));
            t1.Y = Convert.ToInt32(O2.Y + d2 / 2 + (d2 / 2) * Math.Sin(f2));
            t2.X = Convert.ToInt32(O2.X + d2 / 2 + (d2 / 2) * Math.Cos(f2));
            t2.Y = Convert.ToInt32(O2.Y + d2 / 2 - (d2 / 2) * Math.Sin(f2));
            g.DrawLine(p, t1, t2);
            // его подшипкник
            p.DashStyle = DashStyle.Solid;
            A.X = O2.X + d2 / 2;
            A.Y = O2.Y + d2 / 2;
            B.X = O2.X + d2 / 2 - 5;
            B.Y = O2.Y + d2 / 2 + 10;
            g.DrawLine(p, B, A);
            B.X = O2.X + d2 / 2 + 5;
            g.DrawLine(p, B, A);
            SBr.Color = Color.White;
            g.FillEllipse(SBr, A.X - 2, A.Y - 2, 5, 5);
            g.DrawEllipse(p, A.X - 2, A.Y - 2, 5, 5);
            // Линии грузов
            p = new Pen(cl ? Color.Black : Color.White);
            Point g1 = new Point(Center.X, Center.Y + d1 / 2);
            Point g2 = new Point(Center.X, Center.Y + d1 + 10 + Convert.ToInt32(f1 * d1 / 2));
            g.DrawLine(p, g1, g2);
            g1.X = Center.X + d1 - d2;
            g2.X = Center.X + d1 - d2;
            g2.Y = Center.Y + d1 + 10 + Convert.ToInt32(f1 * d1 / 2);
            g.DrawLine(p, g1, g2);
            // Грузы
            p = new Pen(cl ? Color.Black : Color.White);
            Point k1 = new Point(Center.X - 15, Center.Y + d1 + 10 + Convert.ToInt32(f1 * d1 / 2));
            Size s = new Size(30, 25);
            Rectangle rekt1 = new Rectangle(k1, s);
            g.DrawRectangle(p, rekt1);
            k1.X = k1.X + d1 - d2;
            k1.Y = Center.Y + d1 + 10 + Convert.ToInt32(f1 * d1 / 2);
            Rectangle rekt2 = new Rectangle(k1, s);
            if (k1.Y > Center.Y + d1 + 150)
                fl = false;
            if (k1.Y < Center.Y + d1)
                fl = true;
            g.DrawRectangle(p, rekt2);
            p.Dispose();
            SBr.Dispose();
            this.Invalidate();
        }

        private void стопToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            рисоватьToolStripMenuItem.Enabled = true;
        }

        private void рисоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Picture(false, g);
            t = 0;
            Picture(true, g);
            label1.Visible = true;
            label2.Visible = true;
            numericUpDown1.Visible = true;
            numericUpDown2.Visible = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            стопToolStripMenuItem.Enabled = true;
            пускToolStripMenuItem.Enabled = true;
            рисоватьToolStripMenuItem.Enabled = false;
            fl = true;
        }

        private void пускToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Picture(false, g);
            t += fl ? 0.1 : -0.1; 
            Picture(true, g);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (fl)
                Picture(true, e.Graphics);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            omega = Convert.ToDouble(numericUpDown1.Value) * 0.5;
            
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            d2 = 20 * Convert.ToInt32(numericUpDown2.Value);
            fl = false;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Dispose();
            Close();
        }
    }
}
