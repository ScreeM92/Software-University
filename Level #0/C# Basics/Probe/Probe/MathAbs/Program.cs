using System;
    class Program
    {
        static void Main(string[] args)
        {
            int a = 2011;
            int b = 2200;
            Console.WriteLine((a + b));
            Console.WriteLine("Smaller: {0}", (a + b - Math.Abs(a - b)) / 2);
        }
    }

