namespace _02_BankOfKurtovoKonare
{
    using System;
    using System.Collections.Generic;

    class Test
    {
        public static void Main()
        {
            ICustomer gosho = new IndividualCustomer("Gosho Ivanov");
            ICustomer taoCompany = new CompanyCustomer("Tao Company ");

            IAccount mortgageAccInd = new MortgageAccount(gosho, 1000m, 3m);
            IAccount mortgageAccComp = new MortgageAccount(taoCompany, 2024, 5.3m);
            IAccount loanAccInd = new LoanAccount(gosho, 1000, 5.3m);
            IAccount loanAccComp = new LoanAccount(taoCompany, 2024, 8.3m);
            IAccount depositAccIndBig = new DepositAccount(gosho, 124, 5.3m);
            IAccount depositAccIndSmall = new DepositAccount(gosho, 599m, 3.3m);
            IAccount depositAccComp = new DepositAccount(taoCompany, 100, 2.3m);

            List<IAccount> accounts = new List<IAccount>()
            {
                mortgageAccInd,
                mortgageAccComp,
                loanAccInd,
                loanAccComp,
                depositAccIndBig,
                depositAccIndSmall,
                depositAccComp
            };

            foreach (var acc in accounts)
            {
                Console.WriteLine(
                    "{5} {0}: {1:N2}, {2:N2}, {3:N2}, {4:N2}",
                    acc.GetType().Name,
                    acc.CalculateRate(64),
                    acc.CalculateRate(3),
                    acc.CalculateRate(1),
                    acc.CalculateRate(4),
                    acc.Customer.GetType().Name);
            }
        }
    }
}
