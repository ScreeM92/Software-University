using System;
    class Program
    {
        static void Main()
        {
            //n! / k! for given n and k (1 < k < n < 100)
            Console.WriteLine("N:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("K:");
            int k = int.Parse(Console.ReadLine());
            int nFac = 1;
            int kFac = 1;
            int result;
            if (1 < k && k < n && n < 100)
            {
                for (int i = k; i > 0; i--)
                {
                    kFac *= i;
                }
                Console.WriteLine(kFac);
                for (int i = n; i > 0; i--)
                {
                    nFac *= i;
                }
                Console.WriteLine(nFac);
                result = nFac / kFac;
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("No (1 < k < n < 100) ");
            }
        }
    }

