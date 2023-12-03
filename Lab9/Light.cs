using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    internal class Light
    {

        public PointZ position { get; set; }
        public Color color { get; set; }

        public Light(PointZ p, Color color) { 
            this.position = p;
            this.color = color;
        }
    }
}
