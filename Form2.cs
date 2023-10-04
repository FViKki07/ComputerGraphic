using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
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
        Point border;
        Graphics g;
        bool FillFigurebyColor;
        bool ImageLoad = true;
        TextureBrush textureBrush;
        HashSet<Point> visited = new HashSet<Point>();
        Color selectedColor;
        Color borderColor;
        bool flag;

        public Form2()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            selectedColor = Color.Red;
            button6.BackColor = selectedColor;
            borderColor = Color.Black;
            flag = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawLine = true;
            FillFigurebyColor = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // mouseCoord = e.Location;
            prev = e.Location;
            border = e.Location;
            if (button1.Focused)
            {
                pictureBox1_MouseMove(sender, e);
                pictureBox1.Invalidate();
            }
            if (button2.Focused)
            {
                ColorFill(e.Location, selectedColor, borderColor);
                pictureBox1.Invalidate();
            }
            if (textureBrush != null && button5.Focused)
            {
                ImageFill(e.Location, borderColor);
                pictureBox1.Invalidate();
                visited.Clear();
            }
            if (button7.Focused)
            {
                //selectBorder(Color.Red);
                printBorder(selectedColor);
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (prev != null && DrawLine)
            {
                g.DrawLine(new Pen(borderColor), prev.Value, e.Location);
                prev = e.Location;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            prev = null;
            // mouseCoord = e.Location;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FillFigurebyColor = true;
            DrawLine = false;
        }

        private bool IsWindowBorder(Point p)
        {

            //return pictureBox1.ClientRectangle.Contains(p);
            return (p.X <= 0) || (p.X >= bmp.Width) || (p.Y <= 0) || (p.Y >= bmp.Height);
        }

        private bool IsBorder(Point p, Color colorBorder)
        {
            return IsWindowBorder(p) || IsColoredBorder(p, colorBorder);
        }

        private bool IsColoredBorder(Point p, Color colorBorder)
        {
            Color c = ((Bitmap)(pictureBox1.Image)).GetPixel(p.X, p.Y);
            return c.ToArgb() == colorBorder.ToArgb();
        }

        private void ColorFill(Point current, Color colorFill, Color colorBorder)
        {

            if (IsBorder(current, colorBorder) || colorFill.ToArgb() == ((Bitmap)(pictureBox1.Image)).GetPixel(current.X, current.Y).ToArgb())
                return;


            int left = current.X;

            while (!IsBorder(new Point(left, current.Y), colorBorder))
            {
                //bmp.SetPixel(left, current.Y, colorFill);
                left--;
            }
            left++;

            int right = current.X;
            while (!IsBorder(new Point(right, current.Y), colorBorder))
            {
                //bmp.SetPixel(right, current.Y, colorFill);
                right++;
            }
            right--;

            g.DrawLine(new Pen(colorFill), new Point(left, current.Y), new Point(right, current.Y));

            for (int x = left; x <= right; x++)
            {
                ColorFill(new Point(x, current.Y - 1), colorFill, colorBorder);
            }

            for (int x = left; x <= right; x++)
            {
                ColorFill(new Point(x, current.Y + 1), colorFill, colorBorder);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Invalidate();
            DrawLine = false;
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            /*  pictureBox1.Image = bmp;
              g = Graphics.FromImage(pictureBox1.Image);
              pictureBox1.Invalidate();*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Изображения (*.jpg; *.png; *.bmp)|*.jpg;*.png;*.bmp|Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog.FileName);
                textureBrush = new TextureBrush(img);
            }
            DrawLine = false;
        }

        private void ImageFill(Point current, Color colorBorder)
        {

            if (visited.Contains(current) || IsBorder(current, colorBorder))
                return;

            int left = current.X;

            while (!IsBorder(new Point(left, current.Y), colorBorder))
            {
                //bmp.SetPixel(left, current.Y, colorFill);
                left--;
            }
            left++;

            int right = current.X;
            while (!IsBorder(new Point(right, current.Y), colorBorder))
            {
                right++;
            }
            right--;

            g.FillRectangle(textureBrush, left, current.Y, Math.Abs(right - left) + 1, 1);
            for (int i = left; i <= right; ++i)
                visited.Add(new Point(i, current.Y));

            for (int x = left; x <= right; x++)
            {
                ImageFill(new Point(x, current.Y - 1), colorBorder);
            }

            for (int x = left; x <= right; x++)
            {
                ImageFill(new Point(x, current.Y + 1), colorBorder);
            }
        }

        private Point findStartPoint(Point P)
        {
            int x = P.X; //border.X;
            int y = P.Y;//border.Y;

            Color bgColor = bmp.GetPixel(border.X, border.Y);
            Color currColor = bgColor;
            while (x < bmp.Width - 2 && currColor.ToArgb() != borderColor.ToArgb())
            {
                x++;
                currColor = bmp.GetPixel(x, y);
            }

            return new Point(x, y);
        }

        void printBorder(Color c)
        {
            List<Point> pixels = new List<Point>();
            List<Point> newpixels = new List<Point>();
            selectBorder(new Point(border.X, border.Y), ref pixels, ref newpixels);
            List<Point> sortedPoints = pixels.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
            //pixels.First();
            flag = true;
            List<Point> newList = pixels.ToList();
           /* if(sortedPoints.Count() > 0)
            {
                Point prev = sortedPoints.First();
                Point tmp = sortedPoints.First();
                foreach (Point p in sortedPoints)
                {
                    Point next = p;
                    if(next.Y == prev.Y)
                    {
                        tmp = next;
                    }
                    else
                    {
                        int oldX = prev.X;
                        int oldY = prev.Y;
                        while (oldX < bmp.Width && bmp.GetPixel(oldX, oldY).ToArgb() != Color.Black.ToArgb())
                            oldX++;
                        if(tmp.X != oldX )
                        {
                            selectBorder(new Point(oldX, oldY), ref pixels, ref newpixels);
                        }
                        prev = next;
                    }
                }
            }*/

            if (pixels.Count > 0)
            {
                foreach (var p in pixels)
                    bmp.SetPixel(p.X, p.Y, c);

            }
          
        }
        private void selectBorder(Point p, ref List<Point> newpixels, ref List<Point> pixels)
        {
           //List<Point> newpixels = new List<Point>();
            Point start = findStartPoint(p);
            Point cur = start;
            pixels.Add(start);
            Color color = bmp.GetPixel(cur.X, cur.Y);

            Point next = new Point();
            int currPos = 6;
            int nextPos = -1;
            int moveTo = 0;
            while (next != start)
            {
                flag = false;
                moveTo = (currPos - 2 + 8) % 8;
                int cnst = moveTo;
                int mt = -1;
                while (moveTo != mt)
                {
                    if(mt != -1 && moveTo == cnst) { 
                        pixels.Clear(); 
                        return;  }
                    mt = moveTo;
                    next = cur;
                    switch (moveTo)
                    {
                        case 0: next.X++; nextPos = 0; break;
                        case 1: next.X++; next.Y++; nextPos = 1; break;
                        case 2: next.Y++; nextPos = 2; break;
                        case 3: next.X--; next.Y++; nextPos = 3; break;
                        case 4: next.X--; nextPos = 4; break;
                        case 5: next.X--; next.Y--; nextPos = 5; break;
                        case 6: next.Y--; nextPos = 6; break;
                        case 7: next.X++; next.Y--; nextPos = 7; break;
                    }

                    if (next == start)
                        break;

                    if (bmp.GetPixel(next.X, next.Y).ToArgb() == Color.Black.ToArgb() && !pixels.Contains(next) )
                    {
                        pixels.Add(next);
                        cur = next;
                        currPos = nextPos;
                        break;
                    }
                    moveTo = (moveTo + 1) % 8;

                }
            }

            newpixels = pixels.ToList();
            /*foreach (var p in pixels)
                bmp.SetPixel(p.X, p.Y, c);*/

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DrawLine = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DrawLine = false;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog.Color;
                button6.BackColor = selectedColor;

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DrawLine = false;
        }
    }
}
