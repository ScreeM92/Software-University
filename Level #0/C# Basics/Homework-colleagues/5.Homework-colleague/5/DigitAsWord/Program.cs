using System;
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.White;
            string[] words = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            Console.Write("Enter your digit:\t");
            double number = int.Parse(Console.ReadLine());
            if (number < 10 && number > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("{0} is {1}", number, words[(int)number - 1]);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Not a digit");
            }
        }
    }
}