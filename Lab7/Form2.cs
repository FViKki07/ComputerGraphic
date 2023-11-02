using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class Form2 : Form
    {
        Graphics g;
        Bitmap bmp;
        Polyhedron currentPolyhedron;
        public Form2()
        {
            InitializeComponent();
            comboBox1.SelectedItem = comboBox1.Items[0];
            comboBox2.SelectedItem = comboBox2.Items[0];
            //Создаем Bitmap и Graphics для PictureBox
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            g.Clear(Color.White);
            comboBox1.SelectedItem = 0;

            DrawAxis(g, Transform.IsometricProjection());
        }

        //Рисует координатные оси 
        private void DrawAxis(Graphics g, Transform t)
        {
            List<PointZ> p = new List<PointZ>();
            PointZ a = new PointZ(0, 0, 0);
            PointZ b = new PointZ(1, 0, 0);
            PointZ c = new PointZ(0, 1, 0);
            PointZ d = new PointZ(0, 0, 1);

            p.Add(a);
            p.Add(b);
            p.Add(c);
            p.Add(d);

            for (int i = 1; i < p.Count(); i++)
            {
                p[0].DrawLine(g, t, p[i], pictureBox1.Width, pictureBox1.Height, Pens.Black);
            }
        }

        private Transform GetProjection()
        {
            if (ProjectionComboBox.SelectedItem != null)
            {
                switch (ProjectionComboBox.SelectedItem.ToString())
                {
                    case "Изометрическая":
                        {
                            return Transform.IsometricProjection();
                        }

                    case "Перcпективная":
                        {
                            return Transform.PerspectiveProjection(3);
                        }
                }
            }
            return Transform.IsometricProjection();
        }

        private void GetCurrentPolyhedron(Transform t)
        {
            if (comboBox1.SelectedItem != null)
            {
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Тетраэдр":
                        {
                            Tetrahedron tetrahedron = new Tetrahedron(1);
                            tetrahedron.Draw(g, t, pictureBox1.Width, pictureBox1.Height);
                            currentPolyhedron = tetrahedron;
                            break;
                        }
                    case "Гексаэдр":
                        {
                            Hexahedron hexahedron = new Hexahedron(0.5);
                            hexahedron.Draw(g, t, pictureBox1.Width, pictureBox1.Height);
                            currentPolyhedron = hexahedron;
                            break;
                        }
                    case "Октаэдр":
                        {
                            Octahedron octahedron = new Octahedron(1);
                            octahedron.Draw(g, t, pictureBox1.Width, pictureBox1.Height);
                            currentPolyhedron = octahedron;
                            break;
                        }
                    default:
                        {
                            Tetrahedron tetrahedron = new Tetrahedron(0.5);
                            tetrahedron.Draw(g, t, pictureBox1.Width, pictureBox1.Height);
                            currentPolyhedron = new Tetrahedron(0.5);
                            break;
                        }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            GetCurrentPolyhedron(GetProjection());
            DrawAxis(g, GetProjection());
            pictureBox1.Invalidate();
        }

        //масштаб относительно центра
        private void ApplyScaleCenter_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            double C = (double)numericUpDown10.Value;
            currentPolyhedron.Apply(Transform.Scale(C, C, C));
            currentPolyhedron.Draw(g, GetProjection(), pictureBox1.Width, pictureBox1.Height);
            DrawAxis(g, GetProjection());
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            Translate();
            Rotate();
            Scale();

            currentPolyhedron.Draw(g, GetProjection(), pictureBox1.Width, pictureBox1.Height);
            DrawAxis(g, GetProjection());
            pictureBox1.Invalidate();
        }

        private void Translate()
        {
            double X = (double)numericUpDown1.Value;
            double Y = (double)numericUpDown2.Value;
            double Z = (double)numericUpDown3.Value;
            currentPolyhedron.Apply(Transform.Translate(X, Y, Z));
        }

        //Поворот
        private void Rotate()
        {
            double X = (double)numericUpDown4.Value / 180 * Math.PI;
            double Y = (double)numericUpDown5.Value / 180 * Math.PI;
            double Z = (double)numericUpDown6.Value / 180 * Math.PI;
            currentPolyhedron.Apply(Transform.RotateX(X) * Transform.RotateY(Y) * Transform.RotateZ(Z));
        }

        //Масштаб
        private void Scale()
        {
            double X = (double)numericUpDown7.Value;
            double Y = (double)numericUpDown8.Value;
            double Z = (double)numericUpDown9.Value;
            currentPolyhedron.Apply(Transform.Scale(X, Y, Z));

        }

        //Отражение
        private void Reflect()
        {
            switch (comboBox2.SelectedItem.ToString())
            {
                case "Отражение по X":
                    {
                        currentPolyhedron.Apply(Transform.ReflectX());
                        break;
                    }
                case "Отражение по Y":
                    {
                        currentPolyhedron.Apply(Transform.ReflectY());
                        break;
                    }
                case "Отражение по Z":
                    {
                        currentPolyhedron.Apply(Transform.ReflectZ());
                        break;
                    }
                default:
                    {
                        currentPolyhedron.Apply(Transform.ReflectX());
                        break;
                    }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            Reflect();
            currentPolyhedron.Draw(g, GetProjection(), pictureBox1.Width, pictureBox1.Height);
            DrawAxis(g, GetProjection());
            pictureBox1.Invalidate();
        }

        private void ApplyProjection_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            GetCurrentPolyhedron(GetProjection());
            DrawAxis(g, GetProjection());
            pictureBox1.Invalidate();
        }
        private void RotateLine()
        {
            double X1 = (double)numericUpDown13.Value;
            double Y1 = (double)numericUpDown12.Value;
            double Z1 = (double)numericUpDown11.Value;

            double X2 = (double)numericUpDown16.Value;
            double Y2 = (double)numericUpDown15.Value;
            double Z2 = (double)numericUpDown14.Value;

            PointZ p1 = new PointZ(X1, Y1, Z1);
            PointZ p2 = new PointZ(X2, Y2, Z2);

            // p1.DrawLine(g, GetProjection(), p2,pictureBox1.Width,pictureBox1.Height, Pens.Red);

            double ang = (double)numericUpDown17.Value / 180 * Math.PI;

            currentPolyhedron.Apply(Transform.RotateLine(p1, p2, ang));
        }
        private void button4_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            RotateLine();
            currentPolyhedron.Draw(g, GetProjection(), pictureBox1.Width, pictureBox1.Height);
            DrawAxis(g, GetProjection());
            pictureBox1.Invalidate();

        }
    }
}
