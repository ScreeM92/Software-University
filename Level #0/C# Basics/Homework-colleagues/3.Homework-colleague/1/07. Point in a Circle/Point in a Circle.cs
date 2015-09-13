using System;

class PointInAcircle
    {
        static void Main()
        {
            Console.WriteLine("Check if a point is within a circle K({0, 0}, 2).");
            double r = 2;
            Console.WriteLine("Enter a x coordinate");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter a y coordinate");
            double y = double.Parse(Console.ReadLine());
            double powerX = Math.Pow(x, 2);
            double powerY = Math.Pow(y, 2);
            double powerR = Math.Pow(r, 2);
            double d = powerX + powerY;
            Console.WriteLine(d <= powerR);
        }
    }

