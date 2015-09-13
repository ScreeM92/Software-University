using System;
    class UKFlag
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int row = 0; row < n / 2; row++)
            {
                string outDot = new string('.', row);
                string innerDot = new string('.', n / 3 - row);
                Console.WriteLine("{0}{1}{2}{3}{2}{4}{0}", outDot, "\\", innerDot, "|", "/" );
            }
            Console.WriteLine("{0}*{0}", new string('-', n / 2));

            for (int row = 0; row < n / 2; row++)
            {
                string outDot = new string('.', n / 3 - row);
                string innerDot = new string('.', row);
                Console.WriteLine("{0}{1}{2}{3}{2}{4}{0}", outDot, "/", innerDot, "|", "\\");
            }
        }
    }

