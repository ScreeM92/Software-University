using System;

public abstract class Account
{
    public Customer Customer { get; protected set; }
    public decimal Balance { get; protected set; }
    public float InterestRate { get; protected set; }

    public Account(Customer customer, decimal balance, float interestRate)
    {
        this.Customer = customer;
        this.Balance = balance;
        this.InterestRate = interestRate;
    }

    public void Deposit(decimal moneyAmount)
    {
        this.Balance += moneyAmount;
    }

    public virtual decimal CalculateInterestAmount(int numberOfMonths)
    {   
        decimal interestAmount = numberOfMonths * Convert.ToDecimal(this.InterestRate);
        return interestAmount;
    }
}