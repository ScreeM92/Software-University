using System;

class SoftUniRegistration
{
    static void Main()
    {
        Persons ivan = new Persons("Ivan", 18);
        Console.WriteLine(ivan);
        Console.WriteLine("Example 1");
        try
        {
            TakeNewProfile("niki", 18);
            Console.WriteLine("-> OK");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Example 2");
        try
        {
            TakeNewProfile("Niki", 18, "niki@abv.bg");
            Console.WriteLine("-> OK");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        Console.WriteLine("Example 3");
        try
        {
            TakeNewProfile("niki", 101);
            Console.WriteLine("-> OK");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Example 4");
        try
        {
            TakeNewProfile("Niki", 18, "niki@abv.bg");
            Console.WriteLine("-> OK");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Example 5");
        try
        {
            TakeNewProfile("Niki", 18, "abv.bg");
            Console.WriteLine("-> OK");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }



    }

    static void TakeNewProfile(string name, int age)
    {
        Persons user = new Persons(name, age);
        Console.WriteLine(user.ToString());
    }
    static void TakeNewProfile(string name, int age, string email)
    {
        Persons user = new Persons(name, age, email);
        Console.WriteLine(user.ToString());
    }
}

