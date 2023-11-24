using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab8
{
    internal class NoNameFigure : Polyhedron
    {

        private PointZ[] vertices; // 6 вершин, 8 граней
        List<List<int>> polygons;

        public NoNameFigure(List<PointZ> points, List<List<int>> p)
        {
            vertices = points.ToArray();
            polygons = p;
        }

        public NoNameFigure(List<PointZ> points, List<List<int>> p, double size)
        {
            vertices = points.ToArray();
            polygons = p;
            for (int i = 0; i < vertices.Count(); i++)
            {
                vertices[i].X *= size;
                vertices[i].Y *= size;
                vertices[i].Z *= size;

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

        public PointZ Center
        {
            get
            {
                var MaxX = vertices.OrderBy(x => x.X).Last().X;
                var MinX = vertices.OrderBy(x => x.X).First().X;
                var MaxY = vertices.OrderBy(x => x.Y).Last().Y;
                var MinY = vertices.OrderBy(x => x.Y).First().Y;
                var MaxZ = vertices.OrderBy(x => x.Z).Last().Z;
                var MinZ = vertices.OrderBy(x => x.Z).First().Z;

                double meanX = (MinX + MaxX) / 2;
                double meanY = (MinY + MaxY) / 2;
                double meanZ = (MinZ + MaxZ) / 2;

                PointZ p = new PointZ(meanX, meanY, meanZ);
                return p;
            }
        }

        public void Draw(Graphics g, Transform projection, int width, int height)
        {
            for (int i = 0; i < polygons.Count; i++)
            {
                for (int j = 0; j < polygons[i].Count - 1; j++)
                {
                    int vertex1 = polygons[i][j];
                    int vertex2 = polygons[i][j + 1];
                    vertices[vertex1].DrawLine(g, projection, vertices[vertex2], width, height, Pens.Black);
                }
                vertices[polygons[i][0]].DrawLine(g, projection, vertices[polygons[i][polygons[i].Count - 1]], width, height, Pens.Black);
            }
        }
        public void DrawWithoutNonFace(Graphics g, Transform projection, int width, int height)
        {
            PointZ fakeCameraPosition = new PointZ(0, 0, 0);

            foreach (var v in polygons)
            {
                PointZ p1 = vertices[v[0]];
                PointZ p2 = vertices[v[1]];
                PointZ p3 = vertices[v[2]];

                PointZ v1 = new PointZ(p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z);
                PointZ v2 = new PointZ(p3.X - p1.X, p3.Y - p1.Y, p3.Z - p1.Z);

                PointZ normal = PointZ.CrossProduct(v1, v2);
                double normalization = Math.Sqrt(Math.Pow(normal.X, 2) + Math.Pow(normal.Y, 2) + Math.Pow(normal.Z, 2));
                normal.X /= normalization;
                normal.Y /= normalization;
                normal.Z /= normalization;

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
                    for (int i = 0; i < polygons.Count; i++)
                    {
                        for (int j = 0; j < polygons[i].Count - 1; j++)
                        {
                            int vertex1 = polygons[i][j];
                            int vertex2 = polygons[i][j + 1];
                            vertices[vertex1].DrawLine(g, projection, vertices[vertex2], width, height, Pens.Black);
                        }
                        vertices[polygons[i][0]].DrawLine(g, projection, vertices[polygons[i][polygons[i].Count - 1]], width, height, Pens.Black);
                    }
                }
            }
        }

        public void Apply(Transform t)
        {
            foreach (var v in vertices)
                v.Apply(t);
        }


    }
}
