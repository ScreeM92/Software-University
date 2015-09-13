using System;

namespace ExchangeIfGreater
{
    class ExchangeIfGreater
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (a > b)
            { // XOR algorithm
                a = a ^ b;
                b = a ^ b;
                a = a ^ b;
                Console.WriteLine(a + " " + b);
            }
            else
            {
                Console.WriteLine(a + " " + b);
            }
        }
    }
}
