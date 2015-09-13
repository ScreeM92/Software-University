using System;
using System.Threading;
using System.Globalization;

//public class Point
//{
//    private double x;
//    private double y;
//    private double z;
//    private static readonly Point startPoint;

//    public double X { get { return this.x; } }
//    public double Y { get { return this.y; } }
//    public double Z { get { return this.z; } }
//    static Point()
//    {
//        Point.startPoint = new Point(0, 0, 0);
//    }

//    public Point(double x, double y, double z)
//    {
//        this.x = x;
//        this.y = y;
//        this.z = z;
//    }

//    public static Point StartPoint
//    {
//        get { return startPoint; }
//    }

//    public override string ToString()
//    {
//        string result = "{";
//        result += String.Format("{0}, {1}, {2}", this.X, this.Y, this.Z);
//        result += "}";

//        return result;
//    }
//}



public class Point3D
{
    private double x;
    private double y;
    private double z;
    private static readonly Point3D startingPoint = new Point3D(0, 0, 0);

    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public static Point3D StartingPoint { get; set; }

    public Point3D(double x, double y, double z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public override string ToString()
    {

        return string.Format("Point3D - X:{0}; Y:{1}; Z:{2}", this.X, this.Y, this.Z);
    }
}

class Test
{
    static void Main()
    {
        Point3D first = new Point3D(1, 2, 3);
        Point3D second = new Point3D(5, 6, 7);
        Console.WriteLine(first);

        Console.WriteLine("Distance: " + DistanceCalcolator.CalculateDistance(first, second));

        Point3D p1 = new Point3D(2, 3, 4);
        Point3D p2 = new Point3D(6, 8, 3);
        Storage.savePath(p1, p2);
        Console.WriteLine(Storage.loadPath("test.txt"));
    }
}



