using System;
    class KaspichaniaBoats
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            char dot = '.';
            char star = '*';

            //Console.WriteLine("{0}*{0}", new string(dot, n));
            //Console.WriteLine("{0}{1}{0}", new string(dot, n - 1), new string(star, 3));

            //for (int row = 1; row <= n - 2; row++)
            //{
            //    string outDots = new string(dot, n - 1 - row);
            //    string innerDots = new string(dot, row);
            //    Console.WriteLine("{0}*{1}*{1}*{0}", outDots, innerDots);
            //}

            //Console.WriteLine("{0}", new string(star, n * 2 + 1));

            //for (int row = 1; row <= (n - 1) / 2; row++)
            //{
            //    string outDots = new string(dot, row );
            //    string innerDots = new string(dot, (n - 1 - row));
            //    Console.WriteLine("{0}*{1}*{1}*{0}", outDots, innerDots);
            //}

            //Console.WriteLine("{0}{1}{0}", new string(dot, (n + 1) / 2), new string(star, n));


            Console.WriteLine("{0}{1}{0}", new string(dot, n), new string(star, 1));
            Console.WriteLine("{0}{1}{0}", new string(dot, n-1), new string(star, 3));

            //int innerDots = 0;
            //int outDots = 0;

            for (int row = 0; row < n - 2; row++)
            {
                string outDots = new string(dot, n - 2 - row);
                string innerDots = new string(dot, 1 + row);
                Console.WriteLine("{0}*{1}*{1}*{0}", outDots, innerDots);
            }

            Console.WriteLine("{0}", new string(star, n*2 + 1));

            for (int row = 0; row < n/2; row++)
            {
                string outDots = new string(dot, 1 + row);
                string innerDots = new string(dot, n - 2 - row);
                Console.WriteLine("{0}*{1}*{1}*{0}", outDots, innerDots);
            }

            Console.WriteLine("{0}{1}{0}", new string(dot, n / 2 + 1), new string(star, n));
        }
    }

