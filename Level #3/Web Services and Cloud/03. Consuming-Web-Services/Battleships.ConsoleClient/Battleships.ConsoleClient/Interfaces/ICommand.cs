namespace Battleships.ConsoleClient.Interfaces
{
    using System.Collections.Generic;

    public interface ICommand
    {
        string Name { get; }

        IList<string> Parameters { get; }
    }
}