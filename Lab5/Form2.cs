using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form2 : Form
    {
        Graphics g;
        string axiom;
        double angle;
        string direction;
        Dictionary<char, string> rules;
        int iterations;
        Random rnd = new Random();

        public Form2()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);

            rules = new Dictionary<char, string>();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Файлы txt|*.txt";

            if (OPF.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] file = File.ReadAllLines(OPF.FileName);
                    string[] parameters = file[0].Split(' ');

                    axiom = parameters[0];
                    angle = Convert.ToDouble(parameters[1]);
               
                    direction = parameters[2];

                    rules.Clear();
                    string[] rule;
                    for (int i = 1; i < file.Length; ++i)
                    {
                        rule = file[i].Split('=');
                        rules[Convert.ToChar(rule[0])] = rule[1];
                    }
                }
                catch
                {
                    DialogResult result = MessageBox.Show("Can't open file",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private double[] MultiplyVectorByMatrix(double[] point, double[,] m)
        {
            double[] new_point = { 0, 0, 0 };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    new_point[i] += point[j] * m[j, i];
                }
            }
            return new_point;
        }

        private void Fractus(string path)
        {
            List<double>  allX = new List<double>();
            List<double> allY = new List<double>();
            List<Tuple<double, double, double, double>> listPoints = new List<Tuple<double, double, double, double>>();
            Stack<Tuple<double, double, double, double>> stPoints = new Stack<Tuple<double, double, double, double>>();

            double x = 0, y = 0, dx = 0, dy = 0;
            switch (direction)
            {
                case "LEFT":
                    x = pictureBox1.Width;
                    y = pictureBox1.Height / 2;
                    dx = -1;
                    break;

                case "RIGHT":
                    y = pictureBox1.Height / 2;
                    dx = 1;
                    break;

                case "UP":
                    x = pictureBox1.Width / 2;
                    y = pictureBox1.Height;
                    dy = -1;
                    break;

                case "DOWN":
                    x = pictureBox1.Width / 2;
                    dy = 1;
                    break;

                default: break;
            }

            allX.Add(x);
            allY.Add(y);

            //double new_angle = angle;
            double new_angle = rnd.Next((int)angle - 15, (int)angle + 15);
            double cosD = Math.Cos(new_angle * Math.PI / 180);
            double sinD = Math.Sin(new_angle * Math.PI / 180);
            double[,] m = new double[3, 3]
            {
                  { cosD, sinD, 0 },
                  { -sinD, cosD, 0 },
                  {0, 0,  1 }
            };
            double cosD1 = Math.Cos(-new_angle * Math.PI / 180);
            double sinD1 = Math.Sin(-new_angle * Math.PI / 180);
            double[,] m1 = new double[3, 3]
            {
                  { cosD1, sinD1, 0 },
                  { -sinD1, cosD1, 0 },
                  {0, 0,  1 }
            };
            for (int i = 0; i < path.Length; ++i)
            {
               
                switch (path[i])
                {
                    case 'F':
                        listPoints.Add(
                            new Tuple<double, double,double, double>(x, y, x + dx, y + dy));
                        x += dx;
                        y += dy;
                        allX.Add(x);
                        allY.Add(y);
                        break;

                    case '+':
                        double[] point = { dx, dy, 1 };
                        var new_point = MultiplyVectorByMatrix(point, m);
                        dx = new_point[0];
                        dy = new_point[1];
                        break;

                    case '-':
                        double[] point1 = { dx, dy, 1 };
                        new_point = MultiplyVectorByMatrix(point1, m1);
                        dx = new_point[0];
                        dy = new_point[1];
                        break;

                    case '[':
                        stPoints.Push(new Tuple<double, double, double, double>(x, y, dx, dy));
                        break;

                    case ']':
                        Tuple<double, double, double, double> coords = stPoints.Pop();
                        x = coords.Item1;
                        y = coords.Item2;
                        dx = coords.Item3;
                        dy = coords.Item4;
                        break;

                    default: break;
                }
            }
            double xMax = allX.Max();
            double xMin = allX.Min();
            double yMax = allY.Max();
            double yMin = allY.Min();
            double scale = Math.Max(xMax - xMin, yMax - yMin);


            float initialLineWidth = 3.0f;
            Color startColor = Color.Brown;
            Color endColor = Color.Green;
            for (int i = 0; i < listPoints.Count; i++)
            {
                var a = listPoints[i];
                float colorInterpolation = (float)i  / (listPoints.Count  * 0.5f);
                if (colorInterpolation > 1.0f)
                {
                    colorInterpolation = 1.0f;
                }
                Color currentColor = Color.FromArgb(
         (int)(startColor.R + colorInterpolation * (endColor.R - startColor.R)),
         (int)(startColor.G + colorInterpolation * (endColor.G - startColor.G)),
         (int)(startColor.B + colorInterpolation * (endColor.B - startColor.B)));
                Pen pen = new Pen(currentColor, initialLineWidth);

                g.DrawLine(pen,
                    (float)((xMax - a.Item1) / scale * pictureBox1.Width),
                    (float)((yMax - a.Item2) / scale * pictureBox1.Height),
                    (float)((xMax - a.Item3) / scale * pictureBox1.Width),
                    (float)((yMax - a.Item4) / scale * pictureBox1.Height));

                float lineWidthReduction = (initialLineWidth + i)/ listPoints.Count;
                initialLineWidth -= lineWidthReduction;

            }

        }

        string AllPath()
        {
            string prev = axiom;
            string next = axiom;
            int iter = 0;
            while (iter < iterations)
            {
                prev = next;
                next = "";
                for (int i = 0; i < prev.Length; ++i)
                {
                    if (rules.ContainsKey(prev[i]))
                        next += rules[prev[i]];
                    else
                        next += prev[i];
                }
                ++iter;
            }
            return next;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            iterations = Convert.ToInt32(numericUpDown1.Value);
            if (axiom != null)
            {
                string path = AllPath();

                Fractus(path);
                pictureBox1.Invalidate();
            }
        }
    }
}
