using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab7
{
     class ParserOBJ
    {

        string file;

        public ParserOBJ(string f) { this.file = f; }

        public ParserOBJ() { file = null; }

        public void SaveToFile(string path, Polyhedron pol)
        {
            
            using(var fr = new StreamWriter(path, false))
            {

                var p = pol.getPolygons();
                var points = pol.getVertice();

                for (int i = 0; i < points.Length; i++)
                {
                    fr.WriteLine("v " + points[i].X + " " + points[i].Y + " " + points[i].Z);

                }

                for (int i = 0; i < p.Count; i++)
                {
                    fr.Write("f ");
                    for (int j=0; j < p[i].Count;j++)
                        fr.Write(p[i][j]+" ");
                    fr.WriteLine("");
                }
            }
        }
    }
}
