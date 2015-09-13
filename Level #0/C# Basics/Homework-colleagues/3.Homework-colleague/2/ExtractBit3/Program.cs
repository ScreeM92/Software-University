using System;


namespace ExtractBit3
{
    class Program
    {
        static void Main()
        {
            int p = 3;
            int n = int.Parse(Console.ReadLine());
            int bit = (n >> p)&1;
            Console.WriteLine("{0}",bit);



        }
    }
}
