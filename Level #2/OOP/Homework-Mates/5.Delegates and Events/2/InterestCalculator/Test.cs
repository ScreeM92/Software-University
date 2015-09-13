using System;



class Test
{
    public static decimal GetSimpleInterest(decimal sum, decimal interest, int years)
    {
        return sum * (1 + (interest / 100) * years);
    }

    public static decimal GetCompoundInterest(decimal sum, decimal interest, int years)
    {
        return sum * (decimal)Math.Pow((double)(1 + (interest / 100) / 12), 12 * years);
    }

    public static void Work1(string str)
    {
        Console.Write(str);
    }

    public static void Work2(string str)
    {
        Console.Beep();
    }


    static void Main(string[] args)
    {
        var interestCalculator = new InterestCalculator(500m, 5.6m, 10, GetCompoundInterest);
        Console.WriteLine(interestCalculator);

        var compoundInterest = new InterestCalculator(2500m, 7.2m, 15, GetSimpleInterest);
        Console.WriteLine(compoundInterest);

        ////////////////// Async Timer ////////////////////

        AsyncTimer timer1 = new AsyncTimer(Work1, 1000, 10);
        timer1.Start();

        AsyncTimer timer2 = new AsyncTimer(Work2, 500, 20);
        timer2.Start();

    }
}

