namespace Battlefield
{
    using Engine;
    using Interfaces;
    using Models.UI;

    /// <summary>
    /// Main class for the Battlefield game
    /// </summary>
    public class BattlefieldApp
    {
        /// <summary>
        /// Main method for the game
        /// </summary>
        public static void Main()
        {
            IRenderer consoleRenderer = new ConsoleRenderer();
            IInputHandler inputHandler = new ConsoleInputHandler();
            IBattlefieldGameEngine engine = new BattlefieldGameEngine(consoleRenderer, inputHandler);

            engine.Run();
        }
    }
}