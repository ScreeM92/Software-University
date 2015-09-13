using System;
class Rectangles
    {
        static void Main()
        {
            Console.WriteLine("Write width:");
            int width = int.Parse(Console.ReadLine());
            Console.WriteLine("Write height:");
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine("The perimeter is: {0}", (2*width) + (2*height));
            Console.WriteLine("The area is: {0}", width * height);
        }
    }

