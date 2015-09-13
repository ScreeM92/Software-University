using System;
using System.Collections.Generic;

public struct Fraction
{
    private long numerator;
    private long denominator;

    public Fraction(long inputNumerator, long inputDenominator)
        : this()
    {
        this.Numerator = inputNumerator;
        this.Denominator = inputDenominator;
    }

    public long Numerator
    {
        get
        {
            return this.numerator;
        }

        set
        {
            if (value >= -9223372036854775808 && value <= 9223372036854775807)
            {
                this.numerator = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Numerator value out of range [-9223372036854775808…9223372036854775807]!");
            }
        }
    }

    public long Denominator
    {
        get
        {
            return this.denominator;
        }

        set
        {
            if (value == 0)
            {
                throw new DivideByZeroException("Debominator cannot be 0!");
            }
            else
            {
                if (value >= -9223372036854775808 && value <= 9223372036854775807)
                {
                    this.denominator = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Numerator value out of range [-9223372036854775808…9223372036854775807]!");
                }
            }
        }
    }

    public static Fraction operator +(Fraction firstFraction, Fraction secondFraction)
    {
        long denom1 = firstFraction.Denominator;
        long denom2 = secondFraction.Denominator;
        long nomin1 = firstFraction.Numerator;
        long nomin2 = secondFraction.Numerator;
        long a_temp = Math.Abs(denom1);
        long b_temp = Math.Abs(denom2);

        // Calculate LCD(Lowest common denominator)
        long lcd = CalcLCD(a_temp, b_temp);

        return new Fraction((nomin1 * (lcd / denom1)) + (nomin2 * (lcd / denom2)), lcd);
    }

    public static Fraction operator -(Fraction firstFraction, Fraction secondFraction)
    {
        long denom1 = firstFraction.Denominator;
        long denom2 = secondFraction.Denominator;
        long nomin1 = firstFraction.Numerator;
        long nomin2 = secondFraction.Numerator;
        long a_temp = Math.Abs(denom1);
        long b_temp = Math.Abs(denom2);

        // Calculate LCD(Lowest common denominator)
        long lcd = CalcLCD(a_temp, b_temp);

        return new Fraction((nomin1 * (lcd / denom1)) - (nomin2 * (lcd / denom2)), lcd);
    }

    public override string ToString()
    {
        return string.Format("{0}/{1} = {2}", this.numerator, this.denominator, (double)this.numerator / this.denominator);
    }

    private static long CalcLCD(long firstNum, long secondNum)
    {
        long a_temp = Math.Abs(firstNum);
        long b_temp = Math.Abs(secondNum);
        long lcd = a_temp * b_temp;
        for (long i = Math.Min(a_temp, b_temp); i < lcd; i++)
        {
            if (i % a_temp == 0 && i % b_temp == 0)
            {
                lcd = i;
                break;
            }
        }

        return lcd;
    }
}
