using System;
class CheckABitAtGivenPosition
    {
        static void Main()
        {
            Console.WriteLine("Enter integer number n:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Binary representation:");
            Console.WriteLine(Convert.ToString(number, 2).PadLeft(16, '0'));
            Console.WriteLine("Enter bit at position p:");
            int bit = int.Parse(Console.ReadLine());
            int bitMove = number >> bit;
            bool bitResult = (bitMove & 1) == 1;
            Console.WriteLine("Does the bit at position p have value 1?");
            Console.WriteLine(bitResult);         
        }
    }

