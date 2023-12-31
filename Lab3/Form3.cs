﻿//private void findTriangle()
//{
//    if (p1.X < p2.X && p1.X < p3.X)
//        minX = p1.X;
//    else if (p2.X < p1.X && p2.X < p3.X)
//        minX = p2.X;
//    else minX = p3.X;


//    if (p1.Y < p2.Y && p1.Y < p3.Y)
//        minY = p1.Y;
//    else if (p2.Y < p1.Y && p2.Y < p3.Y)
//        minY = p2.Y;
//    else minY = p3.Y;

//    if (p1.X > p2.X && p1.X > p3.X)
//        maxX = p1.X;
//    else if (p2.X > p1.X && p2.X > p3.X)
//        maxX = p2.X;
//    else maxX = p3.X;

//    if (p1.Y > p2.Y && p1.Y > p3.Y)
//        maxY = p1.Y;
//    else if (p2.Y > p1.Y && p2.Y > p3.Y)
//        maxY = p2.Y;
//    else maxY = p3.Y;

//}

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
        Graphics g;
        Color[] colors = new Color[3];
        Point[] points = new Point[3];
        //int x, y;
        // int minX, maxX, minY, maxY;
        private Random random = new Random();

        int step, steps;
        int CounterSetPoint;
        int deltaX, deltaY;
        int signX, signY;
        int e1, e2;

        Bitmap bmp;
        Dictionary<int, GradientColors> dictionary = new Dictionary<int, GradientColors>();
        private class GradientColors
        {
            public int leftX;
            public int rightX;
            public Color leftColor;
            public Color rightColor;

            public GradientColors(int leftX, int rightX, Color leftColor, Color rightColor)
            {
                this.leftX = leftX;
                this.rightX = rightX;
                this.leftColor = leftColor;
                this.rightColor = rightColor;
            }
        }

        public Form3()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.White;
            CounterSetPoint = 0;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(bmp);
            colors[0] = Color.Cyan;
            colors[1] = Color.Blue;
            colors[2] = Color.Red;
            button1.BackColor = colors[0];
            button2.BackColor = colors[1];
            button3.BackColor = colors[2];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chooseColor(0);
            button1.BackColor = colors[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chooseColor(1);
            button2.BackColor = colors[1];
        }
        private void button3_Click(object sender, EventArgs e)
        {
            chooseColor(2);
            button3.BackColor = colors[2];
        }

        private void chooseColor(int index)
        {
            colorDialog1.ShowDialog();
            colors[index] = colorDialog1.Color;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (CounterSetPoint == 3)
            {
                CounterSetPoint = 0;
                CreateGradient();
            }

            points[CounterSetPoint] = new Point(e.X, e.Y);
            CounterSetPoint++;

            Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (CounterSetPoint == 3)
                CreateGradient();

        }

        private Color LerpRGB(Color color1, Color color2)
        {
            return Color.FromArgb(CalculateParametrColor(color1.R, color2.R), CalculateParametrColor(color1.G, color2.G), CalculateParametrColor(color1.B, color2.B));
        }

        private int CalculateParametrColor(int parametrColor1, int parametrColor2)
        {
            return parametrColor1 + (parametrColor2 - parametrColor1) * step / steps;
        }
        private int CalculateDelta(int a, int b) => Math.Abs(b - a);
        private int CalculateSign(int a, int b) => a < b ? 1 : -1;
        private int CalculateCountSteps(Point point1, Point point2)
        {
            int result = 0;


            Point pointForWork = point1;

            signX = CalculateSign(point1.X, point2.X);
            signY = CalculateSign(point1.Y, point2.Y);

            deltaX = CalculateDelta(point1.X, point2.X);
            deltaY = CalculateDelta(point1.Y, point2.Y);

            e1 = (deltaX > deltaY ? deltaX : -deltaY) / 2;

            while (pointForWork.X != point2.X || pointForWork.Y != point2.Y)
            {
                result++;
                e2 = e1;
                if (e2 > -deltaX)
                {
                    e1 -= deltaY;
                    pointForWork.X += signX;
                }
                if (e2 < deltaY)
                {
                    e1 += deltaX;
                    pointForWork.Y += signY;
                }
            }

            return result;
        }

        private void DrawBordersGradient(Point point1, Point point2, Color color1, Color color2, Dictionary<int, GradientColors> dict)
        {

            step = 0;
            steps = CalculateCountSteps(point1, point2);

            while (point1.X != point2.X || point1.Y != point2.Y)
            {
                Color colorForWork = LerpRGB(color1, color2);
                if (dict.ContainsKey(point1.Y))
                {

                    if (dict[point1.Y].leftX > point1.X)
                    {
                        dict[point1.Y].leftX = point1.X;
                        dict[point1.Y].leftColor = colorForWork;
                    }
                    if (dict[point1.Y].rightX < point1.X)
                    {
                        dict[point1.Y].rightX = point1.X;
                        dict[point1.Y].rightColor = colorForWork;
                    }

                }
                else
                    dict.Add(point1.Y, new GradientColors(point1.X, point1.X, colorForWork, colorForWork));
                step++;

                bmp.SetPixel(point1.X, point1.Y, colorForWork);
                pictureBox1.Invalidate();

                e2 = e1;

                if (e2 > -deltaX)
                {
                    e1 -= deltaY;
                    point1.X += signX;
                }
                if (e2 < deltaY)
                {
                    e1 += deltaX;
                    point1.Y += signY;
                }

            }
        }
        private void DrawOneLineGradient(Point point1, Point point2, Color color1, Color color2)
        {
            step = 0;
            steps = CalculateCountSteps(point1, point2);

            while (point1.X != point2.X || point1.Y != point2.Y)
            {
                Color colorForWork = LerpRGB(color1, color2);
                bmp.SetPixel(point1.X, point1.Y, colorForWork);

                e2 = e1;
                if (e2 > -deltaX)
                {
                    e1 -= deltaY;
                    point1.X += signX;
                }
                if (e2 < deltaY)
                {
                    e1 += deltaX;
                    point1.Y += signY;
                }
                step++;
            }
        }
        private void CreateGradient()
        {
            dictionary.Clear();

            DrawBordersGradient(points[0], points[1], colors[0], colors[1], dictionary);
            DrawBordersGradient(points[1], points[2], colors[1], colors[2], dictionary);
            DrawBordersGradient(points[2], points[0], colors[2], colors[0], dictionary);

            foreach (var t in dictionary)
            {
                int y = t.Key;
                Point pt1 = new Point(t.Value.leftX, y);
                Point pt2 = new Point(t.Value.rightX, y);
                DrawOneLineGradient(pt1, pt2, t.Value.leftColor, t.Value.rightColor);
            }
            pictureBox1.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CounterSetPoint = 0;
            Array.Clear(points, 0, points.Length);
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            pictureBox1.Invalidate();

        }
    }
}