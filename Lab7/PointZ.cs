using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal class PointZ
    {
        private double[] coords = new double[] { 0, 0, 0, 1 };

        public double X { get { return coords[0]; } set { coords[0] = value; } }
        public double Y { get { return coords[1]; } set { coords[1] = value; } }
        public double Z { get { return coords[2]; } set { coords[2] = value; } }

        public PointZ() { }

        public PointZ(double x, double y, double z)
        {
            coords[0] = x; coords[1] = y; coords[2] = z;
        }

        public PointZ(double[] arr)
        {
            coords = arr;
        }

        public void Apply(Transform t)
        {
            double[] newCoords = new double[4];
            for (int i = 0; i < 4; ++i)
            {
                newCoords[i] = 0;
                for (int j = 0; j < 4; ++j)
                    newCoords[i] += coords[j] * t.Matrix[j, i];
            }
            coords = newCoords;
        }

        public Point getPoint()
        {
            Point pt = new Point((int)X,(int)Y);
            return pt;
        }


        public PointZ Transform(Transform t)
        {
            var p = new PointZ(X, Y, Z);
            p.Apply(t);
            return p;
        }

        /*
 * Преобразует координаты из ([-1, 1], [-1, 1], [-1, 1]) в ([0, width), [0, height), [-1, 1]).
 */
        public PointZ NormalizedToDisplay(int width, int height)
        {
            var x = (X / coords[3] + 1) / 2 * width;
            var y = (-Y / coords[3] + 1) / 2 *  height;
            return new PointZ(x, y, Z);
        }

        public void DrawLine(Graphics g, Transform projection, PointZ B, int width, int height, Pen p)
        {
            var c = this.Transform(projection).NormalizedToDisplay(width, height);
            var d = B.Transform(projection).NormalizedToDisplay(width, height);
            g.DrawLine(p, (float)c.X, (float)c.Y, (float)d.X, (float)d.Y);
        }
    }
}
