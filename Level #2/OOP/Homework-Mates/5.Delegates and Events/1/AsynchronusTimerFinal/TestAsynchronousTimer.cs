using System;
using System.Threading;

class TestAsynchronousTimer
{
    public static void Main()
    {
        AsynchTimer saySomething = new AsynchTimer(20, 300, SaySomething);
        AsynchTimer saySomethingOther = new AsynchTimer(23, 430, SaySomethingOther);
        AsynchTimer andOther = new AsynchTimer(32, 232, AndOther);
        AsynchTimer andSoOn = new AsynchTimer(14, 380, AndSoOn);
        for (int i=0; i<100; i++)
        {
            Console.WriteLine("void Main()");
            Thread.Sleep(100);
        }
    }

    public static void SaySomething()
    {
        Console.WriteLine("Some Func");
    }

    public static void SaySomethingOther()
    {
        Console.WriteLine("Some Other Func");
    }

    public static void AndOther()
    {
        Console.WriteLine("And Other");
    }
    public static void AndSoOn()
    {
        Console.WriteLine("And So On");
    }
}