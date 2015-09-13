using System;
    class MatrixOfNumbers
    {
        static void Main()
        {
            Console.WriteLine("Please enter (1 ≤ N ≤ 20) N:");
            int N = int.Parse(Console.ReadLine());
            if (N < 1 || N > 20)
            {
                Console.WriteLine("Invalid input!");
            }
            else
            {
                for (int row = 1; row <= N; row++)
                {
                    for (int col = row; col < N + row; col++)
                    {
                        Console.Write(col + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }

