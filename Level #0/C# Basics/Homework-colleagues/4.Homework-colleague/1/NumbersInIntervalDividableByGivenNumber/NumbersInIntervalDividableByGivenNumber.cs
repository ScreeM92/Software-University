using System;

class NumbersInIntervalDividableByGivenNumber
{
    static void Main()
    {
        Console.Write("Start: ");
        int start = int.Parse(Console.ReadLine());
        Console.Write("End: ");
        int end = int.Parse(Console.ReadLine());

        int counter = 0;

        for (int i = start; i <= end; i++)
        {
            if (i % 5 == 0)
            {
                Console.Write(i + " ");
                counter++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("There is {0} numbers dividable by 5!", counter);
    }
}
