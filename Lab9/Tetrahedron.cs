using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    internal class Tetrahedron : Polyhedron
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

            polygons.Add(new List<int> { 0, 1, 2 });
            polygons.Add(new List<int> { 1, 3, 0 });
            polygons.Add(new List<int> { 2, 3, 1 });
            polygons.Add(new List<int> { 0, 3, 2 });

        }

        public void Draw(Graphics g, Camera camera, Transform projection, int width, int height)
        {
            //int[][] edges = new int[4][];

            //for (int i = 0; i < 4; i++)
            //{
            //    edges[i] = new int[3];
            //    for (int j = 0; j < 3; j++)
            //    {
            //        edges[i][j] = (j + i) % 4;
            //    }
            //}

            for (int i = 0; i < polygons.Count(); i++)
            {
                for (int j = 0; j < polygons[i].Count(); j++)
                {
                    int vertex1 = polygons[i][j];
                    int vertex2 = polygons[i][(j + 1) % 3];
                    vertices[vertex1].DrawLine(g, camera, projection, vertices[vertex2], width, height, Pens.Black);
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
