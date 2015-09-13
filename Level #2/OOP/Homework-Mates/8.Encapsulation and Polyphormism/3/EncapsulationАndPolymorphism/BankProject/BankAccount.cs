using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public abstract class BankAccount:IAccountable
    {
        protected Customer customer;
        protected decimal balance;
        protected decimal interestRate;
        

        public BankAccount(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate / 12 / 100;            
        }

        public Customer Customer { get; set; }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = ValidateDecimalValue(value);

            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            set
            {
                this.interestRate = ValidateDecimalValue(value);

            }
        }

        public virtual decimal DepositMoney(decimal money)
        {
            return this.Balance += money;            
        }

        public virtual decimal CalculateInterestRate(int months)
        {
            return this.Balance * (1 + (this.InterestRate) * months) - this.Balance;
        }

        public virtual void WithdrawMoney(decimal money)
        {
            Console.WriteLine("This operation is not alowed for that type account!"); 
        }

        public static decimal ValidateDecimalValue(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Value must be bigger than zero!");
            }
            return value;
        }
    }
}
