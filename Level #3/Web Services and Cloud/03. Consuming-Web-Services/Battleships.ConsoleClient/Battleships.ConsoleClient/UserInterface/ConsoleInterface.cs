namespace Battleships.ConsoleClient.UserInterface
{
    using System;
    using Interfaces;

    public class ConsoleInterface : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string format, params string[] args)
        {
            Console.WriteLine(format);
        }
    }
}