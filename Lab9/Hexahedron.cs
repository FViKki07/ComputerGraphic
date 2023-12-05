using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.DataFormats;

namespace Lab9
{
    internal class Hexahedron : Polyhedron
    {
        private Form form1 = new Form1();
        private PointZ[] vertices; // 8 вершин, 6 граней
        private List<List<int>> polygons;
        public Color Color { get; set; }
        public Hexahedron(double size)
        {
            Color = Color.LightCoral;
            vertices = new PointZ[8];
            polygons = new List<List<int>>();
            vertices[0] = new PointZ(-size / 2, -size / 2, -size / 2);
            vertices[1] = new PointZ(-size / 2, -size / 2, size / 2);
            vertices[2] = new PointZ(-size / 2, size / 2, -size / 2);
            vertices[3] = new PointZ(size / 2, -size / 2, -size / 2);
            vertices[4] = new PointZ(-size / 2, size / 2, size / 2);
            vertices[5] = new PointZ(size / 2, -size / 2, size / 2);
            vertices[6] = new PointZ(size / 2, size / 2, -size / 2);
            vertices[7] = new PointZ(size / 2, size / 2, size / 2);

            polygons.Add(new List<int>() { 0, 1, 5, 3 });
            polygons.Add(new List<int>() { 2, 6, 3, 0 });
            polygons.Add(new List<int>() { 4, 1, 0, 2 });
            polygons.Add(new List<int>() { 7, 5, 3, 6 });
            polygons.Add(new List<int>() { 2, 4, 7, 6 });
            polygons.Add(new List<int>() { 4, 1, 5, 7 });
        }


        public void Draw(Graphics g, Camera camera, Transform projection, int width, int height)
        {
            for (int i = 0; i < polygons.Count; i++)
            {
                for (int j = 0; j < polygons[i].Count; j++)
                {
                    int vertex1 = polygons[i][j];
                    int vertex2 = polygons[i][(j + 1) % 4];
                    vertices[vertex1].DrawLine(g, camera, projection, vertices[vertex2], width, height, Pens.Black);
                }
            }
        }

        public List<List<int>> getPolygons()
        {
            return polygons;
        }


        public PointZ[] getVertice()
        {
            return vertices;
        }
        public void Apply(Transform t)
        {
            foreach (var v in vertices)
                v.Apply(t);
        }

        public PointZ Center
        {
            get
            {
                PointZ p = new PointZ(0, 0, 0);
                for (int i = 0; i < 8; i++)
                {
                    p.X += vertices[i].X;
                    p.Y += vertices[i].Y;
                    p.Z += vertices[i].Z;
                }
                p.X /= 8;
                p.Y /= 8;
                p.Z /= 8;
                return p;
            }
           
        }

    }
}
