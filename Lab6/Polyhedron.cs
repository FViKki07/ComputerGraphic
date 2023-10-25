using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    interface Polyhedron
    {
        void Draw(Graphics g, Transform projection, int width, int height);
        void Apply(Transform t);
        PointZ Center { get; }
    }
}
