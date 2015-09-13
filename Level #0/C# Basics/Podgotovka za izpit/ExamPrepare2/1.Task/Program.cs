using System;
    class Program
    {
        static void Main()
        {
            uint a = uint.Parse(Console.ReadLine());
            uint b = uint.Parse(Console.ReadLine());
            uint c = uint.Parse(Console.ReadLine());
            uint result = 0;
            if (b == 3)
            {
                result = a + c;
            }
            if (b == 6)
            {
                result = a * c;
            }
            if (b == 9)
            {
                result = a % c;
            }
            if (result % 3 == 0)
            {
                Console.WriteLine(result / 3);
            }
            else
            {
                Console.WriteLine(result % 3);
            }
            Console.WriteLine(result);
        }
    }

