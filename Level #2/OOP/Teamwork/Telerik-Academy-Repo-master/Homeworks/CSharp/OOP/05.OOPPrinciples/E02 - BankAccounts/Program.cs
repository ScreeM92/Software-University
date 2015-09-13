using System;

class Program
{
    static void Main(string[] args)
    {
        //Pesho's Account
        Deposit peshosAccount = new Deposit(new Individual("Pesho"), 100000m, 25.3f);

        Console.WriteLine("Pesho's current balance: {0}", peshosAccount.Balance);
        Console.WriteLine("Pesho's interest amount: {0}", peshosAccount.CalculateInterestAmount(12));
        //Add some money in the Pesho's account
        peshosAccount.Deposit(2131m);
        Console.WriteLine("Pesho's balance after the deposit: {0}", peshosAccount.Balance);
        peshosAccount.WithDraw(35000m);
        Console.WriteLine("Pesho's balance after the draw: {0}", peshosAccount.Balance);

        //Let us calculate the Pesho's interest amount
        Console.WriteLine("Pesho's account interest amount: {0}", peshosAccount.CalculateInterestAmount(4));
        Console.WriteLine();
        
        //Ivan's Account
        Account ivansAccount = new Loan(new Company("Ivan"), 1040.4m, 23.3f);
        
        Console.WriteLine("Ivan's interest amount: {0}", ivansAccount.CalculateInterestAmount(7));
        Console.WriteLine();
        
        //Dido's Account
        Account didosAccount = new Mortgage(new Individual("Dido"), 3422m, 5.4f);
        Console.WriteLine("Ivan's interest amount: {0}", didosAccount.CalculateInterestAmount(13));
    }
}