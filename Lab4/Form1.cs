using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lab4
{
    public partial class Form1 : Form
    {
        PictureBox pb;
        private Graphics g;
        private Bitmap bmp;
        Color colorDot;
        Color colorLine;
        Point startPoint;
        List<Line> lines = new List<Line>();
        Point pointLocation;
        Point endPoint;
        List<Point> polygonPoints = new List<Point>();
        bool drawLine;
        Point up;
        Point down;

        public Form1()
        {
            InitializeComponent();

            pb = pictureBox1;
            bmp = new Bitmap(pb.Width, pb.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(pictureBox1.Image);

            g.Clear(Color.White);

            startPoint = Point.Empty;
            endPoint = Point.Empty;
            //groupBox1.Invalidate();

        }

        bool IsFocused() => DotRadioButton.Checked || LineRadioButton.Checked || PolygonRadioButton.Checked;

        private void Form1_Shown(object sender, EventArgs e)
        {
            foreach (RadioButton RB in groupBox1.Controls)//.OfType<RadioButton>())
                RB.Checked = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsFocused())
            {
                drawLine = true;
                startPoint = e.Location;

                if (PolygonRadioButton.Checked)
                {
                    polygonPoints.Add(startPoint);
                    startPoint = Point.Empty;

                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (LineRadioButton.Checked)
            {
                endPoint = e.Location;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            if (DotRadioButton.Checked)
            {
                startPoint = Point.Empty;
                pointLocation = e.Location;
            }
            else
            {

                if (LineRadioButton.Checked)
                {
                    lines.Add(new Line(startPoint, endPoint));
                    drawLine = false;
                    //up = startPoint;
                    //down = endPoint;
                    //startPoint = Point.Empty;
                    //endPoint = Point.Empty;
                }

            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            pictureBox1.Image = bmp;
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);

            if (lines.Count > 0)
            {
                foreach (Line line in lines)
                    g.DrawLine(Pens.Black, line.leftP, line.rightP);
            }

            if (!pointLocation.IsEmpty)
            {
                g.DrawEllipse(Pens.Blue, pointLocation.X - 1, pointLocation.Y - 1, 3, 3);
                g.FillEllipse(Brushes.Blue, pointLocation.X - 1, pointLocation.Y - 1, 3, 3);

            }

            if (LineRadioButton.Checked && drawLine && !endPoint.IsEmpty && !startPoint.IsEmpty)
            {
                g.DrawLine(new Pen(Color.Black), startPoint, endPoint);
                drawLine = true;
            }

            if (polygonPoints.Count == 1)
            {
                g.DrawRectangle(Pens.Red, polygonPoints[0].X, polygonPoints[0].Y, 2, 2);
            }

            if (polygonPoints.Count >= 2)
            {
                for (int i = 0; i < polygonPoints.Count - 1; i++)
                {
                    g.DrawLine(Pens.Red, polygonPoints[i], polygonPoints[i + 1]);
                }
                g.DrawLine(Pens.Red, polygonPoints[0], polygonPoints[polygonPoints.Count() - 1]);
            }
            pictureBox1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            polygonPoints.Clear();
            lines.Clear();
            pointLocation = Point.Empty;
            g.Clear(Color.White);
            pictureBox1.Invalidate();
        }

    }

}