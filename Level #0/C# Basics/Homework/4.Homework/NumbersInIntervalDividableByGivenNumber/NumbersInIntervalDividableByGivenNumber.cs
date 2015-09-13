using System;
    class NumbersInIntervalDividableByGivenNumber
    {
        static void Main()
        {
            Console.WriteLine("Start number");
            int startNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("End number");
            int endNumber = int.Parse(Console.ReadLine());
            int pCounter = 0;
            for (int i = startNumber; i <= endNumber; i++)
            {
                if (i % 5 == 0)
                {
                    Console.WriteLine(i);
                    pCounter++;
                }
            }
            Console.WriteLine(pCounter);
        }
    }

