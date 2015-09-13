using System;
using System.IO;

static class PathStorage
{
    public static void SavePath(Path points)
    {
        StreamWriter writePath = new StreamWriter("path.txt");
        using (writePath)
        {
            for (int i = 0; i < points.Points.Count; i++)
            {
                writePath.WriteLine(points.Points[i]);
            }
        }
    }

    public static void LoadPath(Path loaded)
    {
        StreamReader readPath = new StreamReader("path.txt");
        using (readPath)
        {
            while (true)
            {
                string point = readPath.ReadLine();
                if (point == null)
                {
                    break;
                }
                loaded.Points.Add(new Point3D(point));
            }
        }
    }
}