using System;
    
    class CalculatePerimeter
    {
        static void Main()
        {
            Console.Write("Width: ");
            double width = Convert.ToDouble(Console.ReadLine());

            Console.Write("Height: ");
            double height = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Area: {0}", width*height);
            Console.WriteLine("Perimeter: {0}", 2*(width+height));

        }
    }
