using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal class Hexahedron: Polyhedron
    {
        private PointZ[] vertices; // 8 вершин, 6 граней
        private List<List<int>> polygons;

        public Hexahedron(double size)
        {
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
        }
        public void Draw(Graphics g, Transform projection, int width, int height)
        {
            int[][] edges = new int[6][];

            polygons.Add(new List<int>() { 0, 1, 5, 3 });
            polygons.Add( new List<int>() { 2, 6, 3, 0 });
            polygons.Add( new List<int>() { 4, 1, 0, 2 });
            polygons.Add( new List<int>() { 7, 5, 3, 6 });
            polygons.Add( new List<int>() { 2, 4, 7, 6 });
            polygons.Add( new List<int>() { 4, 1, 5, 7 });

            //Pen[] pens = { Pens.Red, Pens.Green, Pens.Yellow, Pens.Orange, Pens.Purple, Pens.Blue};

            for (int i = 0; i < polygons.Count; i++)
            {
                for (int j = 0; j < polygons[i].Count; j++)
                {
                    int vertex1 = polygons[i][j];
                    int vertex2 = polygons[i][(j + 1) % 4];
                    vertices[vertex1].DrawLine(g, projection, vertices[vertex2], width, height, Pens.Black);
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
