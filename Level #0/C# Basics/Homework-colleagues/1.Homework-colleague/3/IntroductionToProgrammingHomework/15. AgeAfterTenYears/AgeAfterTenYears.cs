using System;

class AgeAfterTenYears
{
    static void Main()
    {       
        Console.Write("Enter your birthday in format(dd.mm.yyyy): ");
        DateTime userBirthday = DateTime.Parse(Console.ReadLine());
        var result = DateTime.Today.Subtract(userBirthday).Ticks;
        Console.WriteLine("You are {0} years old.", new DateTime(result).Year - 1);
        Console.WriteLine("After 10 years uou will be {0} years old.", new DateTime(result).AddYears(10).Year - 1);
    }
}