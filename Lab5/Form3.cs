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
                pointLocation.Add(e.Location);
        }

        private void paintPoint()
        {
            if (pointLocation.Count == 2)
            {
                g.DrawEllipse(Pens.Black, pointLocation[0].X, pointLocation[0].Y, 3, 3);
                g.FillEllipse(Brushes.Black, pointLocation[0].X, pointLocation[0].Y, 3, 3);
                g.DrawEllipse(Pens.Black, pointLocation[1].X, pointLocation[1].Y, 3, 3);
                g.FillEllipse(Brushes.Black, pointLocation[1].X, pointLocation[1].Y, 3, 3);
                g.DrawLine(Pens.Black, pointLocation[0], pointLocation[1]);
            }

            pictureBox1.Invalidate();

        }

        private PointF getNewPoint(PointF p1, PointF p2)
        {
            float newX = (p1.X + p2.X) / 2;
            float newY = (p1.Y + p2.Y) / 2;
            PointF newPoint = new PointF(newX, newY);
            return newPoint;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pointLocation.Clear();
            g.Clear(Color.White);
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            paintPoint();
        }
    }
}
