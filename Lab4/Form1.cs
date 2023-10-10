using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
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
        List<PointF> intersection = new List<PointF>();

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
                if (lines.Count > 0)
                    wherePoint(lines.Last(), pointLocation);
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

            if (intersection.Count > 0)
            {
                foreach (var i in intersection)
                {
                    g.DrawEllipse(Pens.Red, i.X - 1, i.Y - 1, 3, 3);
                    g.FillEllipse(Brushes.Red, i.X - 1, i.Y - 1, 3, 3);
                }
            }

            if (!pointLocation.IsEmpty && polygonPoints.Count > 2)
            {

                label6.Text = "Точка принадлежит полигону: " + (isPointInPolygon(pointLocation) ? "даа" : "неет");
                label6.Refresh();
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
            intersection.Clear();
            label5.Text = "Точка относительно ребра:";
            label6.Text = "Точка принадлежит полигону:";
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


        void rotatePolygonArCenter()
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

            if (polygonPoints.Count > 0)
            {
                centerX /= polygonPoints.Count;
                centerY /= polygonPoints.Count;
            }

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
        void rotatePolygonArPoint()
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

            for (int i = 0; i < polygonPoints.Count; i++)
            {
                polygonPoints[i] = new Point(polygonPoints[i].X - pointLocation.X, polygonPoints[i].Y - pointLocation.Y);
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
                polygonPoints[i] = new Point(polygonPoints[i].X + pointLocation.X, polygonPoints[i].Y + pointLocation.Y);
            }

            pictureBox1.Invalidate();

        }

        private void dilatationPolygonCenter()
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
        private void dilatationPolygonPoint()
        {
            double[,] m = new double[3, 3]
                          {
                  { k, 0, 0 },
                  { 0, k, 0 },
                  {0, 0,  1 }
             };

            for (int i = 0; i < polygonPoints.Count; i++)
            {
                polygonPoints[i] = new Point(polygonPoints[i].X - pointLocation.X, polygonPoints[i].Y - pointLocation.Y);
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
                polygonPoints[i] = new Point(polygonPoints[i].X + pointLocation.X, polygonPoints[i].Y + pointLocation.Y);
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
                rotatePolygonArCenter();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && !pointLocation.IsEmpty)
            {
                degree = double.Parse(textBox3.Text);
                rotatePolygonArPoint();
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
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
                dilatationPolygonCenter();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && !pointLocation.IsEmpty)
            {

                k = double.Parse(textBox4.Text);
                dilatationPolygonPoint();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lines.Count - 1; i++)
            {
                for (int j = i; j < lines.Count; j++)
                {
                    PointF inter = findPoint(lines[i], lines[j]);
                    if (!inter.IsEmpty)
                    {
                        intersection.Add(inter);
                    }
                }
            }

        }

        private int GetScalarMult(Point a, Point b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        private PointF findPoint(Line l1, Line l2)
        {

            Point a = l1.leftP;
            Point b = l1.rightP;
            Point c = l2.leftP;
            Point d = l2.rightP;


            Point ab = l1.Diff();
            Point cd = l2.Diff();

            Point n = new Point(-cd.Y, cd.X);

            int perp = GetScalarMult(n, ab);
            if (perp != 0)
            {
                Point ac = new Point(a.X - c.X, a.Y - c.Y);

                float t = -1 * GetScalarMult(n, ac) * 1.0f / perp;
                Point k = new Point(-ab.Y, ab.X);

                float u = -1 * GetScalarMult(k, ac) * 1.0f / perp;

                if (u >= 0 && u < 1 && t >= 0 && t <= 1)
                {
                    PointF intersection = new PointF(((b.X - a.X) * t + a.X), (t * (b.Y - a.Y) + a.Y));
                    return intersection;
                }

            }

            return PointF.Empty;
        }

        public void wherePoint(Line line, Point p)
        {
            int line_temp_x = line.leftP.X - line.rightP.X;
            int line_temp_Y = line.leftP.Y - line.rightP.Y;

            int user_temp_x = p.X - line.rightP.X;
            int user_temp_y = p.Y - line.rightP.Y;

            int sin = user_temp_y * line_temp_x - user_temp_x * line_temp_Y;
            if (sin > 0)
                label5.Text = "Точка относительно ребра: справа";
            else
            {
                if (sin < 0)
                    label5.Text = "Точка относительно ребра: слева";
                else label5.Text = "Точка относительно ребра: на ребре";
            }
        }



        public bool isPointInPolygon(Point userPoint)
        {
            if (polygonPoints.Count < 3)
                return false;

            Point p = new Point(pb.Width, userPoint.Y);

            int count = 0;

            for (int i = 0; i < polygonPoints.Count - 1; i++)
            {
                PointF intersection = findPoint(new Line(polygonPoints[i], polygonPoints[i + 1]), new Line(userPoint, p));
                if (!intersection.IsEmpty)
                {
                    if (areColinear(polygonPoints[i], userPoint, polygonPoints[i + 1]))
                        //return isPointOnLine(new Line(polygonPoints[i], polygonPoints[i + 1]), userPoint);
                        return true;
                    count++;
                }

            }

            PointF intersect = findPoint(new Line(polygonPoints[polygonPoints.Count - 1], polygonPoints[0]), new Line(userPoint, p));
            if (!intersect.IsEmpty)
            {
                if (areColinear(polygonPoints[polygonPoints.Count - 1], userPoint, polygonPoints[0]))
                    //return isPointOnLine(new Line(polygonPoints[polygonPoints.Count - 1], polygonPoints[0]), userPoint);
                    return true;
                count++;
            }

            return count % 2 != 0;
        }



        private bool isPointOnLine(Line l, Point p)
        {
            return (p.X <= Math.Max(l.leftP.X, l.rightP.X)) && (p.X >= Math.Min(l.leftP.X, l.rightP.X)
                && (p.Y >= Math.Min(l.rightP.Y, l.leftP.Y)) && (p.Y <= Math.Max(l.rightP.Y, l.leftP.Y)));
        }

        private bool areColinear(Point p, Point p1, Point p2)
        {

            return p.X * (p1.Y - p2.Y) + p1.X * (p.Y - p2.Y) + p2.X * (p.Y - p1.Y) == 0;
        }

    }

}