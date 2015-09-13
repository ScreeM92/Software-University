using System;
class BankAccountData
{
    static void Main()
    {
        string firstName = "Ivan";
        string middleName = "Georgiev";
        string lastName = "Ivanov";
        decimal money = 1000.00m;
        string bankName = "BNB";
        string iban = "BG11 BNNB 1111 1111 1111 11";
        long cardNumber1 = 111111111111;
        long cardNumber2 = 111111111111111;
        long cardNumber3 = 111111111111111;
        Console.WriteLine("{0} {1} {2}\nAvailable amount of money: {3}\n{4} IBAN: {5}\nCard number: {6}\nCard number: {7}\nCard number: {8}", firstName, middleName, lastName, money, bankName, iban, cardNumber1, cardNumber2, cardNumber3);

    }
}