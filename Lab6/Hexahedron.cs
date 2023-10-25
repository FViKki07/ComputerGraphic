using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Hexahedron
    {
        private PointZ[] vertices; // 8 вершин, 6 граней

        public Hexahedron(double size)
        {
            vertices = new PointZ[8];

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

            edges[0] = new int[] { 0, 1, 5, 3 };
            edges[1] = new int[] { 2, 6, 3, 0 };
            edges[2] = new int[] { 4, 1, 0, 2 };
            edges[3] = new int[] { 7, 5, 3, 6 };
            edges[4] = new int[] { 2, 4, 7, 6 };
            edges[5] = new int[] { 4, 1, 5, 7 };

            //Pen[] pens = { Pens.Red, Pens.Green, Pens.Yellow, Pens.Orange, Pens.Purple, Pens.Blue};

            for (int i = 0; i < edges.Length; i++)
            {
                for (int j = 0; j < edges[i].Length; j++)
                {
                    int vertex1 = edges[i][j];
                    int vertex2 = edges[i][(j + 1) % 4];
                    vertices[vertex1].DrawLine(g, projection, vertices[vertex2], width, height, Pens.Black);
                }
            }
        }
    }
}
