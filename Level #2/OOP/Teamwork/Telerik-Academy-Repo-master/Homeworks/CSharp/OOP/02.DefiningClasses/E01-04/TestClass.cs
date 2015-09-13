using System;

class TestClass
{
    static void Main()
    {
        Path path = new Path();

        for (int i = 0; i < 5; i++)
        {
            path.Points.Add((new Point3D("2, 3, 6")));
            path.Points.Add((new Point3D("4, 3, 11")));
        }

        Console.WriteLine(path.Points[5]);

        Console.WriteLine("The distance between points {0} and {1} is equal to {2}", path.Points[4], path.Points[5], DistanceIn3DSpace.CalculateDistance(path.Points[4], path.Points[5]));
        Console.WriteLine("The center of 3D coordinate system is equal to {0}", Point3D.CoordCenter);

        PathStorage.SavePath(path);

        Path newPath = new Path();
        PathStorage.LoadPath(newPath);
        Console.WriteLine(newPath.Points[4]);
    }
}

