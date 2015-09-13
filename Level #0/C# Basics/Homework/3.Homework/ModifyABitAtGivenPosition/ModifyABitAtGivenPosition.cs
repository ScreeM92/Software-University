using System;
    class ModifyABitAtGivenPosition
    {
        static void Main()
        {
            Console.WriteLine("Enter integer number n:");
            int numberN = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter index p:");
            int indexP = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter value 0 or 1 for the bit at index p:");
            int bitValue = int.Parse(Console.ReadLine());
            int numberAndMask;
            Console.WriteLine("Binary representation of n:");
            Console.WriteLine(Convert.ToString(numberN, 2).PadLeft(16, '0'));
            if (bitValue == 1)
            {
                int mask = 1 << indexP;
                numberAndMask = mask | numberN;
            }
            else
            {
                int mask = ~(1 << indexP); 
                numberAndMask = mask & numberN;                                       
            }
            Console.WriteLine("Binary result:");
            Console.WriteLine(Convert.ToString(numberAndMask, 2).PadLeft(16, '0'));
            Console.WriteLine("Result:");
            Console.WriteLine(numberAndMask);
        }
    }

