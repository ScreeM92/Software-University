using System;

class Extract_Bit_numer_3
    {
        static void Main()
        {
            Console.WriteLine("Write a random unsigned integer");
            int input = int.Parse(Console.ReadLine());
            int PositionToGet = 3;
            int nRightP = input >> PositionToGet;
            int bit = nRightP & 1;
            Console.WriteLine("The bit at position 3 is " + bit);
        }
    }

