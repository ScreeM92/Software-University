using System;
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Random rnd = new Random();
            int num;
            for (int i = 1; i <= n; i++)
            {
                num = rnd.Next(n + 1);
                Console.Write("{0} ",num);
            }
        }
    }
