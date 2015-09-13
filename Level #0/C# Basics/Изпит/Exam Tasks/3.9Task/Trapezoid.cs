using System;
    class Trapezoid
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            char dot = '.';
            char star = '*';

            Console.WriteLine("{0}{1}", new string(dot, n), new string(star, n));

            for (int row = 0; row < n - 1; row++)
            {
                string outDots = new string(dot, n - 1 - row);
                string innerDots = new string(dot, n - 1 + row);
                Console.WriteLine("{0}*{1}*", outDots, innerDots);
            }
            Console.WriteLine(new string(star, n * 2));
        }
    }

