using System;
    class CirclePerimeterAndArea
    {
        static void Main()
        {
            Console.WriteLine("Insert radius:");
            double r = double.Parse(Console.ReadLine());
            Console.WriteLine("Circle Perimeter is {0:F2}", (2*Math.PI*r));
            Console.WriteLine("Circle Area is {0:F2}", (Math.PI*r*r));
        }
    }

