using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
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
        bool FillFigurebyColor;
        bool ImageLoad = true;
        TextureBrush textureBrush;
        HashSet<Point> visited = new HashSet<Point>();
        Color selectedColor;
        Color borderColor;

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
            button7.BackColor = borderColor;
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
                //bmp.SetPixel(right, current.Y, colorFill);
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

        private void button5_Click(object sender, EventArgs e)
        {
            DrawLine = false;
            //ImageLoad = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DrawLine = false;
            // Откройте диалоговое окно выбора цвета
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Получите выбранный цвет
                selectedColor = colorDialog.Color;

                // Установите цвет кнопки на выбранный цвет
                button6.BackColor = selectedColor;

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DrawLine = false;
            // Откройте диалоговое окно выбора цвета
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Получите выбранный цвет
                borderColor = colorDialog.Color;

                // Установите цвет кнопки на выбранный цвет
                button7.BackColor = borderColor;

            }
        }
    }
}
