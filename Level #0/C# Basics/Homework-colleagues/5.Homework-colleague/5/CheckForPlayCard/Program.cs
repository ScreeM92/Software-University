using System;
class CheckPlayCard
{
    static void Main(string[] args)
    {

        string[] playCards = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter your symbol:\t");
            string enteredSymbol = Console.ReadLine();
            int pos = Array.IndexOf(playCards, enteredSymbol);
            if (pos != -1)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n{0} is a playing card symbol.\n", enteredSymbol); 
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n{0} is NOT correct.\n", enteredSymbol);
            }
        }
    }
}
