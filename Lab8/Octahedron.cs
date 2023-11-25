using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    internal class Octahedron : Polyhedron
    {
        private PointZ[] vertices; // 6 вершин, 8 граней
        private List<List<int>> polygons;

        public Octahedron(double size)
        {
            vertices = new PointZ[6];

            vertices[0] = new PointZ(-size / 2, 0, 0);
            vertices[1] = new PointZ(0, -size / 2, 0);
            vertices[2] = new PointZ(0, 0, -size / 2);
            vertices[3] = new PointZ(size / 2, 0, 0);
            vertices[4] = new PointZ(0, size / 2, 0);
            vertices[5] = new PointZ(0, 0, size / 2);
            polygons = new List<List<int>>();

            polygons.Add(new List<int>() { 0, 2, 4 });
            polygons.Add(new List<int>() { 2, 4, 3 });
            polygons.Add(new List<int>() { 4, 5, 3 });
            polygons.Add(new List<int>() { 0, 5, 4 });
            polygons.Add(new List<int>() { 0, 5, 1 });
            polygons.Add(new List<int>() { 5, 3, 1 });
            polygons.Add(new List<int>() { 0, 2, 1 });
            polygons.Add(new List<int>() { 2, 1, 3 });
        }

        public void Draw(Graphics g, Transform projection, int width, int height)
        {
            for (int i = 0; i < polygons.Count(); i++)
            {
                for (int j = 0; j < polygons[i].Count(); j++)
                {
                    int vertex1 = polygons[i][j];
                    int vertex2 = polygons[i][(j + 1) % 3];
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
                        int vertex2 = v[(i + 1) % 3];
                        vertices[vertex1].DrawLine(g, projection, vertices[vertex2], width, height, Pens.Black);
                    }
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
