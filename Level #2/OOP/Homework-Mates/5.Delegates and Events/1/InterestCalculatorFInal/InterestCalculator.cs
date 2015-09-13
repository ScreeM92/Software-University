using System;

internal class InterestCalculator
{
    private const int n = 12;
    private decimal money { get; set; }
    private decimal interest { get; set; }
    private int years { get; set; }
    private decimal payOutValue { get; set; }

    public InterestCalculator(decimal money, decimal interest, int years, Delegate del)
    {
        this.Money = money;
        this.Interest = interest;
        this.Years = years;
        this.PayOutValue = del(money, interest, years);
    }

    public delegate decimal Delegate(decimal money, decimal interest, int years);

    public decimal Money
    {
        get { return this.money; }
        set { this.money = value; }
    }

    public decimal Interest
    {
        get { return this.interest; }
        set { this.interest = value; }
    }

    public int Years
    {
        get { return this.years; }
        set { this.years = value; }
    }

    public decimal PayOutValue
    {
        get { return this.payOutValue; }
        set { this.payOutValue = value; }
    }

    public static decimal GetSimpleInterest(decimal money, decimal interest, int years)
    {
        decimal result = money * (1 + (interest * years / 100));
        return result;
    }

    public static decimal GetCompoundInterest(decimal money, decimal interest, int years)
    {
        decimal firstPart = (1 + (interest / InterestCalculator.n / 100));
        decimal secondPart = years * InterestCalculator.n;
        double result = (double)money * Math.Pow((double)firstPart, (double)secondPart);
        return (decimal)result;
    }
}