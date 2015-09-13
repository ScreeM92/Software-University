using System;
using System.Numerics;
    class CatalanNumbers
    {
        static void Main()
        {
            Console.WriteLine("Please enter N (1 < N < 100):");
            int N = int.Parse(Console.ReadLine());
            if (N <= 1 || N >= 100)
            {
                Console.WriteLine("Invalid input!");
            }
            else
            {
                BigInteger resultDivisionN = 1;
                for (int i = 1;  i <= N; i++)
                {
                    resultDivisionN *= i;
                }
                BigInteger result = 1;
                for (int i = 2*N; i > N + 1; i--)
                {
                    result *= i;
                }
                BigInteger sum = result / resultDivisionN;
                Console.WriteLine("The N Catalan number  is: {0}", sum);
            }
        }
    }

