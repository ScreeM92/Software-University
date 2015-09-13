using System;

    class ModifyBit
    {
        static void Main()
        {
            Console.Write("Integer: ");
            int theNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Index p: ");
            int p = Convert.ToInt32(Console.ReadLine());

            Console.Write("Bit Value (0/1): ");
            int value = Convert.ToInt32(Console.ReadLine());

            int mask=1<<p;
            int result;

            if (value == 0)
            {
                result = theNumber & ~mask;
            }
            else
            {
                result = theNumber | mask;
            }

            Console.WriteLine(result);
        }
    }
