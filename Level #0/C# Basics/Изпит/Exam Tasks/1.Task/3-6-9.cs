using System;
using System.Numerics;
    class ThreeSixNine
    {
        static void Main()
        {
            ulong a = ulong.Parse(Console.ReadLine());
            ulong b = ulong.Parse(Console.ReadLine());
            ulong c = ulong.Parse(Console.ReadLine());
            ulong result = 0;
            ulong num = 0;
            if (b == 3)
            {
                result = a + c;
            }
            else if (b == 6)
            {
                result = a * c;
            }
            else if (b == 9)
            {
                result = a % c;
            }
            if (result % 3 == 0)
            {
                num = result / 3;
            }
            else 
            {
                num = result % 3;
            }
            Console.WriteLine(num);
            Console.WriteLine(result);
        }
    }

