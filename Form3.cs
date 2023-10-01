using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Laba3
{
    public partial class Form3 : Form
    {
        Color color1, color2, color3;
        int x1, x2, x3, y1, y2, y3;
        Point p1, p2, p3;
        private Random random = new Random();
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            color1 = colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            color2 = colorDialog2.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog3.ShowDialog();
            color3 = colorDialog3.Color;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            (x1, y1) = randomAx();
            (x2, y2) = randomAx();
            (x3, y3) = randomAx();

            p1 = new Point(x1, y1);
            p2 = new Point(x2, y2);
            p3 = new Point(x3, y3);


            if (p2.Y < p1.Y)
                Swap(ref p1, ref p2, ref color1, ref color2);
            if (p3.Y < p1.Y)
                Swap(ref p1, ref p3, ref color1, ref color3);
            if (p3.Y < p2.Y)
                Swap(ref p2, ref p3, ref color2, ref color3);
        }

        private (int, int) randomAx()
        {
            int newX = random.Next(0, pictureBox1.Width);
            int newY = random.Next(0, pictureBox1.Height);
            return (newX, newY);
        }

        private void Swap(ref Point p1, ref Point p2, ref Color col1, ref Color col2)
        {
            Point tempPoint = p1;
            p1 = p2;
            p2 = tempPoint;

            Color tempColor = col1;
            col1 = col2;
            col2 = tempColor;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();

        }

    }
}