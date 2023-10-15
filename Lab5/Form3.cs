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
        int x;
        float l;
        int currentIteration;
        public Form3()
        {
            InitializeComponent();
            currentIteration = 0;
            l = 5;
            x = 1;
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
        private PointF getNewPoint(PointF p1, PointF p2)
        {
            l = (float)Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));//длина отрезка
            int ind = (int)Math.Floor(l * 0.3);
            float newX = (p1.X + p2.X) / 2;
            float newY = (float)((p1.Y + p2.Y) / 2 + random.Next(-ind, ind + 1));
            if (newY > pb.Height)
                newY = pb.Height - 5;
            return new PointF(newX, newY);
        }

        private void paintPoint()
        {
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(pictureBox1.Image);
            // int x = 1;
            for (int i = 0; i < iteration; i++)
            {
                g.Clear(Color.White);
                for (int j = 0; j < x; j++)
                {
                    PointF newPoint = getNewPoint(pointLocation[j], pointLocation[j + 1]);
                    pointLocation.Add(newPoint);
                    if (l < 1)
                    {
                        label3.Text = currentIteration.ToString();
                        return;
                    }
                }
                currentIteration++;
                pointLocation = pointLocation.OrderBy(x => x.X).ToList();
                x *= 2;
                g.DrawLines(Pens.Black, pointLocation.ToArray());
                pictureBox1.Refresh();
                Thread.Sleep(500);
            }

            g.DrawLines(Pens.Black, pointLocation.ToArray());
            pictureBox1.Invalidate();
            label3.Text = currentIteration.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            iteration = (int)numericUpDown1.Value;
            //MessageBox.Show(iteration.ToString());
            if (pointLocation.Count == 2)
                paintPoint();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            x = 1;
            pointLocation.Clear();
            g.Clear(Color.White);
            pictureBox1.Invalidate();
            currentIteration = 0;
            label3.Text = "";
        }

    }
}