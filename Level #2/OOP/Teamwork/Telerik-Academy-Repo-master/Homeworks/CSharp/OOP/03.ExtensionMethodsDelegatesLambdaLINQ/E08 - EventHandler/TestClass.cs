using System;

class MainClass
{
    static void Main()
    {
        EventHandler newHandler = new EventHandler();
        newHandler.current += TestMetnod;
        newHandler.Run(2000);

        Console.ReadLine();
    }

    public static void TestMetnod()
    {
        Console.WriteLine("Do something method!");
    }
}