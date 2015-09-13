using System;

class Mortgage : Account
{
    public Mortgage(Customer customer, decimal balance, float interestRate) : base(customer, balance, interestRate) { }

    public override decimal CalculateInterestAmount(int numberOfMonths)
    {
        bool isAnyInterest = true;
        int divider = 1;

        if (this.Customer is Individual)
        {
            numberOfMonths -= 6;
            if (numberOfMonths <= 6)
            {
                isAnyInterest = false;
            }
        }
        else if (this.Customer is Company)
        {
            divider = 2;
        }

        if (isAnyInterest)
        {
            decimal interestAmount = numberOfMonths * Convert.ToDecimal(this.InterestRate);
            interestAmount /= divider;
            return interestAmount;
        }
        else 
        {
            return 0;
        }
    }
}
