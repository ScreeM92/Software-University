namespace Battleships.ConsoleClient.Engine
{
    using System;
    using Execution;
    using Interfaces;
    using Utilities;

    public class BattleshipsEngine : IEngine
    {
        private readonly CommandExecutor commandExecutor;
        private readonly IUserInterface userInterface;
        private readonly BattleshipsData data;

        public BattleshipsEngine(CommandExecutor commandExecutor, IUserInterface userInterface, BattleshipsData data)
        {
            this.commandExecutor = commandExecutor;
            this.userInterface = userInterface;
            this.data = data;
        }

        public void Run()
        {
            this.userInterface.WriteLine(Messages.Legend);
            string commandLine = this.userInterface.ReadLine();

            while (commandLine != "exit")
            {
                commandLine = commandLine.Trim();
                if (!string.IsNullOrEmpty(commandLine))
                {
                    try
                    {
                        var command = new Command(commandLine);
                        this.commandExecutor.ExecuteCommand(command, this.data);
                    }
                    catch (Exception ex)
                    {
                        this.userInterface.WriteLine(ex.Message);
                    }
                }

                commandLine = this.userInterface.ReadLine();
            }
        }
    }
}