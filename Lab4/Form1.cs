using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


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
        int dx, dy;
        double degree, k;

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
            foreach (System.Windows.Forms.RadioButton RB in groupBox1.Controls)//.OfType<RadioButton>())
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

        private void offsetPolygon()
        {
            double[,] m = new double[3, 3]
                {
                  { 1, 0, dx },
                  { 0, 1, -dy },
                  {0, 0,  1 }
                };

            for (int i = 0; i < polygonPoints.Count; i++)
            {

                int x = polygonPoints[i].X;
                int y = polygonPoints[i].Y;

                int newX = (int)(m[0, 0] * x + m[0, 1] * y + m[0, 2]);
                int newY = (int)(m[1, 0] * x + m[1, 1] * y + m[1, 2]);

                polygonPoints[i] = new Point(newX, newY);
            }

            pictureBox1.Invalidate();

        }


        void rotatePolygon()
        {
            degree *= Math.PI / 180;
            double cosD = Math.Cos(degree);
            double sinD = Math.Sin(degree);

            double[,] m = new double[3, 3]
               {
                  { cosD, sinD, 0 },
                  { sinD, cosD, 0 },
                  {0, 0,  1 }
               };
            int centerX = 0;
            int centerY = 0;

            for (int i = 0; i < polygonPoints.Count; i++)
            {
                centerX += polygonPoints[i].X;
                centerY += polygonPoints[i].Y;
            }

            centerX /= polygonPoints.Count;
            centerY /= polygonPoints.Count;

            for (int i = 0; i < polygonPoints.Count; i++)
            {
                polygonPoints[i] = new Point(polygonPoints[i].X - centerX, polygonPoints[i].Y - centerY);
            }

            for (int i = 0; i < polygonPoints.Count; i++)
            {
                int x = polygonPoints[i].X;
                int y = polygonPoints[i].Y;
                int newX = (int)(m[0, 0] * x - m[0, 1] * y + m[0, 2]);
                int newY = (int)(m[1, 0] * x + m[1, 1] * y + m[1, 2]);
                polygonPoints[i] = new Point(newX, newY);
            }

            for (int i = 0; i < polygonPoints.Count; i++)
            {
                polygonPoints[i] = new Point(polygonPoints[i].X + centerX, polygonPoints[i].Y + centerY);
            }

            pictureBox1.Invalidate();

        }

        private void dilatationPolygon()
        {
            double[,] m = new double[3, 3]
                          {
                  { k, 0, 0 },
                  { 0, k, 0 },
                  {0, 0,  1 }
             };

            int centerX = 0;
            int centerY = 0;

            for (int i = 0; i < polygonPoints.Count; i++)
            {
                centerX += polygonPoints[i].X;
                centerY += polygonPoints[i].Y;
            }

            centerX /= polygonPoints.Count;
            centerY /= polygonPoints.Count;

            for (int i = 0; i < polygonPoints.Count; i++)
            {
                polygonPoints[i] = new Point(polygonPoints[i].X - centerX, polygonPoints[i].Y - centerY);
            }

            for (int i = 0; i < polygonPoints.Count; i++)
            {
                int x = polygonPoints[i].X;
                int y = polygonPoints[i].Y;
                int newX = (int)(m[0, 0] * x + m[0, 1] * y + m[0, 2]);
                int newY = (int)(m[1, 0] * x + m[1, 1] * y + m[1, 2]);
                polygonPoints[i] = new Point(newX, newY);
            }

            for (int i = 0; i < polygonPoints.Count; i++)
            {
                polygonPoints[i] = new Point(polygonPoints[i].X + centerX, polygonPoints[i].Y + centerY);
            }

            pictureBox1.Invalidate();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                dx = int.Parse(textBox1.Text);
                dy = int.Parse(textBox2.Text);
                offsetPolygon();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                degree = double.Parse(textBox3.Text);
                rotatePolygon();
            }

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != '-')
                e.Handled = true;

            if (e.KeyChar == '-' && (sender as TextBox).Text.Length > 0)
                e.Handled = true;

        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != '-')
                e.Handled = true;

            if (e.KeyChar == '-' && (sender as TextBox).Text.Length > 0)
                e.Handled = true;

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '-')
            {
                e.Handled = true; // Запрещаем ввод других символов
            }

            if (e.KeyChar == '-' && (sender as TextBox).Text.Length > 0)
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' )
            {
                e.Handled = true; // Запрещаем ввод других символов
            }


            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(","))
            {
                e.Handled = true;
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                k = double.Parse(textBox4.Text);
                dilatationPolygon();
            }
        }
    }

}