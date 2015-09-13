using System;
    class SumOfNNumbers
    {
        static void Main()
        {
            int sumNumber = 0;
            Console.Write("n:");
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                Console.Write("X:");
                int sum = int.Parse(Console.ReadLine());
                sumNumber = sumNumber + sum;
            }
            Console.WriteLine("Sum: {0}", sumNumber);
        }
    }

