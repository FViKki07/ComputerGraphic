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
                    fr.WriteLine("v " + points[i].X.ToString().Replace(',','.') + " " + points[i].Y.ToString().Replace(',', '.') + " " + points[i].Z.ToString().Replace(',', '.'));

                }

                for (int i = 0; i < p.Count; i++)
                {
                    fr.Write("f ");
                    for (int j=0; j < p[i].Count;j++)
                        fr.Write((p[i][j] + 1)+" ");
                    fr.WriteLine("");
                }
            }
        }


        public static double mtdGetDouble(string Value)
        {
            var new_val =Value.Replace('.', ',');
            if (Value[0] == '-')
                return Convert.ToDouble(new_val.Substring(1)) * (-1);
            return Convert.ToDouble(new_val);
        }

        public NoNameFigure LoadFromFile()
        {

            List<PointZ> points = new List<PointZ>();
            List<List<int>> polygons = new List<List<int>>();
            using (var fs = new StreamReader(file))
            {
                while (!fs.EndOfStream)
                {
                    string line = fs.ReadLine().Trim();
                    if (line.Count() == 0)
                       continue;
                    switch (line[0])
                    {

                        case 'v':
                            {
                                if (line[1] == 't' || line[1] == 'n')
                                    break;
                                var point = line.Split(' ');
                                if (point[1] == "")
                                    points.Add(new PointZ(mtdGetDouble(point[2]), mtdGetDouble(point[3]), mtdGetDouble(point[4])));
                                else
                                    points.Add(new PointZ(mtdGetDouble(point[1]), mtdGetDouble(point[2]), mtdGetDouble(point[3])));
                                break;
                            }
                        case 'f':
                            {
                                var polygon = line.Split(' ');
                                List<int> p = new List<int>();
                                for(int i = 1;i< polygon.Count(); i++)
                                {
                                    var c = polygon[i].Split('/');
                                    p.Add(int.Parse(c.First()) - 1);

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

            var maxX = points.OrderBy(x => x.X).Last().X;
            var minX = points.OrderBy(x => x.X).First().X;
            var maxY = points.OrderBy(x => x.Y).Last().Y;
            var minY = points.OrderBy(x => x.Y).First().Y;
            var maxZ = points.OrderBy(x => x.Z).Last().Z;
            var minZ = points.OrderBy(x => x.Z).First().Z;

            double meanX = (minX + maxX) / 2;
            double meanY = (minY + maxY) / 2;
            double meanZ = (minZ + maxZ) / 2;

            foreach (var p in points)
                p.Apply(Transform.Translate(-meanX, -meanY, -meanZ));

            maxX = points.OrderBy(x => x.X).Last().X;
            maxY = points.OrderBy(x => x.Y).Last().Y;
            maxZ = points.OrderBy(x => x.Z).Last().Z;

            foreach (var p in points)
            {
                p.X = p.X / maxX;
                p.Y = p.Y / maxY;
                p.Z = p.Z / maxZ;
                p.Apply(Transform.FlipY());
            }

            NoNameFigure nn = new NoNameFigure(points, polygons);
            return nn;
        }



    }
}
