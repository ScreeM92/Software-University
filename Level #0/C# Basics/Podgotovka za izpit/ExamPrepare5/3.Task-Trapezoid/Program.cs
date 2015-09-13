using System;
    class Trapezoid
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.Write(new string('.', n));
            Console.WriteLine(new string('*', n));

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = 0; j < n*2; j++)
                {
                    if (i == j || (j == n*2 - 1) || i == 0)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
                Console.WriteLine();
            }
        }
    }

