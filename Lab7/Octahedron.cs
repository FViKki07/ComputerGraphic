using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal class Octahedron: Polyhedron
    {
        private PointZ[] vertices; // 6 вершин, 8 граней

        public Octahedron(double size)
        {
            vertices = new PointZ[6];

            vertices[0] = new PointZ(-size / 2, 0, 0);
            vertices[1] = new PointZ(0, -size / 2, 0);
            vertices[2] = new PointZ(0, 0, -size / 2);
            vertices[3] = new PointZ(size / 2, 0, 0);
            vertices[4] = new PointZ(0, size / 2, 0);
            vertices[5] = new PointZ(0, 0, size / 2);
        }

        public void Draw(Graphics g, Transform projection, int width, int height)
        {
            int[][] edges = new int[8][];

            edges[0] = new int[] { 0, 2, 4 };
            edges[1] = new int[] { 2, 4, 3 };
            edges[2] = new int[] { 4, 5, 3 };
            edges[3] = new int[] { 0, 5, 4 };
            edges[4] = new int[] { 0, 5, 1 };
            edges[5] = new int[] { 5, 3, 1 };
            edges[6] = new int[] { 0, 2, 1 };
            edges[7] = new int[] { 2, 1, 3 };

            //Pen[] pens = { Pens.Red, Pens.Green, Pens.Yellow, Pens.Orange, Pens.Purple, Pens.Blue };

            for (int i = 0; i < edges.Length; i++)
            {
                for (int j = 0; j < edges[i].Length; j++)
                {
                    int vertex1 = edges[i][j];
                    int vertex2 = edges[i][(j + 1) % 3];
                    vertices[vertex1].DrawLine(g, projection, vertices[vertex2], width, height, Pens.Black);
                }
            }
        }


        public PointZ[] getVertice()
        {
            return vertices;
        }

        public List<List<int>> getPolygons()
        {
            return null;
            //return polygons;
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
                for (int i = 0; i < 6; i++)
                {
                    p.X += vertices[i].X;
                    p.Y += vertices[i].Y;
                    p.Z += vertices[i].Z;
                }
                p.X /= 6;
                p.Y /= 6;
                p.Z /= 6;
                return p;
            }
        }
    }
}
