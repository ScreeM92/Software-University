using System;
using System.Numerics;
    class NightmareOnCodeStreet
    {
        static void Main()
        {
            string str = Console.ReadLine();

            BigInteger count = 0;
            BigInteger sum = 0;

            for (int i = 1; i < str.Length; i+= 2)
            {
                if (char.IsDigit(str[i]))
                {
                sum += BigInteger.Parse(str[i].ToString());
                count++;
                }
            }
            Console.WriteLine("{0} {1}", count, sum);
        }
    }

