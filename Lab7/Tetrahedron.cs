using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal class Tetrahedron: Polyhedron
    {
        private PointZ[] vertices; // 4 вершины, 4 грани
        private List<List<int>> polygons;

        public Tetrahedron(double size)
        {
            vertices = new PointZ[4]; 
            polygons = new List<List<int>>();
            double h = Math.Sqrt(2.0 / 3.0) * size;

            vertices[0] = new PointZ(-size / 2, 0, h / 3);
            vertices[1] = new PointZ(0, 0, -h * 2 / 3);
            vertices[2] = new PointZ(size / 2, 0, h / 3);
            vertices[3] = new PointZ(0, h, 0);
        }

        public void Draw(Graphics g, Transform projection, int width, int height)
        {
            int[][] edges = new int[4][];

            for (int i = 0; i < 4; i++)
            {
                edges[i] = new int[3];
                for (int j = 0; j < 3; j++)
                {
                    edges[i][j] = (j + i) % 4;
                }
            }

            for (int i = 0; i < edges.Length; i++)
            {
                for (int j = 0; j < edges[i].Length; j++)
                {
                    int vertex1 = edges[i][j];
                    int vertex2 = edges[i][(j + 1) % 3];
                    vertices[vertex1].DrawLine(g, projection, vertices[vertex2], width, height, Pens.Black);
                    polygons.Add(new List<int>() { vertex1, vertex2 });
                }
            }
        }

        public PointZ[] getVertice()
        {
            return vertices;
        }

        public List<List<int>> getPolygons()
        {
            return polygons;
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
                for (int i = 0; i < 4; i++)
                {
                    p.X += vertices[i].X;
                    p.Y += vertices[i].Y;
                    p.Z += vertices[i].Z;
                }
                p.X /= 4;
                p.Y /= 4;
                p.Z /= 4;
                return p;
            }
        }
    }

}
