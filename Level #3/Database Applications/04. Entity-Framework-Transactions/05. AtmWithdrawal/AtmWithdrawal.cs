using System.Linq;

namespace _05.AtmWithdrawal
{
    using System;
    using AtmDB;

    public class AtmWithdrawal
    {
        public static void Main()
        {
            // TransactionsHistory included in this task. For more information look at AtmManager
            // SQL sciprt for the ATM database provided in the zip.

            // CardNumber	CardPIN	 CardCash
            // 1234567890	7799	 1500.00
            // 1478523690	4466	 8943.00
            // 3216549870	3311	 700.00
            // 9632587410	9977	 40.00
            // 9764318250	6644	 200.00
            // 9876543210	1133	 3210.00

            try
            {
                Console.Write("Enter card number: ");
                var cardNumber = Console.ReadLine();

                Console.Write("Enter pin: ");
                var cardPin = Console.ReadLine();

                Console.Write("Enter withdraw amount: ");
                var amount = decimal.Parse(Console.ReadLine());

                AtmManager.Withdraw(cardNumber, cardPin, amount);
                Console.WriteLine("Withdraw was successful.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}