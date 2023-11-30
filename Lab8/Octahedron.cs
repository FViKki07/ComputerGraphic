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

        public void Draw(Graphics g, Camera camera, Transform projection, int width, int height)
        {
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
