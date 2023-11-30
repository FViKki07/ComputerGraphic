using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    internal class Transform
    {
        private double[,] matrix = new double[4, 4];

        public double[,] Matrix { get { return matrix; } }

        public Transform()
        {
            matrix = Identity().matrix;
        }

        public Transform(double[,] matrix)
        {
            this.matrix = matrix;
        }

        public static Transform Translate(PointZ v)
        {
            return Translate(v.X, v.Y, v.Z);
        }

        public static Transform RotateX(double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Transform(
                new double[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, cos, -sin, 0 },
                    { 0, sin, cos, 0 },
                    { 0, 0, 0, 1 }
                });
        }

        public static Transform RotateY(double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Transform(
                new double[,]
                {
                    { cos, 0, sin, 0 },
                    { 0, 1, 0, 0 },
                    { -sin, 0, cos, 0 },
                    { 0, 0, 0, 1 }
                });
        }

        public static Transform RotateZ(double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Transform(
                new double[,]
                {
                    { cos, -sin, 0, 0 },
                    { sin, cos, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                });
        }

        public static Transform RotateLine(PointZ p1,PointZ p2, double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            double l = Math.Sign(p2.X - p1.X);
            double m = Math.Sign(p2.Y - p1.Y);
            double n = Math.Sign(p2.Z - p1.Z);
            double length = Math.Sqrt(l * l + m * m + n * n);
            l /= length; m /= length; n /= length;
            return new Transform(
                new double[,]
                {
                   { l * l + cos * (1 - l * l),   l * (1 - cos) * m + n * sin,   l * (1 - cos) * n - m * sin,  0  },
                   { l * (1 - cos) * m - n * sin,   m * m + cos * (1 - m * m),    m * (1 - cos) * n + l * sin,  0 },
                   { l * (1 - cos) * n + m * sin,  m * (1 - cos) * n - l * sin,    n * n + cos * (1 - n * n),   0 },
                   {            0,                            0,                             0,               1   }
                });

        }

        public static Transform Scale(double fx, double fy, double fz)
        {
            return new Transform(
                new double[,] {
                    { fx, 0, 0, 0 },
                    { 0, fy, 0, 0 },
                    { 0, 0, fz, 0 },
                    { 0, 0, 0, 1 }
                });
        }

        public static Transform Translate(double dx, double dy, double dz)
        {
            return new Transform(
                new double[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { dx, dy, dz, 1 },
                });
        }

        public static Transform FlipY()
        {
            return new Transform(
                new double[,] {
            { 1, 0, 0, 0 },
            { 0, -1, 0, 0 }, // Отражение по Y
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
                });
        }

        public static Transform Identity()
        {
            return new Transform(
                new double[,] {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                });
        }


        public static Transform ReflectX()
        {
            return Scale(-1, 1, 1);
        }

        public static Transform ReflectY()
        {
            return Scale(1, -1, 1);
        }

        public static Transform ReflectZ()
        {
            return Scale(1, 1, -1);
        }

        public static Transform OrthographicXYProjection()
        {
            return Identity();
        }

        public static Transform OrthographicXZProjection()
        {
            return Identity() * RotateX(-Math.PI / 2);
        }

        public static Transform OrthographicYZProjection()
        {
            return Identity() * RotateY(Math.PI / 2);
        }

        public static Transform IsometricProjection()
        {
            return Identity() * RotateY(Math.PI / 4) * RotateX(-Math.PI / 4);
        }

        /*public static Transform PerspectiveProjection(double left, double right, double bottom, double top, double near, double far)
        {
            var a = 2 * near / (right - left);
            var b = (right + left) / (right - left);
            var c = 2 * near / (top - bottom);
            var d = (top + bottom) / (top - bottom);
            var e = -(far + near) / (far - near);
            var f = -2 * far * near / (far - near);
            return new Transform(
                new double[4, 4] {
                    { a, 0, 0, 0 },
                    { 0, c, 0, 0 },
                    { b, d, e, -1 },
                    { 0, 0, f, 0 }
                });
            return new Transform(
                new double[4, 4] {
                    { a, 0, b, 0 },
                    { 0, c, d, 0 },
                    { 0, 0, e, f },
                    { 0, 0, -1, 0 }
                     });
        }*/
        public static Transform PerspectiveProjection(float k, Camera camera)
        {
            float aspectRatio = camera.AspectRatio;
            float n = 0.1f;
            float f = 100.0f;


            return camera.LookAt() *  new Transform(
                new double[,] {
            { (1.0 / (Math.Tan(camera.alpha / 2) * aspectRatio)), 0, 0, 0 },
            { 0, (1.0 / Math.Tan(camera.alpha / 2)), 0, 0 },
            { 0, 0, -(f + n) / (f - n), -1 },
            { 0, 0, -2.0 * f * n / (f - n), 0 }
                });
            //return new Transform(
            //    new double[,] {
            //{ (1.0 / (Math.Tan(camera.alpha / 2) * aspectRatio)), 0, 0, 0 },
            //{ 0, (1.0 / Math.Tan(camera.alpha / 2)), 0, 0 },
            //{ 0, 0, (f + n) / (f - n), 1 },
            //{ 0, 0, 2.0 * f * n / (f - n), 0 }
            //    });
            return new Transform(
                new double[,] {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 0, -1/k },
                    { 0, 0, 0, 1 }
                });
    }

        public static Transform operator *(Transform t1, Transform t2)
        {
            double[,] matrix = new double[4, 4];
            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 4; ++j)
                {
                    matrix[i, j] = 0;
                    for (int k = 0; k < 4; ++k)
                        matrix[i, j] += t1.matrix[i, k] * t2.matrix[k, j];
                }
            return new Transform(matrix);
        }
    }
}
