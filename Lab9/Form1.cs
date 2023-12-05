using Lab9;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab9
{
    public partial class Form1 : Form
    {
        bool zB;
        Random random = new Random();
        // private ZBufferRenderer renderer;
        // float[,] zBuffer;
        //Color[,] colorBuffer;
        Graphics g1, g2;
        Bitmap bmp1, bmp2;
        Polyhedron currentPolyhedron;
        List<PointZ> points;
        int steps;
        Func<float, float, float> function;
        bool figure;
        Camera camera;
        public static bool cameraUse;
        Light light;
        bool guro;
        bool non_face;

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedItem = comboBox1.Items[0];
            comboBox2.SelectedItem = comboBox2.Items[0];
            ProjectionComboBox.SelectedItem = ProjectionComboBox.Items[0];
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
            non_face = false;
            zB = false;
            points = new List<PointZ>();
            guro = false;
            functiounComboBox.Items.AddRange(new object[] { "10 * sin(x) + 10 * sin(y)", "10 * cos(x) * cos(y)", "x^2 / 100" });


            DrawAxis(g1, Transform.IsometricProjection());
            camera = new Camera(new PointZ(0, 0, 2), 0, new PointZ(0, 0, 0), pictureBox1.Width, pictureBox1.Height);
            cameraUse = false;
            light = new Light(new PointZ(0, 0, 2), Color.Orange);
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
                p[0].DrawLine(g, camera, t, p[i], pictureBox1.Width, pictureBox1.Height, Pens.Black);
            }
        }

        private Transform GetProjection()
        {
            if (ProjectionComboBox.SelectedItem != null)
            {
                switch (ProjectionComboBox.SelectedItem.ToString())
                {
                    case "Перспективная":
                        {
                            return Transform.PerspectiveProjection(2, camera);

                        }
                    case "Изометрическая":
                        {
                            return Transform.IsometricProjection();
                        }
                    case "Ортогональная XY":
                        {
                            return Transform.OrthographicXYProjection();
                        }
                    case "Ортогональная XZ":
                        {
                            return Transform.OrthographicXZProjection();
                        }
                    case "Ортогональная YZ":
                        {
                            return Transform.OrthographicYZProjection();
                        }
                    default:
                        {
                            return Transform.IsometricProjection();
                        }/*
                    case "Изометрическая":
                        {
                            return Transform.IsometricProjection();
                        }

                    case "Перcпективная":
                        {
                            var projection = Transform.PerspectiveProjection(-0.1, 0.1, -0.1, 0.1, 0.1, 20);
                            camera = new Camera(new PointZ(1, 1, 1), Math.PI / 4, -Math.PI / 4, projection);
                            return camera.ViewProjection;
                            //return Transform.PerspectiveProjection(2,camera);
                        }*/
                }
            }
            return Transform.IsometricProjection();
        }

        private Transform GetProjectionAxis()
        {
            if (ProjectionComboBox.SelectedItem != null)
            {
                switch (ProjectionComboBox.SelectedItem.ToString())
                {
                    case "Перспективная":
                        {
                            return Transform.PerspectiveProjection(2, camera);

                        }
                    case "Изометрическая":
                        {
                            return Transform.IsometricProjection();

                        }
                    case "Ортогональная XY":
                        {
                            return Transform.OrthographicXZProjection();
                        }
                    case "Ортогональная XZ":
                        {

                            return Transform.OrthographicXZProjection();
                        }
                    case "Ортогональная YZ":
                        {
                            return Transform.OrthographicYZProjection();
                        }
                    default:
                        {
                            return Transform.IsometricProjection();
                        }
                }
            }
            return Transform.IsometricProjection();
        }


        private void GetCurrentPolyhedron(Transform t)
        {
            if (currentPolyhedron != null && !figure)
            {
                //currentPolyhedron.Draw(g1, t, pictureBox1.Width, pictureBox1.Height);
                return;
            }
            if (comboBox1.SelectedItem != null)
            {
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Тетраэдр":
                        {
                            currentPolyhedron = new Tetrahedron(1);
                            break;
                        }
                    case "Гексаэдр":
                        {
                            currentPolyhedron = new Hexahedron(0.5);
                            break;
                        }
                    case "Октаэдр":
                        {
                            currentPolyhedron = new Octahedron(1);
                            break;
                        }
                    default:
                        {

                            Tetrahedron tetrahedron = new Tetrahedron(1);
                            tetrahedron.Draw(g1, camera, t, pictureBox1.Width, pictureBox1.Height);
                            currentPolyhedron = new Tetrahedron(1);
                            break;
                        }
                }
            }
        }
        void DrawWithoutNonFace(Graphics g, Transform projection, int width, int height, Polyhedron cur, PointZ CameraPosition)
        {
            foreach (var v in cur.getPolygons())
            {
                var vertices = cur.getVertice();
                PointZ p1 = vertices[v[0]];
                PointZ p2 = vertices[v[1]];
                PointZ p3 = vertices[v[2]];

                PointZ v1 = new PointZ(p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z);
                PointZ v2 = new PointZ(p3.X - p1.X, p3.Y - p1.Y, p3.Z - p1.Z);

                PointZ normal = PointZ.CrossProduct(v1, v2);

                double d = -(normal.X * p1.X + normal.Y * p1.Y + normal.Z * p1.Z);

                var Center = cur.Center;
                PointZ pp = new PointZ(p1.X + normal.X, p1.Y + normal.Y, p1.Z + normal.Z);
                double val1 = normal.X * pp.X + normal.Y * pp.Y + normal.Z * pp.Z + d;
                double val2 = normal.X * Center.X + normal.Y * Center.Y + normal.Z * Center.Z + d;

                if (val1 * val2 > 0)
                {
                    normal.X = -normal.X;
                    normal.Y = -normal.Y;
                    normal.Z = -normal.Z;
                }

                if (PointZ.DotProduct(normal, CameraPosition) + PointZ.DotProduct(normal, p1) < 0)
                {
                    for (int i = 0; i < v.Count; i++)
                    {
                        int vertex1 = v[i];
                        int vertex2 = v[(i + 1) % v.Count];
                        vertices[vertex1].DrawLine(g, camera, projection, vertices[vertex2], width, height, Pens.Black);
                    }
                }
            }
        }

        private void DrawingSelection(Polyhedron cur)
        {
            if (currentPolyhedron != null)
            {
                if (non_face)
                {
                    DrawWithoutNonFace(g1, GetProjection(), pictureBox1.Width, pictureBox1.Height, currentPolyhedron, camera.Position);
                }
                else if (zB)
                {
                    zBuf();
                }
                else if (guro)
                {
                    CalculateNormal(light);
                }
                else
                {
                    currentPolyhedron.Draw(g1, camera, GetProjection(), pictureBox1.Width, pictureBox1.Height);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            g1.Clear(Color.White);
            zB = false;
            figure = true;
            non_face = false;
            guro = false;
            GetCurrentPolyhedron(GetProjection());
            DrawingSelection(currentPolyhedron);
            figure = false;
            //DrawAxis(g1, GetProjectionAxis());
            pictureBox1.Invalidate();
        }

        //масштаб относительно центра
        private void ApplyScaleCenter_Click(object sender, EventArgs e)
        {
            g1.Clear(Color.White);
            double C = (double)numericUpDown10.Value;
            currentPolyhedron.Apply(Transform.Scale(C, C, C));

            DrawingSelection(currentPolyhedron);
            // DrawAxis(g1, GetProjectionAxis());

            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g1.Clear(Color.White);
            Translate();
            Rotate();
            Scale();

            DrawingSelection(currentPolyhedron);

            //DrawAxis(g1, GetProjectionAxis());

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


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.W:
                    if (camera.Position.Y < 2)
                    {
                        //camera.move(new PointZ(0, 0.5f, 0));
                        currentPolyhedron.Apply(Transform.Translate(new PointZ(0, -0.5f, 0)));
                    }
                    break;
                case Keys.A:
                    if (camera.Position.X > -2)
                    {
                        //camera.move(new PointZ(-0.5f, 0, 0));
                        currentPolyhedron.Apply(Transform.Translate(new PointZ(0.5f, 0, 0)));
                    }
                    break;
                case Keys.S:
                    if (camera.Position.Y > -2)
                    {
                        //camera.move(new PointZ(0, -0.5f, 0));
                        currentPolyhedron.Apply(Transform.Translate(new PointZ(0, 0.5f, 0)));
                    }
                    break;
                case Keys.D:
                    if (camera.Position.X < 2)
                    {
                        //camera.move(new PointZ(0.5f, 0, 0));
                        currentPolyhedron.Apply(Transform.Translate(new PointZ(-0.5f, 0, 0)));
                    }
                    break;
                case Keys.Q:
                    //camera.Position += new PointZ(0, 0, -0.5f);
                    currentPolyhedron.Apply(Transform.Translate(new PointZ(0, 0, 0.5f)));
                    break;
                case Keys.E:
                    //camera.Position += new PointZ(0, 0, 0.5f);
                    currentPolyhedron.Apply(Transform.Translate(new PointZ(0, 0, -0.5f)));
                    break;
                case Keys.F:
                    if (Math.Abs(camera.Rotation) <= 90)
                    {
                        //camera.move(new PointZ(-0.5f, 0, 0));
                        currentPolyhedron.Apply(Transform.RotateX(0) * Transform.RotateY(-10.0 / 180 * Math.PI) * Transform.RotateZ(0));
                    }
                    break;
                case Keys.H:
                    if (Math.Abs(camera.Rotation) <= 90)
                    {
                        currentPolyhedron.Apply(Transform.RotateX(0) * Transform.RotateY(10.0 / 180 * Math.PI) * Transform.RotateZ(0));

                    }
                    break;
                case Keys.T:
                    if (Math.Abs(camera.Rotation) < 90)
                    {
                        currentPolyhedron.Apply(Transform.RotateX(10.0 / 180 * Math.PI) * Transform.RotateY(0) * Transform.RotateZ(0));
                    }
                    break;
                case Keys.G:
                    if (Math.Abs(camera.Rotation) <= 90)
                    {

                        currentPolyhedron.Apply(Transform.RotateX(-10.0 / 180 * Math.PI) * Transform.RotateY(0) * Transform.RotateZ(0));
                    }
                    break;
            }
            g1.Clear(Color.White);
            //currentPolyhedron.Draw(g1, GetProjection(), pictureBox1.Width, pictureBox1.Height);
            DrawingSelection(currentPolyhedron);
            //DrawAxis(g1, GetProjectionAxis());
            pictureBox1.Invalidate();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g1.Clear(Color.White);
            Reflect();
            //currentPolyhedron.Draw(g1, GetProjection(), pictureBox1.Width, pictureBox1.Height);
            DrawingSelection(currentPolyhedron);
            //DrawAxis(g1, GetProjectionAxis());
            pictureBox1.Invalidate();
        }
        private void ApplyProjection_Click(object sender, EventArgs e)
        {
            g1.Clear(Color.White);
            GetCurrentPolyhedron(GetProjection());

            DrawingSelection(currentPolyhedron);
            DrawAxis(g1, GetProjectionAxis());

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

            DrawingSelection(currentPolyhedron);
            //DrawAxis(g1, GetProjectionAxis());

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
                    centerPoints();
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
        private void reflectAxis()
        {
            switch (comboBox3.SelectedItem.ToString())
            {
                case "по X":
                    {
                        currentPolyhedron.Apply(Transform.ReflectX());
                        break;
                    }
                case "по Y":
                    {
                        currentPolyhedron.Apply(Transform.ReflectY());
                        currentPolyhedron.Apply(Transform.Translate(0, 1, 0));
                        break;
                    }
                case "по Z":
                    {
                        currentPolyhedron.Apply(Transform.ReflectZ());
                        break;
                    }
                default:
                    {
                        currentPolyhedron.Apply(Transform.ReflectY());
                        currentPolyhedron.Apply(Transform.Translate(0, 1, 0));
                        break;
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

            var maxX = allPoints.OrderBy(x => x.X).Last().X;
            var maxY = allPoints.OrderBy(x => x.Y).Last().Y;
            var maxZ = allPoints.OrderBy(x => x.Z).Last().Z;

            currentPolyhedron = new NoNameFigure(allPoints, polygons, 0.005);
            reflectAxis();
            g1.Clear(Color.White);

            currentPolyhedron.Draw(g1, camera, GetProjection(), pictureBox1.Width, pictureBox1.Height);

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

        private float SinFunction(float x, float y)
        {
            return (float)(10 * Math.Sin(x) + 10 * Math.Sin(y));
        }

        private float AdditionFunction(float x, float y)
        {
            return (float)(x * x) / 100;
        }
        private float CosFunction(float x, float y)
        {
            return (float)(10 * Math.Cos(x) * Math.Cos(y));
        }

        private void GetUserFunction()
        {
            if (functiounComboBox.SelectedItem != null)
            {
                switch (functiounComboBox.SelectedItem.ToString())
                {
                    case "10 * sin(x) + 10 * sin(y)":
                        {
                            function = (x, y) => SinFunction(x, y); break;
                        }
                    case "10 * cos(x) * cos(y)":
                        {
                            function = (x, y) => CosFunction(x, y); break;
                        }
                    case "x^2 / 100":
                        {
                            function = (x, y) => AdditionFunction(x, y); break;
                        }
                }
            }
        }

        public void GetFunctionFigure(int x0, int y0, int x1, int y1, int steps, Func<float, float, float> func)
        {
            List<PointZ> newPoints = new List<PointZ>();
            List<PointZ> allPoints = new List<PointZ>();
            List<PointZ> oldPoints = new List<PointZ>();
            List<List<int>> polygons = new List<List<int>>();
            float stepX = (x1 - x0) * 1.0f / steps;
            float stepY = (y1 - y0) * 1.0f / steps;
            float dx = -(x1 + x0) / 2.0f;
            float dy = -(y1 + y0) / 2.0f;

            int index = 0;
            for (int i = 0; i <= steps; i++)
            {
                for (int j = 0; j <= steps; j++)
                {
                    float x = x0 + i * stepX;
                    float y = y0 + j * stepY;
                    float z = func(x, y);

                    newPoints.Add(new PointZ(dx + x, dy + y, z));
                    allPoints.Add(new PointZ(dx + x, dy + y, z));
                }

                if (oldPoints.Count > 0)
                {
                    for (int x = 0; x < oldPoints.Count - 1; x++)
                    {
                        polygons.Add(new List<int>
                        {
                            index + x,
                            index + x + 1,
                            index + newPoints.Count + x
                        });
                        polygons.Add(new List<int>()
                        {
                            index + x + 1,
                            index + newPoints.Count() + x,
                            index + newPoints.Count() + x + 1
                        });
                    }
                    index += newPoints.Count();
                }
                oldPoints.Clear();
                oldPoints.AddRange(newPoints);
                newPoints.Clear();
            }

            currentPolyhedron = new NoNameFigure(allPoints, polygons, 0.008);
            g1.Clear(Color.White);
            currentPolyhedron.Draw(g1, camera, GetProjection(), pictureBox1.Width, pictureBox1.Height);
            DrawAxis(g1, GetProjection());
            pictureBox1.Invalidate();
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
                        currentPolyhedron.Draw(g1, camera, GetProjection(), pictureBox1.Width, pictureBox1.Height);
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
                        currentPolyhedron.Draw(g1, camera, GetProjection(), pictureBox1.Width, pictureBox1.Height);
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
            //List<Triangle> triangles = new List<Triangle>();
            //triangles.Add(t1);
            //triangles.Add(t2);
            //triangles.Add(t3);
            //Obgect3D obgect3D = new Obgect3D(triangles);
            //obgect3D.Draw(g1,GetProjection(),pictureBox1.Width, pictureBox1.Height);
            //pictureBox1.Invalidate();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GetUserFunction();

            if (function == null)
            {
                MessageBox.Show("Выберите функцию!");
            }
            else
            {
                GetFunctionFigure((int)x0NumericUpDown.Value, (int)y0NumericUpDown.Value, (int)x1NumericUpDown.Value, (int)y1NnumericUpDown.Value, (int)stepsNumericUpDown.Value, function);
            }
        }

        //BUF Z
        private void Interpolate(Vertex a, Vertex b, double f, ref Vertex v)
        {
            v.Coordinate = Interpolate(a.Coordinate, b.Coordinate, f);
            v.Normal = Interpolate(a.Normal, b.Normal, f);
            v.Color = Interpolate(a.Color, b.Color, f);
        }

        private double Interpolate(double x0, double x1, double f)
        {
            return x0 + (x1 - x0) * f;
        }
        private Color Interpolate(Color a, Color b, double f)
        {
            return Color.FromArgb((byte)Interpolate(a.R, b.R, f),
                (byte)Interpolate(a.G, b.G, f), (byte)Interpolate(a.B, b.B, f));
        }

        private PointZ Interpolate(PointZ a, PointZ b, double f)
        {
            return new PointZ(
                Interpolate(a.X, b.X, f),
                Interpolate(a.Y, b.Y, f),
                Interpolate(a.Z, b.Z, f));
        }
        private long Interpolate(long x0, long x1, double f)
        {
            return x0 + (long)((x1 - x0) * f);
        }
        private static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }
        private Vertex GetScene(Vertex vertex)
        {
            return new Vertex(vertex.Coordinate.NormalizedToDisplay(pictureBox1.Width, pictureBox1.Height), vertex.Normal, vertex.Color);
        }
        void DrawBufferZ(ref double[,] ZBuffer, int width, int height, Vertex first, Vertex second, Vertex third)
        {

            // Преобразуем вершины из трехмерного пространства в пространство экрана
            first = GetScene(first);
            second = GetScene(second);
            third = GetScene(third);

            // Сортировка вершин по их координатам Y
            if (first.Coordinate.Y > second.Coordinate.Y)
                Swap(ref first, ref second);
            if (first.Coordinate.Y > third.Coordinate.Y)
                Swap(ref first, ref third);
            if (second.Coordinate.Y > third.Coordinate.Y)
                Swap(ref second, ref third);

            Vertex l = new Vertex();
            Vertex r = new Vertex();
            Vertex p = new Vertex();

            for (double y = first.Coordinate.Y; y < third.Coordinate.Y; ++y)
            {
                // Пропускаем рисование, если текущая координата Y находится за пределами экрана
                if (y < 0 || y > (height - 1))
                    continue;

                bool topHalf = y < second.Coordinate.Y;

                var f0 = first;
                var f1 = third;
                Interpolate(f0, f1, (y - f0.Coordinate.Y) / (f1.Coordinate.Y - f0.Coordinate.Y), ref l);

                var ff0 = topHalf ? first : second;
                var ff1 = topHalf ? second : third;
                Interpolate(ff0, ff1, (y - ff0.Coordinate.Y) / (ff1.Coordinate.Y - ff0.Coordinate.Y), ref r);

                if (l.Coordinate.X > r.Coordinate.X)
                    Swap(ref l, ref r);

                for (double x = l.Coordinate.X; x < r.Coordinate.X; ++x)
                {
                    // Пропускаем рисование, если текущая координата X находится за пределами экрана
                    if (x < 0 || x > (width - 1))
                        continue;

                    Interpolate(l, r, (x - l.Coordinate.X) / (r.Coordinate.X - l.Coordinate.X), ref p);

                    // Пропускаем рисование, если текущая глубина вершины находится за пределами диапазона
                    if (p.Coordinate.Z > 1 || p.Coordinate.Z < -1)
                        continue;

                    // Обновление буфера глубины и буфера цвета
                    if (p.Coordinate.Z < ZBuffer[(int)x, (int)y])
                    {
                        ZBuffer[(int)x, (int)y] = p.Coordinate.Z;

                        g1.DrawEllipse(new Pen(p.Color), (int)x, (int)y, 1, 1);
                        g1.FillEllipse(new SolidBrush(p.Color), (int)x, (int)y, 1, 1);
                        //pictureBox1.Invalidate();
                        // ColorBuffer.SetPixel((int)x, (int)y, p.Color);
                    }
                }
            }
        }





        private void zBuf()
        {
            double[,] ZBuffer = new double[pictureBox1.Width, pictureBox1.Height];

            for (int j = 0; j < pictureBox1.Height; ++j)
                for (int i = 0; i < pictureBox1.Width; ++i)
                    ZBuffer[i, j] = double.MaxValue;
            var indpolygons = currentPolyhedron.getPolygons();

            var pointZ = currentPolyhedron.getVertice();
            List<List<PointZ>> points = new List<List<PointZ>>();

            for (int i = 0; i < indpolygons.Count; i++)
            {
                if (indpolygons[i].Count() == 4)
                {
                    points.Add(new List<PointZ> { pointZ[indpolygons[i][0]], pointZ[indpolygons[i][1]], pointZ[indpolygons[i][2]], pointZ[indpolygons[i][3]] });

                }
                else
                    points.Add(new List<PointZ> { pointZ[indpolygons[i][0]], pointZ[indpolygons[i][1]], pointZ[indpolygons[i][2]] });
            }

            Random r = new Random(256);

            foreach (var verge in points)
            {
                int k = r.Next(0, 256);
                int k2 = r.Next(0, 256);
                int k3 = r.Next(0, 256);

                for (int i = 1; i < verge.Count - 1; ++i)
                {

                    var a = new Vertex(verge[0], new PointZ(), Color.FromArgb(k2, k, k3));
                    var b = new Vertex(verge[i], new PointZ(), Color.FromArgb(k2, k, k3));
                    var c = new Vertex(verge[i + 1], new PointZ(), Color.FromArgb(k2, k, k3));
                    // g1.DrawTriangle(a, b, c);
                    //Graphics3D ggg = new Graphics3D(g1, GetProjection(), pictureBox1.Width, pictureBox1.Height, new PointZ(0, 0, 1));
                    DrawBufferZ(ref ZBuffer, pictureBox1.Width, pictureBox1.Height, a, b, c);
                }
            }

            currentPolyhedron = new NoNameFigure(pointZ.ToList(), indpolygons);
        }

        public void zBufForGuro()
        {
            double[,] ZBuffer = new double[pictureBox1.Width, pictureBox1.Height];

            for (int j = 0; j < pictureBox1.Height; ++j)
                for (int i = 0; i < pictureBox1.Width; ++i)
                    ZBuffer[i, j] = double.MaxValue;
            var indpolygons = currentPolyhedron.getPolygons();

            var pointZ = currentPolyhedron.getVertice();
            List<List<PointZ>> points = new List<List<PointZ>>();

            for (int i = 0; i < indpolygons.Count; i++)
            {
                if (indpolygons[i].Count() == 4)
                {
                    points.Add(new List<PointZ> { pointZ[indpolygons[i][0]], pointZ[indpolygons[i][1]], pointZ[indpolygons[i][2]], pointZ[indpolygons[i][3]] });

                }
                else
                    points.Add(new List<PointZ> { pointZ[indpolygons[i][0]], pointZ[indpolygons[i][1]], pointZ[indpolygons[i][2]] });
            }

            Random r = new Random(256);

            foreach (var verge in points)
            {

                for (int i = 1; i < verge.Count - 1; ++i)
                {
                    var a = verge[0].vert;
                    var b = verge[i].vert;
                    var c = verge[i + 1].vert;

                    //var a = new Vertex(verge[0], new PointZ(), Color.FromArgb(k2, k, k3));
                    //var b = new Vertex(verge[i], new PointZ(), Color.FromArgb(k2, k, k3));
                    //var c = new Vertex(verge[i + 1], new PointZ(), Color.FromArgb(k2, k, k3));
                    // g1.DrawTriangle(a, b, c);
                    //Graphics3D ggg = new Graphics3D(g1, GetProjection(), pictureBox1.Width, pictureBox1.Height, new PointZ(0, 0, 1));
                    DrawBufferZ(ref ZBuffer, pictureBox1.Width, pictureBox1.Height, a, b, c);
                }
            }
            currentPolyhedron = new NoNameFigure(pointZ.ToList(), indpolygons);
        }

        private void buttonNonFace_Click(object sender, EventArgs e)
        {
            non_face = true;
            zB = false;
            guro = false;
            g1.Clear(Color.White);
            figure = true;
            //GetCurrentPolyhedron(GetProjection());
            DrawingSelection(currentPolyhedron);
            figure = false;
           // DrawAxis(g1, GetProjection());
            pictureBox1.Invalidate();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            camera = new Camera(new PointZ(0, 0, 1), 0, new PointZ(0, 0, 0), pictureBox1.Width, pictureBox1.Height);
            non_face = false;
            zB = true;
            guro = false;
            g1.Clear(Color.White);
            figure = true;
            //GetCurrentPolyhedron(GetProjection());
            DrawingSelection(currentPolyhedron);
            figure = false;
            //DrawAxis(g1, GetProjection());
            pictureBox1.Invalidate();
        }

        private void buttonHoryzont_Click(object sender, EventArgs e)
        {
            FloatingHorizon form = new FloatingHorizon();
            form.Show();
        }

        void CalculateNormal(Light light)
        {
            var polygons = currentPolyhedron.getPolygons();
            var vertices = currentPolyhedron.getVertice();
            foreach (var v in polygons)
            {
                PointZ v0 = vertices[v[0]];
                PointZ v1 = vertices[v[1]];
                PointZ v2 = vertices[v[2]];

                PointZ edge1 = v1 - v0;
                PointZ edge2 = v2 - v0;

                PointZ normal = PointZ.CrossProduct(edge1, edge2);

                for (int i = 0; i < v.Count(); i++)
                {
                    var currentVert = vertices[v[i]].vert;
                    currentVert.Coordinate = vertices[v[i]];
                    if (currentVert.Countnormal == 0)
                    {
                        currentVert.Countnormal = 1;
                        currentVert.Normal = normal.Normalize();
                    }
                    else
                    {
                        currentVert.Countnormal += 1;
                        currentVert.Normal += normal;
                        currentVert.Normal /= currentVert.Countnormal;
                        currentVert.Normal = currentVert.Normal.Normalize();
                    }
                    var lightDirection = (light.position - currentVert.Coordinate).Normalize();
                    var dotpro = PointZ.DotProduct(currentVert.Normal, lightDirection);
                    if (dotpro != 0)
                    {
                        var b = 4;
                    }
                    var cosLambert = Math.Max(0, dotpro);//проверить, что тут до 1

                    //посмотреть, что тут до 255
                    int red = (int)(currentPolyhedron.Color.R * cosLambert);
                    int green = (int)(currentPolyhedron.Color.G * cosLambert) ;
                    int blue = (int)(currentPolyhedron.Color.B * cosLambert) ;

                    currentVert.Color = Color.FromArgb(red, green, blue);

                }
            }

            zBufForGuro();
        }

        private void GuroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guro = true;
            zB = false;
            non_face = false;
            figure = true;
            g1.Clear(Color.White);
            CalculateNormal(light);
            figure = false;
            pictureBox1.Invalidate();
        }
    }
}