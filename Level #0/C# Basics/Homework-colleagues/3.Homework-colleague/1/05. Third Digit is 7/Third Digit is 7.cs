using System;

class ThirdDigitIs7
    {
        static void Main()
        {
            Console.WriteLine("Enter a random integer to check if its 3 digit form right to left is 7");
            string randomInteger = Console.ReadLine();
            char integer = (char)randomInteger[randomInteger.Length - 3];
            // int check = (int)integer;
            Console.WriteLine("check = " + integer);
            Console.WriteLine(integer == '7' ? "true" : "false");
        }
    }

