using System;
    class Program
    {
        static void Main()
        {
            uint num = uint.Parse(Console.ReadLine());
            uint result = num;
            uint mask1 = 7 << 3;
            uint mask2 = 7 << 24;

            uint bits345 = num & mask1;
            uint bits2456 = num & mask2;

            bits345 <<= 21;
            bits2456 >>= 21;

            result = ~mask1 & result;
            result = ~mask2 & result;

            result = result | bits345;
            result = result | bits2456;

            Console.WriteLine(result);
            // 2ri variant
            //long number = uint.Parse(Console.ReadLine());
            //long mask = 7;
            //long thirdFourthFifthBits = ((mask << 3) & number) >> 3;
            //long otherBits = ((mask << 24) & number) >> 24;
            //number = ~(mask << 24) & number;
            //number = ~(mask << 3) & number;
            //number = (thirdFourthFifthBits << 24) | number;
            //number = (otherBits << 3) | number;
            //Console.WriteLine(number);
       }
   }
    

