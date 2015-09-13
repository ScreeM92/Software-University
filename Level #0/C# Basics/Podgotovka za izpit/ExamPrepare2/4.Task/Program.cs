using System;
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            char star = '*';
            char dot = '.';
            Console.WriteLine("{0}{1}{0}",
            new string(dot,(n + 1) / 2 ),
            new string(star, n));

            int dotsCount = (n - 1) / 2;
            int innerDotsCount = dotsCount;
            int outerDotsCount = dotsCount;
            for (int row = 0; row < (n - 1) / 2; row++)
			{
                string outerDots = new string(dot, outerDotsCount--);
                string innerDots = new string(dot, innerDotsCount++);
			}

            Console.WriteLine(new string(star, 2 * n +1));
            for (int row = 1; row < n; row++)
            {
                string outerDots = new string(dot, row);
                Console.WriteLine();
            }
            Console.WriteLine("{0}*{0}"); 
            new string(dot, n);
        }
    }

