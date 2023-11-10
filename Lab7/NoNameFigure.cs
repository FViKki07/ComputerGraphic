﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal class NoNameFigure: Polyhedron
    {

        private PointZ[] vertices; // 6 вершин, 8 граней
        List<List<int>> polygons;

        public NoNameFigure(List<PointZ> points, List<List<int>> p)
        {
            vertices = points.ToArray();
            polygons = p;
        }

        public PointZ[] getVertice()
        {
            return vertices;
        }

        public List<List<int>> getPolygons()
        {
            return polygons;
        }

        public void MinAndMax()
        {
            var MaxX = vertices.OrderBy(x => x.X).Last().X;
            var MinX = vertices.OrderBy(x => x.X).First().X;
            var MaxY = vertices.OrderBy(x => x.Y).Last().Y;
            var MinY = vertices.OrderBy(x => x.Y).First().Y;
            var MaxZ = vertices.OrderBy(x => x.Z).Last().Z;
            var MinZ = vertices.OrderBy(x => x.Z).First().Z;

            double scale = Math.Max(MaxX - MinX, MaxY - MinY);
            scale = Math.Max(scale, MaxZ - MinZ);



        }
        public void Draw(Graphics g, Transform projection, int width, int height)
        {
           // double scaleX = (double)width / 2;
           // double scaleY = (double)height / 2;

          //  this.Apply(Transform.Scale(scaleX, scaleY, 0));

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

        public void Apply(Transform t)
        {
            foreach (var v in vertices)
                v.Apply(t);
        }


    }
}