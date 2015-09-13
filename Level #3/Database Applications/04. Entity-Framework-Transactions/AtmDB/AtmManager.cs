using System.Data.Entity.Migrations;
using System.Transactions;
using IsolationLevel = System.Data.IsolationLevel;

namespace AtmDB
{
    using System;
    using System.Linq;

    public static class AtmManager
    {
        public static void Withdraw(string cardNumber, string pin, decimal amount)
        {
            var context = new AtmEntities();

            using (TransactionScope scope =
                new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
            {
                var bankAccount = context.CardAccounts.FirstOrDefault(a => a.CardNumber == cardNumber && a.CardPIN == pin);

                if (bankAccount == null)
                {
                    throw new InvalidOperationException("Invalid card number or/and pin!");
                }

                if (bankAccount.CardCash < amount)
                {
                    throw new InvalidOperationException("The account has not enough money to complete the operation!");
                }

                if (amount <= 0)
                {
                    throw new InvalidOperationException("The amoutnt should be positive!");
                }

                bankAccount.CardCash -= amount;
                Update(bankAccount, context);
                AddTransactionHistoryRecord(bankAccount.CardNumber, DateTime.Now, amount, context);

                context.SaveChanges();
                scope.Complete();
            }
        }

        private static void AddTransactionHistoryRecord(string cardNumber, DateTime transactionDate, decimal amount, AtmEntities context)
        {
            context.TransactionHistories.Add(new TransactionHistory
            {
                CardNumber = cardNumber,
                TransactionDate = transactionDate,
                Amount = amount
            });
        }

        private static void Update(CardAccount account, AtmEntities context)
        {
            context.CardAccounts.AddOrUpdate(a => a.CardNumber, account);
        }
    }
}