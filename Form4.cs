using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            g.Clear(Color.White);
        }

        private int GetAlgorithm()
        {
            if (radioButton1.Checked) { return 0; }
            else { return 1; }
        }

        private void SetPoints(Point p)
        {
            if (!is_start)
            {
                start_point = new Point(p.X, pictureBox1.Height - p.Y);
                is_start = true;
            }
            else
            {
                end_point = new Point(p.X, pictureBox1.Height - p.Y);
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
            g.FillRectangle(Brushes.Black, point.X, point.Y, 2, 2);
            SetPoints(point);

            pictureBox1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
            g.Clear(Color.White);
            pictureBox1.Invalidate();
        }
    }
}
