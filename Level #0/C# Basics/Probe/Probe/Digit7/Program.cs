using System;
    class Digit7
    {
        static void Main()
        {
            Console.WriteLine("Enter number:");
            int num = int.Parse(Console.ReadLine());
            int digit = num / 100;
            digit = digit % 10;
            bool same = true;
            if (digit == 7)
            {
                Console.WriteLine(same);
            }
            else
            {
                same = false;
                Console.WriteLine(same);
            }
        }
    }

