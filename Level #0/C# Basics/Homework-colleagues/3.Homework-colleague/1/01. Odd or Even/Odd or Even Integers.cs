using System;

class OddOrEvenIntegers
    {
        static void Main()
        {
            Console.WriteLine("Enter a number to check");
            string NumberToCheck = Console.ReadLine();
            int NumberToVerify = int.Parse(NumberToCheck);
            Console.WriteLine(NumberToVerify % 2 == 0 ? "even" : "odd");
        }
    }

