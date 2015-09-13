using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class LoanAccount:BankAccount
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate) { }

        public override decimal CalculateInterestRate(int months)
        {
            if (months > 0)
            {
                if (months <= 3 && this.Customer == Customer.Individual)
                {
                    return 0;
                }
                else if (months <= 2 && this.Customer == Customer.Companies)
                {
                    return 0;
                }
                return base.CalculateInterestRate(months);
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
