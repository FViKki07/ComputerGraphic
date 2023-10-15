using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Lab5
{
    public partial class Form3 : Form
    {
        List<PointF> pointLocation = new List<PointF>();
        PictureBox pb;
        private Graphics g;
        private Bitmap bmp;
        int iteration;
        Random random = new Random();
        public Form3()
        {
            InitializeComponent();
            pb = pictureBox1;
            bmp = new Bitmap(pb.Width, pb.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(pictureBox1.Image);

            g.Clear(Color.White);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pointLocation.Count < 2)
            {
                g.DrawEllipse(Pens.Black, e.Location.X, e.Location.Y, 3, 3);
                g.FillEllipse(Brushes.Black, e.Location.X, e.Location.Y, 3, 3);
                pointLocation.Add(e.Location);
                pictureBox1.Invalidate();
            }

        }
        private void getNewPoint(PointF p1, PointF p2)
        {
            iteration++;
            float l = (float)Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));//длина отрезка
            if (l < 1)
            {
                label1.Text = "Итераций :" + iteration.ToString();
                return;
            }
            int ind = (int)Math.Floor(l * 0.3);
            float newX = (p1.X + p2.X) / 2;
            float newY = (float)((p1.Y + p2.Y) / 2 + random.Next(-ind, ind + 1));
            PointF newPoint = new PointF(newX, newY);
            pointLocation.Add(newPoint);
            getNewPoint(p1, newPoint);
            getNewPoint(newPoint, p2);
        }

        private void paintPoint()
        {
            iteration = 0;
            getNewPoint(pointLocation[0], pointLocation[1]);
            pointLocation = pointLocation.OrderBy(p => p.X).ToList();
            g.DrawLines(Pens.Black, pointLocation.ToArray());
            pictureBox1.Invalidate();
        }

        //private void DrawPoint()
        //{
        //    g.DrawLines(Pens.Black, pointLocation.ToArray());
        //    pictureBox1.Invalidate();
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(iteration.ToString());
            if (pointLocation.Count == 2)
                paintPoint();
            else MessageBox.Show("Отметьте 2 точки");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pointLocation.Clear();
            g.Clear(Color.White);
            pictureBox1.Invalidate();
            label1.Text = "Итераций:";
        }

    }
}
