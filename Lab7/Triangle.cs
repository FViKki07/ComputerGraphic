using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Lab7
{
    internal class Triangle
    {
        private PointZ[] points;

        public Triangle(List<PointZ> p)
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

        public void reflectX()
        {
            for (int i = 0; i < points.Length; i++)
                points[i].Apply(Transform.ReflectX());
        }
        public void reflectY()
        {
            for (int i = 0; i < points.Length; i++)
                points[i].Apply(Transform.ReflectY());
        }
        public void reflectZ()
        {
            for (int i = 0; i < points.Length; i++)
                points[i].Apply(Transform.ReflectZ());
        }

        public void translate(float x, float y, float z)
        {
            for (int i = 0; i < points.Length; i++)
                points[i].Apply(Transform.Translate(x, y, z));
        }

        public void rotateX(double angle)
        {
            for (int i = 0; i < points.Length; i++)
                points[i].Apply(Transform.RotateX(angle));
        }
        public void rotateY(double angle)
        {
            for (int i = 0; i < points.Length; i++)
                points[i].Apply(Transform.RotateY(angle));
        }
        public void rotateZ(double angle)
        {
            for (int i = 0; i < points.Length; i++)
                points[i].Apply(Transform.RotateZ(angle));
        }
        public void rotateLine(double angle, PointZ p1, PointZ p2)
        {
            for (int i = 0; i < points.Length; i++)
                points[i].Apply(Transform.RotateLine(p1, p2, angle));
        }
        public void scale(float fx, float fy, float fz)
        {
            for (int i = 0; i < points.Length; i++)
                points[i].Apply(Transform.Scale(fx, fy, fz));
        }

        public void Draw(Graphics g, Transform projection, int width, int height)
        {
            for (int i = 0; i < points.Length; i++)
            {
                PointZ p1 = points[i];
                PointZ p2 = points[(i + 1) % 3];
                p1.DrawLine(g, projection, p2, width, height, Pens.Red);
            }
        }


    }
}
