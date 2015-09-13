using System;
    class Program
    {
        static void Main()
        {
            Console.WriteLine("N:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Convert.ToString(n, 2).PadLeft(16, '0'));
            Console.WriteLine("P:");
            int p = int.Parse(Console.ReadLine());
            Console.WriteLine("V: (0 or 1)");
            int v = int.Parse(Console.ReadLine());
            int maskAndNumber;
            if (v == 1)
            {
                int mask = 1 << p;
                maskAndNumber = mask | n;
            }
            else
            {
                int mask = ~(1 << p);
                maskAndNumber = mask & n;
            }
            Console.WriteLine(Convert.ToString(maskAndNumber, 2).PadLeft(16, '0'));
            Console.WriteLine(maskAndNumber);
        }
    }

