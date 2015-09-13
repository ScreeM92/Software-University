using System;
using System.Numerics;

    class Tribonacci
    {
        static void Main()
        {
            BigInteger Tr1 = BigInteger.Parse(Console.ReadLine());
            BigInteger Tr2 = BigInteger.Parse(Console.ReadLine());
            BigInteger Tr3 = BigInteger.Parse(Console.ReadLine());
            BigInteger N = BigInteger.Parse(Console.ReadLine());

            BigInteger nextTr = 0;
            if (N == 1)
            {
                Console.WriteLine(Tr1);
            }
            else if (N == 2)
            {
                Console.WriteLine(Tr2);
            }
            else if (N == 3)
            {
                Console.WriteLine(Tr3);
            }
            else
            {
            for (int i = 0; i < N - 3; i++)
             {
                nextTr = Tr1 + Tr2 + Tr3;
                Tr1 = Tr2;
                Tr2 = Tr3;
                Tr3 = nextTr;
             }
            Console.WriteLine(nextTr);
            }
        }
    }

