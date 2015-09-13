using System;

class TestCalculator
{
    public static void Main()
    {
        InterestCalculator simpleCalc = new InterestCalculator(2500, 7.2m, 15, InterestCalculator.GetSimpleInterest);
        Console.WriteLine("{0:0.0000}", simpleCalc.PayOutValue);

        InterestCalculator compoundCalc = new InterestCalculator(500, 5.6m, 10, InterestCalculator.GetCompoundInterest);
        Console.WriteLine("{0:0.0000}", compoundCalc.PayOutValue);
    }
}