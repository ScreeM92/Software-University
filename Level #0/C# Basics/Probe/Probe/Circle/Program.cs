using System;
    class Program
    {
        static void Main()
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            bool inside = (x * x) + (y * y) <= (5 * 5);
            bool insideRectangle = (-1 <= x && 1 >= x) && (-5 <= y && 5 >= y);
            if (inside && !insideRectangle)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }

