using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.DataFormats;

namespace Lab8
{
    internal class Hexahedron : Polyhedron
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

            polygons.Add(new List<int>() { 0, 1, 5, 3 });
            polygons.Add(new List<int>() { 2, 6, 3, 0 });
            polygons.Add(new List<int>() { 4, 1, 0, 2 });
            polygons.Add(new List<int>() { 7, 5, 3, 6 });
            polygons.Add(new List<int>() { 2, 4, 7, 6 });
            polygons.Add(new List<int>() { 4, 1, 5, 7 });
        }


        public void Draw(Graphics g, Transform projection, int width, int height)
        {
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


        public void DrawWithoutNonFace(Graphics g, Transform projection, int width, int height)
        {
            PointZ fakeCameraPosition = new PointZ(0, 0, 1);

            foreach (var v in polygons)
            {
                PointZ p1 = vertices[v[0]];
                PointZ p2 = vertices[v[1]];
                PointZ p3 = vertices[v[2]];

                PointZ v1 = new PointZ(p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z);
                PointZ v2 = new PointZ(p3.X - p1.X, p3.Y - p1.Y, p3.Z - p1.Z);

                PointZ normal = PointZ.CrossProduct(v1, v2);
              
                double d = -(normal.X * p1.X + normal.Y * p1.Y + normal.Z * p1.Z);

                PointZ pp = new PointZ(p1.X + normal.X, p1.Y + normal.Y, p1.Z + normal.Z);
                double val1 = normal.X * pp.X + normal.Y * pp.Y + normal.Z * pp.Z + d;
                double val2 = normal.X * Center.X + normal.Y * Center.Y + normal.Z * Center.Z + d;

                if (val1 * val2 > 0)
                {
                    normal.X = -normal.X;
                    normal.Y = -normal.Y;
                    normal.Z = -normal.Z;
                }

                if (normal.X * (-fakeCameraPosition.X) + normal.Y * (-fakeCameraPosition.Y) + normal.Z * (-fakeCameraPosition.Z) + normal.X * p1.X + normal.Y * p1.Y + normal.Z * p1.Z < 0)
                {
                    for (int i = 0; i < v.Count(); i++)
                    {
                        int vertex1 = v[i];
                        int vertex2 = v[(i + 1) % 4];
                        vertices[vertex1].DrawLine(g, projection, vertices[vertex2], width, height, Pens.Black);
                    }
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
