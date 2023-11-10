using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal class Object3D
    {
        private List<Triangle> triangles;

        public Object3D()
        {
            triangles = new List<Triangle>();
        }
        public Object3D(List<Triangle> tr)
        {
            triangles = new List<Triangle>(tr);
        }

        public PointZ Center
        {
            get
            {
                double sumX = 0;
                double sumY = 0;
                double sumZ = 0;
                foreach (Triangle tr in triangles)
                {
                    sumX += tr.Center.X;
                    sumY += tr.Center.Y;
                    sumZ += tr.Center.Z;

                }
                return new PointZ(sumX / triangles.Count, sumY / triangles.Count, sumZ / triangles.Count);
            }
        }

        public void Draw(Graphics g, Transform projection, int width, int height)
        {
            foreach (Triangle tr in triangles)
            {
                tr.Draw(g, projection, width, height);
            }
        }
    }
}
