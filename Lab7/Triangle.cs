using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal class Triangle
    {
        private PointZ[] points;

        public Triangle(ICollection<PointZ> p)
        {
            points = new PointZ[3];
            for (int i = 0; i < 3; i++)
                points[i] = p.ElementAt(i);
        }

        public Triangle(PointZ p1, PointZ p2, PointZ p3)
        {
            points = new PointZ[3] { p1, p2, p3 };
        }

        public PointZ Center
        {
            get
            {
                return new PointZ(points.Sum(p => p.X) / 3, points.Sum(p => p.Y) / 3, points.Sum(p => p.Z) / 3);
            }
        }

    }
}
