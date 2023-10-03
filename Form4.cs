using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Laba3
{
    public partial class Form4 : Form
    {
        Bitmap bmp;
        Graphics g;

        Point start_point;
        Point end_point;

        bool is_start;
        public Form4()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            is_start = false;
            g = Graphics.FromImage(pictureBox1.Image);
            g.ScaleTransform(1.0F, -1.0F); //инверсия по вертикали
            g.TranslateTransform(0.0F, -pictureBox1.Height);
            g.Clear(Color.White);
        }

        private void SetAlgorithm()
        {
            if (radioButton1.Checked)
            {
                BresenhamAlghoritm();
            }
        }

        private void SetPoints(Point p)
        {
            if (!is_start)
            {
                start_point = new Point(p.X, pictureBox1.Height - p.Y);
                //g.DrawLine(new Pen(Color.Black), start_point.X, start_point.Y, 1, 1);
                is_start = true;
            }
            else
            {
                end_point = new Point(p.X, pictureBox1.Height - p.Y);
                //g.DrawLine(new Pen(Color.Black), end_point.X, end_point.Y, 1, 1);

            }
        }

        private void Clear()
        {
            is_start = false;
            start_point = new Point(0, 0);
            end_point = new Point(0, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs m = (MouseEventArgs)e;
            Point point = m.Location;

            //g.DrawLine(new Pen(Color.Black), point.X, point.Y, 1, 1);
            SetPoints(point);
            if (!end_point.IsEmpty)
            {
                SetAlgorithm();
                Clear();
            }
            pictureBox1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
            g.Clear(Color.White);
            pictureBox1.Invalidate();
        }


        private void DrawLineBresenhamX(Point start, Point end)
        {
            int dx = end.X - start.X;
            int dy = end.Y - start.Y;

            int yi; // направление движения по оси y
            if (dy > 0) { yi = 1; }
            else { yi = -1; }

            dy = Math.Abs(dy);

            int delta = 2 * dy - dx;
            int y = start.Y;

            for (int x = start.X; x <= end.X; x++)
            {
                g.FillRectangle(Brushes.Black, x, y, 2, 2);
                if (delta > 0)
                {
                    y += yi;
                    delta += 2 * (dy - dx);
                }
                else
                    delta += 2 * dy;
            }
        }

        private void DrawLineBresenhamY(Point start, Point end)
        {
            int dx = end.X - start.X;
            int dy = end.Y - start.Y;

            int xi; // направление движения по оси x
            if (dx > 0) { xi = 1; }
            else { xi = -1; }

            dx = Math.Abs(dx);

            int delta = 2 * dx - dy;
            int x = start.X;

            for (int y = start.Y; y <= end.Y; y++)
            {
                g.FillRectangle(Brushes.Black, x, y, 2, 2);
                if (delta > 0)
                {
                    x += xi;
                    delta += 2 * (dx - dy);
                }
                else
                    delta += 2 * dx;
            }
        }

        private void BresenhamAlghoritm()
        {
            if (Math.Abs(start_point.Y - end_point.Y) < Math.Abs(start_point.X - end_point.X)) // наклон ближе к х
            {
                if (start_point.X > end_point.X) // справа налево
                {
                    DrawLineBresenhamX(end_point, start_point);
                }
                else
                {
                    DrawLineBresenhamX(start_point, end_point);
                }
            }
            else // наклон ближе у
            {
                if (start_point.Y > end_point.Y)
                {
                    DrawLineBresenhamY(end_point, start_point);
                }
                else
                {
                    DrawLineBresenhamY(start_point, end_point);
                }

            }
        }

    }
}
