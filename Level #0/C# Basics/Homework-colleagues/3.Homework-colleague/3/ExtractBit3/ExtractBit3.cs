using System;

    class ExtractBit3
    {
        static void Main()
        {
            Console.Write("Number: ");
            int theNumber = Convert.ToInt32(Console.ReadLine());
            int altered = theNumber >> 3;
            int bit = altered & 1;
            Console.WriteLine(bit);
        }
    }
