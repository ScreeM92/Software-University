using System;

class Dividable_Integers_in__Interval
{
    static void Main()
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());
        int p = 0;
        for (int i = start; i <= end; i++)
        {
            if (i % 5 == 0)
            {
                p++;
            }
        }
        Console.WriteLine(p);
    }
}