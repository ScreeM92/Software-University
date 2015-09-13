using System;


class AgeAfter10Years
{
    static void Main()
    {
        Console.WriteLine("Please enter Your age.");
        int AgeNow = int.Parse(Console.ReadLine());
        int AgeAfter = AgeNow + 10;
        Console.Write("Your age now:");
        Console.WriteLine(AgeNow);
        Console.WriteLine("Your age after 10 Years will be:");
        Console.WriteLine(AgeAfter);
    }
}
