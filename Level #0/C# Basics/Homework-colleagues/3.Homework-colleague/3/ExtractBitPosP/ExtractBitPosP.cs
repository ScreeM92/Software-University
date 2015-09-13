using System;

    class ExtractBitPosP
    {
        static void Main()
        {
            Console.Write("Integer: ");
            int theNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Index p: ");
            int p = Convert.ToInt32(Console.ReadLine());

            int altered = theNumber >> p;
            int bit = altered & 1;
            Console.WriteLine(bit);
        }
    }