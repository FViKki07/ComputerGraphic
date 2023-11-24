using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    internal class Graphics3D
    {
        private Graphics graphics;
        public Bitmap ColorBuffer { get; set; }
        private double[,] ZBuffer { get; set; }

        public Transform Transformation { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public PointZ CamPosition;
        public Graphics3D(Graphics graphics, Transform transformation, int width, int height, PointZ pos)
        {
            this.graphics = graphics;
            Transformation = transformation;
            Width = width;
            Height = height;
            CamPosition = pos;

            ColorBuffer = new Bitmap(Width, Height);
            ZBuffer = new double[Width, Height];

            for (int j = 0; j < Height; ++j)
                for (int i = 0; i < (Width); ++i)
                    ZBuffer[i, j] = double.MaxValue;

        }
        private void Interpolate(Vertex a, Vertex b, double f, ref Vertex v)
        {
            v.Coordinate = Interpolate(a.Coordinate, b.Coordinate, f);
            v.Normal = Interpolate(a.Normal, b.Normal, f);
            v.Color = Interpolate(a.Color, b.Color, f);
        }

        private double Interpolate(double x0, double x1, double f)
        {
            return x0 + (x1 - x0) * f;
        }

        private long Interpolate(long x0, long x1, double f)
        {
            return x0 + (long)((x1 - x0) * f);
        }
        private static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }
        private Vertex GetScene(Vertex vertex)
        {
            return new Vertex(vertex.Coordinate.NormalizedToDisplay(Width, Height), vertex.Normal, vertex.Color);
        }
        public void DrawTriangle(Vertex first, Vertex second, Vertex third, Graphics g1)
        {
            // Преобразуем вершины из трехмерного пространства в пространство экрана
            first = GetScene(first);
            second = GetScene(second);
            third = GetScene(third);

            // Сортировка вершин по их координатам Y
            if (first.Coordinate.Y > second.Coordinate.Y)
                Swap(ref first, ref second);
            if (first.Coordinate.Y > third.Coordinate.Y)
                Swap(ref first, ref third);
            if (second.Coordinate.Y > third.Coordinate.Y)
                Swap(ref second, ref third);

            Vertex l = new Vertex();
            Vertex r = new Vertex();
            Vertex p = new Vertex();

            for (double y = first.Coordinate.Y; y < third.Coordinate.Y; ++y)
            {
                // Пропускаем рисование, если текущая координата Y находится за пределами экрана
                if (y < 0 || y > (Height - 1))
                    continue;

                bool topHalf = y < second.Coordinate.Y;

                var f0 = first;
                var f1 = third;
                Interpolate(f0, f1, (y - f0.Coordinate.Y) / (f1.Coordinate.Y - f0.Coordinate.Y), ref l);

                var ff0 = topHalf ? first : second;
                var ff1 = topHalf ? second : third;
                Interpolate(ff0, ff1, (y - ff0.Coordinate.Y) / (ff1.Coordinate.Y - ff0.Coordinate.Y), ref r);

                if (l.Coordinate.X > r.Coordinate.X)
                    Swap(ref l, ref r);

                for (double x = l.Coordinate.X; x < r.Coordinate.X; ++x)
                {
                    // Пропускаем рисование, если текущая координата X находится за пределами экрана
                    if (x < 0 || x > (Width - 1))
                        continue;

                    Interpolate(l, r, (x - l.Coordinate.X) / (r.Coordinate.X - l.Coordinate.X), ref p);

                    // Пропускаем рисование, если текущая глубина вершины находится за пределами диапазона
                    if (p.Coordinate.Z > 1 || p.Coordinate.Z < -1)
                        continue;

                    // Обновление буфера глубины и буфера цвета
                    if (p.Coordinate.Z < ZBuffer[(int)x, (int)y])
                    {
                        ZBuffer[(int)x, (int)y] = p.Coordinate.Z;

                       // g1.FillEllipse(new SolidBrush(p.Color), (int)x, (int)y, 1, 1);
                        ColorBuffer.SetPixel((int)x, (int)y, p.Color);
                    }
                }
            }
        }

        private Color Interpolate(Color a, Color b, double f)
        {
            return Color.FromArgb((byte)Interpolate(a.R, b.R, f),
                (byte)Interpolate(a.G, b.G, f), (byte)Interpolate(a.B, b.B, f));
        }

        private PointZ Interpolate(PointZ a, PointZ b, double f)
        {
            return new PointZ(
                Interpolate(a.X, b.X, f),
                Interpolate(a.Y, b.Y, f),
                Interpolate(a.Z, b.Z, f));
        }
    }
}
