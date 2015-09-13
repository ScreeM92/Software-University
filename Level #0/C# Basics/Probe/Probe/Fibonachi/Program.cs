using System;
    class Program
    {
        static void Main()
        {
            int a = 0;
            int b = 1;
            int sum;
            Console.Write("0 1 ");
            for (int i = 1; i <= 98; i++)
            {
                sum = a + b;
                Console.Write(sum + " ");
                a = b;
                b = sum;
            }
        }
    }

