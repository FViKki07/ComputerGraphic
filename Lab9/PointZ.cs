using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    internal class PointZ
    {

        private double[] coords = new double[] { 0, 0, 0, 1 };

        public double X { get { return coords[0]; } set { coords[0] = value; } }
        public double Y { get { return coords[1]; } set { coords[1] = value; } }
        public double Z { get { return coords[2]; } set { coords[2] = value; } }
        public double W
        {
            get { return coords[3]; }
            set { coords[3] = value; }
        }
        public PointZ() { coords[3] = 1; }

        public PointZ(double x, double y, double z)
        {
            coords[0] = x; coords[1] = y; coords[2] = z;
            coords[3] = 1;
        }

        public PointZ(double[] arr)
        {
            coords = arr;
            coords[3] = 1;
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
            Point pt = new Point((int)X, (int)Y);
            return pt;
        }

        // Скалярное произведение векторов
        public static double DotProduct(PointZ u, PointZ v)
        {
            double result = 0;
            result += u.X * v.X;
            result += u.Y * v.Y;
            result += u.Z * v.Z;
            return result;
        }

        // Векторное произведение векторов
        public static PointZ CrossProduct(PointZ u, PointZ v)
        {
            return new PointZ(
                u.Y * v.Z - u.Z * v.Y,
                u.Z * v.X - u.X * v.Z,
                u.X * v.Y - u.Y * v.X);
        }

        public static PointZ operator *(double x, PointZ v)
        {
            v.X *= x; v.Y *= x; v.Z *= x;
            return v;
        }

        public static PointZ operator -(PointZ v)
        {
            return -1 * v;
        }

        public static PointZ operator +(PointZ ths, PointZ other)
        {
            return new PointZ(ths.X + other.X, ths.Y + other.Y, ths.Z + other.Z);
        }
        public static PointZ operator -(PointZ ths, PointZ other)
        {
            return new PointZ(ths.X - other.X, ths.Y - other.Y, ths.Z - other.Z);
        }
        public PointZ Transform(Transform t)
        {
            var p = new PointZ(X, Y, Z);
            p.Apply(t);

            return p;
        }

        public PointZ Normalize()
        {
            double normalization = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
            this.X = X / normalization;
            this.Y = Y / normalization;
            this.Z = Z / normalization;
            this.W = 1; //xs
            return this;
        }

        bool IsNormalize()
        {
            if (X < -1 || X > 1 || Y < -1 || Y > 1 || Z > 1 || Z < -1 || W != 1)
                return false;
            return true;
        }
        private bool Check(int width, int height)
        {

            return
                   !Double.IsInfinity(X) &&
                   !Double.IsInfinity(Y) &&
                   !Double.IsInfinity(Z);
            return ((X >= 0 && X < width) &&
                   (Y >= 0 && Y < height) &&
                   (Z < 1) && (Z > -1));
        }
        /*
 * Преобразует координаты из ([-1, 1], [-1, 1], [-1, 1]) в ([0, width), [0, height), [-1, 1]).
 */
        public PointZ NormalizedToDisplay(int width, int height)
        {
            //if(!this.IsNormalize())
            // this.Normalize();
            var x = (X / coords[3] + 1) / 2 * width;
            var y = (-Y / coords[3] + 1) / 2 * height;
            return new PointZ(x, y, Z / coords[3]);

        }

        public void DrawLine(Graphics g, Camera camera, Transform projection, PointZ B, int width, int height, Pen p)
        {
            var c = this.Transform(projection).NormalizedToDisplay(width, height);
            var d = B.Transform(projection).NormalizedToDisplay(width, height);
            if (c.Check(width, height) && d.Check(width, height))
                g.DrawLine(p, (float)c.X, (float)c.Y, (float)d.X, (float)d.Y);

        }

    }
}
