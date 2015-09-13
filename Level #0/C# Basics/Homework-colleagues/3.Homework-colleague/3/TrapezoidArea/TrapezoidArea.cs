using System;

    class TrapezoidArea
    {
        static void Main()
        {
            Console.Write("a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("height: ");
            double height = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("The area of the Trapezoid is: {0}", (a+b)*height/2);
        }
    }
