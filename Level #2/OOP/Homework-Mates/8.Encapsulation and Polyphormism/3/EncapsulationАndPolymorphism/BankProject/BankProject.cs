using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class BankProject
    {
        static void Main()
        {
            BankAccount meryPopins = new DepositAccount(Customer.Individual, 2500.88m, 7.5m);
            BankAccount johnRoss = new MortgageAccount(Customer.Companies, 3654.65m, 8.2m);
            BankAccount emiBarns = new MortgageAccount(Customer.Individual, 1654.65m, 8.2m);
            BankAccount stivDaun = new LoanAccount(Customer.Individual, 254.36m, 7.5m);
            BankAccount foxCompany = new LoanAccount(Customer.Companies, 22254.36m, 7.5m);

            List<BankAccount> bankAccounts = new List<BankAccount>() 
            { 
                meryPopins,
                johnRoss,
                emiBarns,
                stivDaun,
                foxCompany 
            };

            foreach (var client in bankAccounts)
            {
                var typeAccount = client.GetType().Name;                
                var clientBalance = client.Balance;
                var rateValue = client.CalculateInterestRate(6);
                var totalBalance = rateValue + client.Balance;

                Console.WriteLine(
                    "Type: {0}\n" +
                    "Balance: {1:f2}$\n" +
                    "Itereset rate for 6 months: {2:f2}$\n" +
                    "Total balance: {3:f2}$\n",
                    typeAccount, clientBalance, rateValue, totalBalance); 
            }

            
            Console.WriteLine("{0} Customer\nBalance: {1:f2}$", meryPopins.Customer, meryPopins.Balance);           
            meryPopins.WithdrawMoney(2500m);
            Console.WriteLine("Withdraw: 2500$\nTotal balance: {0:f2}$\n", meryPopins.Balance);

            
            Console.WriteLine("{0} Customer\nBalance: {1:f2}$", foxCompany.Customer, foxCompany.Balance);
            foxCompany.DepositMoney(1000m);
            Console.WriteLine("Deposit: 1000$\nTotal balance: {0:f2}$\n", foxCompany.Balance);
 
            Console.ReadLine();
        }
    }
}
