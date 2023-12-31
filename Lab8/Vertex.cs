﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    internal class Vertex
    {
        public PointZ Coordinate { get; set; }
        public PointZ Normal { get; set; }
        public Color Color { get; set; }

        public Vertex() { }

        public Vertex(PointZ coordinate, PointZ normal, Color color)
        {
            Coordinate = coordinate;
            Normal = normal;
            Color = color;
        }
    }
}
