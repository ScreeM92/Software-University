using System;
using System.Collections.Generic;
class AgeCalculation
{
    static void Main()
    {
        Console.WriteLine("What is your birthay date? Please use FORMAT: dd.mm.yyyy");
        string year = (Console.ReadLine().Substring(6));
        int bornYear = int.Parse(year);
        int currentYear = DateTime.Now.Year;
        int age = currentYear - bornYear;
        Console.WriteLine("Your age is " + age);
        Console.WriteLine("After 10 years you'll be {0} years old", age + 10);
    }
}