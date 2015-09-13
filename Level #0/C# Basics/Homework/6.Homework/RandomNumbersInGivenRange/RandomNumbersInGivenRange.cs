using System;
using System.Text;
    class RandomNumbersInGivenRange
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Please enter min (min ≤ max) :");
            int min = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter max (min ≤ max) :");
            int max = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter n:");
            int n = int.Parse(Console.ReadLine());
            Random rnd = new Random();
            if (min <= max)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write(rnd.Next(min, max + 1) + " ");
                }
            }
            else
            {
                Console.WriteLine("Try again! (min ≤ max) ");
            }
        }
    }

