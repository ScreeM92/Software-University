namespace Battleships.ConsoleClient
{
    using System.Globalization;
    using System.Threading;
    using Engine;
    using Execution;
    using UserInterface;

    public class BattleshipsMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var userInterface = new ConsoleInterface();
            var commandExecutor = new CommandExecutor(userInterface);
            var data = new BattleshipsData();
            var engine = new BattleshipsEngine(commandExecutor, userInterface, data);
            engine.Run();
        }
    }
}
