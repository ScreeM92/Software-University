using System;
class Bit
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(Convert.ToString(num, 2).PadLeft(16, '0'));
            int moveNum = num >> 3;
            int bit = moveNum & 1;
            Console.WriteLine(bit);
            }
    }

