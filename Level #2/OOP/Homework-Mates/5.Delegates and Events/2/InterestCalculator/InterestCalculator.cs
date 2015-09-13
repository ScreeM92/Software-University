using System;


public delegate decimal CalculateInterest(decimal sum, decimal interest, int years);
class InterestCalculator
{
    private decimal Money { get; set; }
    private decimal interest;
    private int years;
    private CalculateInterest type;
    
    
    public decimal Interest 
    {
        get { return interest; }
        set
        {
            if (value == 0)
            {
                throw new FormatException("Interest can't be negative!");
            }
            else
            {
                interest = value;
            }
        }
    }

    public int Years
    {
        get { return years; }
        set
        {
            if (value < 0)
            {
                throw new FormatException("Years can't be negative!");
            }
        }
    }

    public InterestCalculator(decimal money, decimal interest, int years, CalculateInterest type)
    {
        Interest = interest;
        Years = years;
        this.type = type;
        Money = money;
    }

    public override string ToString()
    {
        return string.Format("{0:F4}", this.type(Money, Interest, Years));
    }
}

