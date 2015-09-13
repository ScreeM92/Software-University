using System;
class ExtractBitFromInteger
    {
        static void Main()
        {
            Console.WriteLine("Enter integer number n:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Binary representation:");
            Console.WriteLine(Convert.ToString(number, 2).PadLeft(16, '0'));
            Console.WriteLine("Enter index p:");
            int bit = int.Parse(Console.ReadLine());
            int bitMove = number >> bit;
            int bitResult = bitMove & 1;
            Console.WriteLine("The value of the given bit at index p:");
            Console.WriteLine(bitResult);
        }
    }

