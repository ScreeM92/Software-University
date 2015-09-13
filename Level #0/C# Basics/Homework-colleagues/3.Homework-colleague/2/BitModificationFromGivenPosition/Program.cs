using System;


namespace BitModificationFromGivenPosition
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter integer ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of bit");
            int p = int.Parse(Console.ReadLine());
            Console.WriteLine("Choice '0' or '1'");
            short v = short.Parse(Console.ReadLine());
            if (v == 0)
            {
                Console.WriteLine((~( 1<< p)&n));
            }
                else
            {
                Console.WriteLine((1 << p)|n);
            }
        }
    }
}
