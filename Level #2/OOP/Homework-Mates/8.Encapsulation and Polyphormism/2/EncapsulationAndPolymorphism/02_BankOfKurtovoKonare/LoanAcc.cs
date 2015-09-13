namespace _02_BankOfKurtovoKonare
{

    public class LoanAccount : Account, IAccount, IDeposit
    {
        public LoanAccount(ICustomer customer, decimal balance, decimal monthlyInterestRate)
            : base(customer, balance, monthlyInterestRate)
        {
        }

        public override decimal CalculateRate(double months)
        {
            if (this.Customer is IndividualCustomer)
            {
                if (months >= 3)
                {
                    return base.CalculateRate(months - 3);
                }
                else
                {
                    return this.Balance;
                }
            }

            if (this.Customer is CompanyCustomer)
            {
                if (months >= 2)
                {
                    return base.CalculateRate(months - 2);
                }
                else
                {
                    return this.Balance;
                }
            }

            return base.CalculateRate(months);
        }
    }
}
