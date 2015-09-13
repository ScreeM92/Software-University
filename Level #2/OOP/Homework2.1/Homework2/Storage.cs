using System;
using System.IO;
static class Storage
{
    public static void savePath(Point3D p1, Point3D p2)
    {
        StreamWriter writer = new StreamWriter("test.txt");

        using (writer)
        {
            writer.WriteLine(DistanceCalcolator.CalculateDistance(p1, p2));
        }
    }

    public static string loadPath(string path)
    {
        StreamReader reader = new StreamReader(path);
        string result = "";

        using(reader)
        {
            result += reader.ReadLine();
        }

        return result;
    }
}

