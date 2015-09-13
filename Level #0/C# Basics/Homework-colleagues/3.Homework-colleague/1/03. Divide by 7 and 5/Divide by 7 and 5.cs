using System;

class DivideBy7And5
    {
        static void Main()
        {
            Console.WriteLine("Write a number to check");
            string ConsoleInput = Console.ReadLine();
            int Number = int.Parse(ConsoleInput);
            Console.WriteLine((Number % 5 == 0) && (Number % 7 == 0) ? "true" : "false");
        }
    }
