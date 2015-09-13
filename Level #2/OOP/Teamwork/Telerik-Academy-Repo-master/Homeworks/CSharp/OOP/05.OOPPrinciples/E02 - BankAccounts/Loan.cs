using System;

class Loan : Account
{
    public Loan(Customer customer, decimal balance, float interestRate) : base(customer, balance, interestRate) { }

    public override decimal CalculateInterestAmount(int numberOfMonths)
    {
        bool isAnyInterest = true;

        if (this.Customer is Individual)
        {
            numberOfMonths -= 3;
            if (numberOfMonths <= 3)
            {
                isAnyInterest = false;
            }
        }
        else if (this.Customer is Company)
        {
            numberOfMonths -= 2;
            if (numberOfMonths <= 3)
            {
                isAnyInterest = false;
            }
        }

        if (isAnyInterest)
        {
            decimal interestAmount = numberOfMonths * Convert.ToDecimal(this.InterestRate);
            return interestAmount;
        }
        else
        {
            return 0;
        }
    }
}
