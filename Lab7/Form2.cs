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
using static System.Formats.Asn1.AsnWriter;

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
        bool figure; 

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
            figure = false;

            points = new List<PointZ>();
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
            if (currentPolyhedron != null && !figure)
            {
                currentPolyhedron.Draw(g1, t, pictureBox1.Width, pictureBox1.Height);
                return;
            }
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
            figure = true;
            GetCurrentPolyhedron(GetProjection());
            figure = false;
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
            if (points.Count >= 2)
            {
                if (comboBox3.SelectedItem != null)
                {
                    steps = ((int)stepsNumericUpDown.Value);
                    // centerPoints();
                    rotationFigure();
                }
                else MessageBox.Show("Выберите ось");

            }
            else MessageBox.Show("Выберите минимум 2 точки");
        }

        private PointZ chooseAxis(PointZ p, float angle)
        {

            switch (comboBox3.SelectedItem.ToString())
            {
                case "по X":
                    {
                        //return p.Apply(Transform.RotateX(angle / 180 * Math.PI));
                        p.Apply(Transform.RotateX(angle / 180 * Math.PI));
                        return p;
                    }
                case "по Y":
                    {
                        p.Apply(Transform.RotateY(angle / 180 * Math.PI));
                        return p;
                    }
                case "по Z":
                    {
                        p.Apply(Transform.RotateZ(angle / 180 * Math.PI));
                        return p;
                    }
                default:
                    {
                        p.Apply(Transform.RotateX(angle / 180 * Math.PI));
                        return p;
                    }
            }
        }
        public void centerPoints()
        {
            double min_x = double.MaxValue;
            double min_y = double.MaxValue;
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].X < min_x)
                {
                    min_x = points[i].X;
                }
                if (points[i].Y < min_y)
                {
                    min_y = points[i].Y;
                }
            }
            for (int i = 0; i < points.Count; i++)
            {
                points[i].X = points[i].X - min_x;
                points[i].Y = points[i].Y - min_y;
            }
        }

        private void rotationFigure()
        {
            float rotAngle = 360f / steps;
            List<PointZ> newPoints = new List<PointZ>();
            List<PointZ> allPoints = new List<PointZ>();
            List<List<int>> polygons = new List<List<int>>();
            int index = 0;
            for (int i = 0; i < steps; i++)
            {
                newPoints.Clear();
                foreach (PointZ point in points)
                {
                    //newPoints.Add(new PointZ(point.X, point.Y, point.Z));
                    //newPoints.Last().Apply(Transform.RotateY(rotAngle / 180 * Math.PI));

                    //allPoints.Add(point);
                    PointZ newp = new PointZ(point.X, point.Y, point.Z);
                    newPoints.Add(chooseAxis(newp, rotAngle));
                    allPoints.Add(point);
                }

                for (int j = 0; j < newPoints.Count - 1; j++)
                {
                    polygons.Add(new List<int>()
                {
                index + j, index + 1 + j, index + newPoints.Count() + j
                });
                    polygons.Add(new List<int>()
                {
                index + j + 1, index + newPoints.Count() + j, index + newPoints.Count() + j + 1
                });
                }
                points.Clear();

                foreach (PointZ point in newPoints)
                    points.Add(point);
                index += points.Count;
            }
            foreach (PointZ point in points)
            {
                //newPoints.Add(new PointZ(point.X, point.Y, point.Z));
                //newPoints.Last().Apply(Transform.RotateY(rotAngle / 180 * Math.PI));
                //allPoints.Add(point);
                PointZ newp = new PointZ(point.X, point.Y, point.Z);
                newPoints.Add(chooseAxis(newp, rotAngle));
                allPoints.Add(point);
            }
            List<int> up = new();
            for (int i = 0; i < steps; i++)
                up.Add(i * points.Count());
            polygons.Add(up);

            List<int> down = new();
            for (int i = 0; i < steps; i++)
                down.Add(i * points.Count() + points.Count() - 1);
            polygons.Add(down);

            currentPolyhedron = new NoNameFigure(allPoints, polygons, 0.005);
            g1.Clear(Color.White);
            currentPolyhedron.Draw(g1, GetProjection(), pictureBox1.Width, pictureBox1.Height);
            DrawAxis(g1, GetProjection());
            pictureBox1.Invalidate();
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

        private float SimpleSquareFunction(float x, float y)
        {
            return x * x + y * y;
        }

        private float SimpleFunction(float x, float y)
        {
            return x * y;
        }

        private void GetFunction()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Obj files (*.obj)|*.obj|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        g1.Clear(Color.White);
                        var filename = openFileDialog.FileName;
                        ParserOBJ parser = new ParserOBJ(filename);
                        currentPolyhedron = parser.LoadFromFile();
                        StringBuilder figureName = new StringBuilder();
                        currentPolyhedron.Draw(g1, GetProjection(), pictureBox1.Width, pictureBox1.Height);
                        DrawAxis(g1, GetProjection());
                        pictureBox1.Invalidate();
                    }
                    catch
                    {
                        DialogResult result = MessageBox.Show("Could not open file",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Obj files (*.obj)|*.obj|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        g1.Clear(Color.White);
                        var filename = openFileDialog.FileName;
                        ParserOBJ parser = new ParserOBJ(filename);
                        currentPolyhedron = parser.LoadFromFile();
                        StringBuilder figureName = new StringBuilder();
                        currentPolyhedron.Draw(g1, GetProjection(), pictureBox1.Width, pictureBox1.Height);
                        DrawAxis(g1, GetProjection());
                        pictureBox1.Invalidate();
                    }
                    catch
                    {
                        DialogResult result = MessageBox.Show("Could not open file",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DrawFromFile()
        {

        }
    }
}

