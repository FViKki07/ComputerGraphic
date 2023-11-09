﻿using System;
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
        Graphics g1, g2;
        Bitmap bmp1, bmp2;
        Polyhedron currentPolyhedron;
        List<PointZ> points;
        int steps;
        Func<float, float, float> function;

        public Form2()
        {
            InitializeComponent();
            comboBox1.SelectedItem = comboBox1.Items[0];
            comboBox2.SelectedItem = comboBox2.Items[0];
            //Создаем Bitmap и Graphics для PictureBox
            bmp1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g1 = Graphics.FromImage(bmp1);
            pictureBox1.Image = bmp1;
            g1.Clear(Color.White);
            bmp2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g2 = Graphics.FromImage(bmp2);
            pictureBox2.Image = bmp2;
            g2.Clear(Color.White);
            comboBox1.SelectedItem = 0;

            points = new List<PointZ>();

            functiounComboBox.Items.AddRange(new object[] { "10sin(x) + 10sin(y)", "x + y" });

            DrawAxis(g1, Transform.IsometricProjection());
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
                            tetrahedron.Draw(g1, t, pictureBox1.Width, pictureBox1.Height);
                            currentPolyhedron = tetrahedron;
                            break;
                        }
                    case "Гексаэдр":
                        {
                            Hexahedron hexahedron = new Hexahedron(0.5);
                            hexahedron.Draw(g1, t, pictureBox1.Width, pictureBox1.Height);
                            currentPolyhedron = hexahedron;
                            break;
                        }
                    case "Октаэдр":
                        {
                            Octahedron octahedron = new Octahedron(1);
                            octahedron.Draw(g1, t, pictureBox1.Width, pictureBox1.Height);
                            currentPolyhedron = octahedron;
                            break;
                        }
                    default:
                        {
                            Tetrahedron tetrahedron = new Tetrahedron(0.5);
                            tetrahedron.Draw(g1, t, pictureBox1.Width, pictureBox1.Height);
                            currentPolyhedron = new Tetrahedron(0.5);
                            break;
                        }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g1.Clear(Color.White);
            GetCurrentPolyhedron(GetProjection());
            DrawAxis(g1, GetProjection());
            pictureBox1.Invalidate();
        }

        //масштаб относительно центра
        private void ApplyScaleCenter_Click(object sender, EventArgs e)
        {
            g1.Clear(Color.White);
            double C = (double)numericUpDown10.Value;
            currentPolyhedron.Apply(Transform.Scale(C, C, C));
            currentPolyhedron.Draw(g1, GetProjection(), pictureBox1.Width, pictureBox1.Height);
            DrawAxis(g1, GetProjection());
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g1.Clear(Color.White);
            Translate();
            Rotate();
            Scale();

            currentPolyhedron.Draw(g1, GetProjection(), pictureBox1.Width, pictureBox1.Height);
            DrawAxis(g1, GetProjection());
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
            g1.Clear(Color.White);
            Reflect();
            currentPolyhedron.Draw(g1, GetProjection(), pictureBox1.Width, pictureBox1.Height);
            DrawAxis(g1, GetProjection());
            pictureBox1.Invalidate();
        }

        private void ApplyProjection_Click(object sender, EventArgs e)
        {
            g1.Clear(Color.White);
            GetCurrentPolyhedron(GetProjection());
            DrawAxis(g1, GetProjection());
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
            g1.Clear(Color.White);
            RotateLine();
            currentPolyhedron.Draw(g1, GetProjection(), pictureBox1.Width, pictureBox1.Height);
            DrawAxis(g1, GetProjection());
            pictureBox1.Invalidate();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            g1.Clear(Color.White);
            g2.Clear(Color.White);
            DrawAxis(g1, Transform.IsometricProjection());
            points.Clear();
            pictureBox1.Invalidate();
            pictureBox2.Invalidate();
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            PointZ newp = new PointZ(e.X, e.Y, 0);
            points.Add(newp);
            g2.DrawEllipse(Pens.Red, e.X, e.Y, 3, 3);
            g2.FillEllipse(Brushes.Red, e.X, e.Y, 3, 3);
            if (points.Count > 1)
                for (int i = 0; i < points.Count - 1; i++)
                {
                    g2.DrawLine(Pens.Red, points[i].getPoint(), points[i + 1].getPoint());
                }

            pictureBox2.Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            steps = ((int)stepsNumericUpDown.Value);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var path = figure.Name + ".obj";


            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Title = "Save as...";
            sfd.CheckPathExists = true;
            sfd.Filter = "OBJ Files(*.obj)|*.obj";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ParserOBJ parser = new ParserOBJ();
                    parser.SaveToFile(sfd.FileName, currentPolyhedron);
                }
                catch
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }






        ///////////// Task3

        private float SinFunction(float x, float y)
        {
            return (float)(10 * Math.Sin(x) + 10 * Math.Sin(y));
        }

        private float AdditionFunction(float x, float y)
        {
            return (float)(x + y);
        }
       
        private void GetFunction()
        {
            if (functiounComboBox.SelectedItem != null)
            {
                switch (functiounComboBox.SelectedItem.ToString())
                {
                    case "10sin(x) + 10sin(y)":
                        {
                            function = (x, y) => SinFunction(x, y); break;
                        }
                    case "x + y":
                        {
                            function = (x, y) => AdditionFunction(x, y); break;
                        }
                }
            }
        }
    }
}

