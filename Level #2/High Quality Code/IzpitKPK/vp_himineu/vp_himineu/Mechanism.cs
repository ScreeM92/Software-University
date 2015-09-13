namespace VehicleParkSystem
{
    using System;

    class Mechanism
    {
        private Executor exec;

        public Mechanism(Executor ex)
        {
            this.exec = ex;
        }

        public Mechanism()
            :this (new Executor())
        {
        }

        public void Run()
        {
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == null) break;

                commandLine.Trim();

                if (!string.IsNullOrEmpty(commandLine))
                {
                    try
                    {
                        var command = new CommandHandler(commandLine);
                        string commandResult = exec.Execute(command);
                        Console.WriteLine(commandResult);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
