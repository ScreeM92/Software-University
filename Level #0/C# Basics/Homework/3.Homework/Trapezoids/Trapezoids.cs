using System;
    class Trapezoids
    {
        static void Main()
        {
            Console.WriteLine("Side \"a\"=");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Side \"b\"=");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Height \"h\"=");
            double h = double.Parse(Console.ReadLine());
            Console.WriteLine("Area of trapezoid is: {0}", ((a + b) * h) / 2);
        }
    }

