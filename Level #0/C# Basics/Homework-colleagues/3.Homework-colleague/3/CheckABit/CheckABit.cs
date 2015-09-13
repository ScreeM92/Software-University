using System;

    class CheckABit
    {
        static void Main()
        {
            Console.Write("Integer: ");
            int theNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Index p: ");
            int p = Convert.ToInt32(Console.ReadLine());

            int alteredNumber = theNumber >> p;
            int bit = alteredNumber & 1;
            Console.WriteLine(bit==1);
        }
    }
