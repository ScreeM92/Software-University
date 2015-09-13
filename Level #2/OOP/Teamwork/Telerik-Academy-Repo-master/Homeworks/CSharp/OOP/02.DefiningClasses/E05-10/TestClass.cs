using System;

class TestClass
{
    static void Main()
    {
        GenericList<int> a = new GenericList<int>(4);
        Console.WriteLine(a.ToString());

        GenericList<decimal> exampleB = new GenericList<decimal>(4);
        exampleB.AddElement(3.4231231m);
        exampleB.AddElement(238.47326478234m);
        exampleB.AddElement(-18.346287346287m);
        exampleB.AddElement(3.147432684m);
        exampleB.AddElement(2.3567894m);
        exampleB.AddElement(-2.2m);

        Console.WriteLine(exampleB[3]);

        Console.WriteLine("Max = {0}",exampleB.Max<decimal>());
        Console.WriteLine("Min = {0}", exampleB.Min<decimal>());

        Console.WriteLine(exampleB.ToString());

    }
}

