using System;
    class BitsExchange
    {
        static void Main()
        {
            Console.Write("Enter your number: ");
            long number = long.Parse(Console.ReadLine());

            Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));

            int fakeBitOne = 3;
            int fakeBitTwo = 24;

            for (int i = 0; i < 3; i++)
            {
                long maskOne = (number & (1 << fakeBitOne)) >> fakeBitOne; // 3 = 0,1
                long maskTwo = (number & (1 << fakeBitTwo)) >> fakeBitTwo; // 24 = 0,1

                //mask one
                if (maskOne == 0)
                {
                    number = number & (~(1 << fakeBitTwo)); // 24 = 0
                }
                else if (maskOne == 1)
                {
                    number = number | (1 << fakeBitTwo); // 24 = 0
                }

                //mask two
                if (maskTwo == 0)
                {
                    number = number & (~(1 << fakeBitOne)); // 3 = 0
                }
                else if (maskTwo == 1)
                {
                    number = number | (1 << fakeBitOne); // 3 = 1
                }

                fakeBitOne++;
                fakeBitTwo++;
            }

            Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
            Console.WriteLine(number);
        }
    }

