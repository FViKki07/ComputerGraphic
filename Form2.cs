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
    public partial class Form2 : Form
    {
        Bitmap bmp;
        bool DrawLine;
        Point? prev;
        Graphics g;

        public Form2()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(pictureBox1.Image);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1_MouseMove(sender, e);
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            g.DrawLine(new Pen(Color.FromArgb(255, 0, 0, 0), 1), prev.Value, e.Location);
            prev = e.Location;
            pictureBox1.Invalidate();
        }
    }
}
