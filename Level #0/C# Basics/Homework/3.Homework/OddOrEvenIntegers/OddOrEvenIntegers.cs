using System;
    class OddOrEvenIntegers
    {
        static void Main()
        {
            Console.WriteLine("Enter count:");
            int count = int.Parse(Console.ReadLine());
            if (count % 2 == 0)
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("True");
            }
        }
    }

