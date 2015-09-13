using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class MortgageAccount: BankAccount
    {
        public MortgageAccount(Customer customer, decimal money, decimal interestRate)
            : base(customer, money, interestRate) { }

        public override decimal CalculateInterestRate(int months)
        {
            if (months > 0)
            {
                if (this.Customer == Customer.Individual && months <= 6)
                {
                    return 0;
                }
                else if (this.Customer == Customer.Companies && months <= 12)
                {
                    return this.Balance * (1 + ((this.InterestRate / 2) / 100) * months) - this.Balance;
                }
                else
                {
                    return base.CalculateInterestRate(months);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Month can't be negative or zero value!");
            }           
        }

        public override void WithdrawMoney(decimal money)
        {
            base.WithdrawMoney(money);
        }
    }
}
