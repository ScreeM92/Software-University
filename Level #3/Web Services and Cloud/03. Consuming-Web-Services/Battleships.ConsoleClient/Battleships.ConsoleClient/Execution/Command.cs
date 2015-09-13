namespace Battleships.ConsoleClient.Execution
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using System.Web.Script.Serialization;

    public class Command : ICommand
    {
        public Command(string commandLine)
        {
            this.ParseCommand(commandLine);
        }

        public string Name { get; private set; }

        public IList<string> Parameters { get; private set; }

        private void ParseCommand(string commandLine)
        {
            string[] commandParts = commandLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            this.Name = commandParts[0];
            var commandParameters = this.ParseCommandParameters(commandParts);
            this.Parameters = commandParameters;
        }

        private IList<string> ParseCommandParameters(IReadOnlyList<string> commandParts)
        {
            var parameters = new List<string>();
            
            for (int i = 1; i < commandParts.Count; i++)
            {
                parameters.Add(commandParts[i]);
            }

            return parameters;
        }
    }
}