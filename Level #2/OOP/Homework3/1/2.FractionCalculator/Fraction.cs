using System;

public struct Fraction
{
    private long numerator;
    private long denominator;

    public long Numerator
    {
        get { return this.numerator; }
        set { this.numerator = value; }
    }

    public long Denominator
    {
        get { return this.denominator; }
        set
        {
            if (value == 0)
            {
                throw new ArgumentException("The denominator can not be 0");
            }
            this.denominator = value;
        }
    }

    public Fraction(long numerator, long denominator)
        : this()
    {
        this.Numerator = numerator;
        this.Denominator = denominator;
    }

    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        long numerator = f1.numerator * f2.denominator + f2.numerator * f1.denominator;
        long denomominator = f1.denominator * f2.denominator;
        return new Fraction(numerator, denomominator);
    }

    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        long numerator = f1.numerator * f2.denominator - f2.numerator * f1.denominator;
        long denomominator = f1.denominator * f2.denominator;
        return new Fraction(numerator, denomominator);
    }

    public override string ToString()
    {
        return string.Format("{0}", (decimal)this.Numerator/(decimal)this.Denominator);
    }
}