using System;

 class Point_Inside_a_Circle_and_Outside_of_a_Rectangle
 {
        static void Main(string[] args)
        {
            Console.WriteLine("Check for given point (x, y) if it is within the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2)");
            double r = 1.5;
            double xCenter = 1.0;
            double yCenter = 1.0;
             Console.WriteLine("Enter a x coordinate");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter a y coordinate");
            double y = double.Parse(Console.ReadLine());
            double powerX = Math.Pow((x - xCenter), 2);
            double powerY = Math.Pow((y - yCenter), 2);
            double powerR = Math.Pow(r, 2);
            double d = powerX + powerY;
            Console.WriteLine((d <= powerR) && y <= 1);
        }
    }

