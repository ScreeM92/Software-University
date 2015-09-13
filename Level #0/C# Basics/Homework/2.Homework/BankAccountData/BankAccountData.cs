using System;

class BankAccountData
{
    static void Main()
    {
        Console.Title = "Problem 11. Bank Account Data";
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string name1 = "Ivan";
        string name2 = "Ivanov";
        string name3 = "Ivanov";
        decimal balance = 45458.68m;
        char symbol = '$';
        string bankName = "Universe Bank";
        string numIBAN = "BG80 BNBG 4333 1120 3446 11";
        string codeBIC = "JGNSKORL";
        long cardNum1 = 4567398566336494;
        long cardNum2 = 3402222129867901;
        long cardNum3 = 5426975583239762;

        object objName = (name1 + " " + name2 + " " + name3);
        object objMoney = (balance + "" + (char)symbol);

        Console.WriteLine(" Bank account record: \n \n Holder: {0} \n Bank: {1} \n Balance: {2} \n IBAN: {3} \n BIC: {4}", objName, bankName, objMoney, numIBAN, codeBIC);
        Console.WriteLine();
        Console.WriteLine(" Card Numbers: \n Visa: {0} \n American Express: {1} \n Discover: {2}", cardNum1, cardNum2, cardNum3);
        Console.WriteLine();
    }
}