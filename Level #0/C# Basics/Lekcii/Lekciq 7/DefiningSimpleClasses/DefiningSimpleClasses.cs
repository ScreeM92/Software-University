using System;

class Point
{
    public int X { get; set; }
    public int Y { get; set; }
}

class DefiningSimpleClasses
{
    static void Main()
    {
        Point point = new Point() { X = 3, Y = 4 };
        Console.WriteLine("Point({0}, {1})", point.X, point.Y);
        Console.WriteLine(point); // This does not work as expected!

        Console.WriteLine("Distance = " + CalcDictance(-2, 1, 1, 3));

        Point[] line = new Point[]
        {
            new Point() { X = -2, Y = 1 },
            new Point() { X = 1, Y = 3 },
            new Point() { X = 4, Y = 2 },
            new Point() { X = 3, Y = -2 },
        };

        for (int i = 0; i < line.Length; i++)
        {
            Console.WriteLine("Point(" + line[i].X + ", " + line[i].Y + ")");
        }

        Console.WriteLine("Line length = " + CalcLineLength(line));
    }

    static double CalcLineLength(Point[] line)
    {
        double length = 0;
        for (int i = 0; i < line.Length-1; i++)
        {
            length += CalcDictance(line[i].X, line[i].Y, line[i + 1].X, line[i + 1].Y);
        }
        return length;
    }

    static double CalcDictance(int x1, int y1, int x2, int y2)
    {
        int dx = x2 - x1;
        int dy = y2 - y1;
        double distance = Math.Sqrt(dx * dx + dy * dy);
        return distance;
    }
}
