using System.Security.Cryptography.Xml;

namespace Lab6
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();

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
                            break;
                        }
                    case "Гексаэдр":
                        {
                            Hexahedron hexahedron = new Hexahedron(0.5);
                            hexahedron.Draw(g, t, pictureBox1.Width, pictureBox1.Height);
                            break;
                        }
                    case "Октаэдр":
                        {
                            Octahedron octahedron = new Octahedron(1);
                            octahedron.Draw(g, t, pictureBox1.Width, pictureBox1.Height);
                            break;
                        }
                    default:
                        {
                            Tetrahedron tetrahedron = new Tetrahedron(0.5);
                            tetrahedron.Draw(g, t, pictureBox1.Width, pictureBox1.Height);
                            break;
                        }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            DrawAxis(g, Transform.IsometricProjection());
            GetCurrentPolyhedron(Transform.IsometricProjection());
            pictureBox1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}