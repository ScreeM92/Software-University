using System;
    class SumOf3Integers
    {
        static void Main()
        {
            Console.WriteLine("Write a:");
            decimal a = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Write b:");
            decimal b = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Write c:");
            decimal c = decimal.Parse(Console.ReadLine());
            Console.WriteLine("The sum of numbers is {0}", (a + b + c));
        }
    }

