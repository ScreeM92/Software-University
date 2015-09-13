using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class DepositAccount:BankAccount
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate) { }

        public override decimal CalculateInterestRate(int months)
        {
            if (months > 0)
            { 
                if (this.Balance < 1000)
                {
                    return 0;
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
            if (money > this.Balance)
            {
                throw new ArgumentOutOfRangeException("Insufficient availability!");
            }
            this.Balance -= money;
            
        }



        
    }
}
