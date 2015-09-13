using System;
class CheckForPlayCard
{
    static void Main()
    {
        Console.Write("Enter Play Card 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A: ");
        string card = Convert.ToString(Console.ReadLine());
        switch (card)
        {
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
            case "10":
            case "J":
            case "Q":
            case "K":
            case "A":
                Console.WriteLine("yes");break;
            default:
                Console.WriteLine("no");break;
        }
    }
}