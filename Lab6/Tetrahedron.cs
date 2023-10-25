﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Tetrahedron
    {
        private PointZ[] vertices;

        public Tetrahedron(double size)
        {
            vertices = new PointZ[4];

            double h = Math.Sqrt(2.0 / 3.0) * size;

            vertices[0] = new PointZ(-size / 2, 0, h / 3);
            vertices[1] = new PointZ(0, 0, -h * 2 / 3);
            vertices[2] = new PointZ(size / 2, 0, h / 3);
            vertices[3] = new PointZ(0, h, 0);
        }

        public void Draw(Graphics g, Transform projection, int width, int height)
        {
            int[] edge1 = { 0, 1, 2 };
            int[] edge2 = { 0, 1, 3 };
            int[] edge3 = { 1, 2, 3 };
            int[] edge4 = { 0, 2, 3 };

            int[][] edges = { edge1, edge2, edge3, edge4 };

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
    }

}