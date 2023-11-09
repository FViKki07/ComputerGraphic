using System;
using System.Collections.Generic;
using System.IO;
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

        public void LoadFromFile(List<PointZ> points, List<List<int>> polygons)
        {
            //List<PointZ> points = new List<PointZ>();
            //List<List<int>> polygons = new List<List<int>>();
            using (var fs = new StreamReader(file))
            {
                while (!fs.EndOfStream)
                {
                    string line = fs.ReadLine().Trim();
                    //if (line[0] == '#')
                    // continue;
                    switch (line[0])
                    {

                        case 'v':
                            {
                                var point = line.Substring(1).Split(' ');
                                points.Add(new PointZ(double.Parse(point[0]), double.Parse(point[1]), double.Parse(point[2])));
                                break;
                            }
                        case 'f':
                            {
                                var polygon = line.Substring(1).Split(' ');
                                List<int> p = new List<int>();
                                for(int i = 0;i< polygon.Count(); i++)
                                {
                                    p.Add(int.Parse(polygon[i].Split('/').First()));

                                }
                                polygons.Add(p);
                                break;
                            }
                        default:
                            {
                                break;
                            } 

                    }
                }
            }
           // Mesh res = new Mesh(triangles);
            //return res;
        }
    }
}
