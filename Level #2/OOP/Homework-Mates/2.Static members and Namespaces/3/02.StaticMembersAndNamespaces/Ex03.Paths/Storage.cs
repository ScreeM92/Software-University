namespace Ex03.Paths
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using StaticMembersAndNamespaces;

    public static class Storage
    {
        public static void Save3DPointsPath(Path3D listOfPoints, string path)
        {
            using (StreamWriter file = new StreamWriter(path))
            {
                for (int i = 0; i < listOfPoints.Count; i++)
                {
                    file.WriteLine(listOfPoints[i]);
                }
            }
        }

        public static Path3D Load3DPointsPath(string path)
        {
            Path3D listofpoints = new Path3D();
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                Regex regex = new Regex(@"(\d+|\d+\.\d+)\,\s*(\d+|\d+\.\d+)\,\s*(\d+|\d+\.\d+)");
                while ((line = reader.ReadLine()) != null)
                {
                    var v = regex.Match(line);
                    double x = double.Parse(v.Groups[1].Value);
                    double y = double.Parse(v.Groups[2].Value);
                    double z = double.Parse(v.Groups[3].Value);
                    listofpoints.AddPoint(x, y, z); // Add to list.
                    Console.WriteLine(line); // Write to console.
                }
            }

            return listofpoints;
        }
    }
}
