using System;
    class Prime
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            bool isPrime = true;
            int maxDevide = (int)Math.Sqrt(num);
            for (int i = 2; i <= maxDevide; i++)
            {
                if (num % i == 0) 
                isPrime = false;
                break;
            }
            Console.WriteLine(isPrime);
        }
    }

