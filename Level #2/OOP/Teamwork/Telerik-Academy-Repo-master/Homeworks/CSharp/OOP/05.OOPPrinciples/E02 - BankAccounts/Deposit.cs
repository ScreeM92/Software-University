using System;

public class Deposit : Account, IWithDraw
{
    public Deposit(Customer customer, decimal balance, float interestRate) : base(customer, balance, interestRate) { }

    public void WithDraw(decimal moneyAmount)
    {
        this.Balance -= moneyAmount;
    }

    public override decimal CalculateInterestAmount(int numberOfMonths)
    {
        if (this.Balance < 1000 && this.Balance >= 0)
        {
            return 0;
        }

        decimal interestAmount = numberOfMonths * Convert.ToDecimal(this.InterestRate);
        return interestAmount;
        
    }
}
