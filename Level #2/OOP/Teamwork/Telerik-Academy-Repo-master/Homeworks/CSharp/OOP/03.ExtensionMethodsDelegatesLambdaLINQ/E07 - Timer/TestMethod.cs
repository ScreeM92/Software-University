using System;

public class TestClass
{
    static void Main()
    {
        Timer testTimer = new Timer(Test, 4, 1500);
        testTimer.Run();
    }

    public static void Test()
    {
        Console.WriteLine("This is a test method!");
    }
}

