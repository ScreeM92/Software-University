using System;

class Extract_Bit_from_Integer
    {
        static void Main()
        {
            Console.WriteLine("Write a random unsigned integer");
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine("Write the bit position which value you'd like to get");
            int PositionToGet = int.Parse(Console.ReadLine());
            int nRightP = input >> PositionToGet;
            int bit = nRightP & 1;
            Console.WriteLine("The bit at position " + PositionToGet + " is " + bit);
        }
    }
