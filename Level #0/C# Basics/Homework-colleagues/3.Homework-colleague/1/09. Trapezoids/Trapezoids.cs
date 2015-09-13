using System;

class Trapezoids
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculates trapezoid's area");
            Console.WriteLine("Enter \"a\" dimention");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter \"b\" dimention");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter \"h\" dimention");
            double h = double.Parse(Console.ReadLine());
            double area = ((a + b) / 2.0) * h;
            Console.WriteLine("The are of the trapezoid is " + area);
        }
    }

