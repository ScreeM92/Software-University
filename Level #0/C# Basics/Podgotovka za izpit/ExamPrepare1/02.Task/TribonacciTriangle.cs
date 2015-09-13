using System;
    class TribonacciTriangle
    {
        static void Main()
        {
            long tr1 = long.Parse(Console.ReadLine());
            long tr2 = long.Parse(Console.ReadLine());
            long tr3 = long.Parse(Console.ReadLine());

            int lines = int.Parse(Console.ReadLine());

            Console.WriteLine(tr1);
            Console.WriteLine("{0} {1}", tr2, tr3);

            int line = 3;

            while (line <= lines)
            {
                for (int i = 0; i < line; i++)
                {
                    long nextElement = tr1 + tr2 + tr3;
                    tr1 = tr2;
                    tr2 = tr3;
                    tr3 = nextElement;
                    if (i <= line - 1)
                    {
                       Console.Write(nextElement + " ");
                    }
                    else
                    {
                        Console.Write(nextElement + " ");
                    }
                }
                line++;
                Console.WriteLine();
            }
        }
    }

