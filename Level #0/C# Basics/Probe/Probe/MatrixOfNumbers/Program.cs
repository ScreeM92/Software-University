using System;
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            for (int row = 1; row <= n; row++)
            {
                for (int col = row; col < n + row ; col++)
                {
                    Console.Write(col);
                }
                Console.WriteLine();
            }
        }

    }

