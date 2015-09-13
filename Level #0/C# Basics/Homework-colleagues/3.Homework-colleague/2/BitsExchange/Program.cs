using System;


namespace BitsExchange
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int bit = (n >> p) & 1;
            bool bitIsOne = (bit == 1);
            Console.WriteLine(bitIsOne);

        }
    }
}
