using System;
    class Program
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int greater = Math.Max(a, b);
            while (true)
            {
                if (a % greater == 0 && b % greater == 0)
                {
                    Console.WriteLine(greater);
                    break;
                }
                greater--;
            }
        }
    }

