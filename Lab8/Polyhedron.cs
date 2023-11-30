using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    interface Polyhedron
    {
        void Draw(Graphics g, Camera camera, Transform projection, int width, int height);
        public List<List<int>> getPolygons();
        public PointZ[] getVertice();
        void Apply(Transform t);
        PointZ Center { get; }
    }
}
