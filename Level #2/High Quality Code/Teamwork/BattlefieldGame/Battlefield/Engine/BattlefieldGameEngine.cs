namespace Battlefield.Engine
{
    using Interfaces;
    using Models.UI;

    /// <summary>
    /// The game engine of the Battlefield game responsible for controlling the game loop
    /// </summary>
    public class BattlefieldGameEngine : IBattlefieldGameEngine
    {
        /// <summary>
        /// A renderer which controls output messages
        /// </summary>
        private readonly IRenderer renderer;

        /// <summary>
        /// Input handler to receive input from the user
        /// </summary>
        private readonly IInputHandler inputHandler;

        /// <summary>
        /// Initializes a new instance of the BattlefieldGameEngine class
        /// </summary>
        /// <param name="renderer">A renderer which controls output messages</param>
        /// <param name="inputHandler">Input handler to receive input from the user</param>
        public BattlefieldGameEngine(IRenderer renderer, IInputHandler inputHandler)
        {
            this.renderer = renderer;
            this.inputHandler = inputHandler;
        }

        /// <summary>
        /// Gets a value indicating whether the game is running or not
        /// </summary>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// Main loop of the Battlefield game
        /// </summary>
        public void Run()
        {
            this.IsRunning = true;

            this.renderer.RenderMessage(GameMessages.WelcomeMessage);

            int size = this.inputHandler.GetBattlefieldSize(this.renderer);

            IBattlefield battlefield = Battlefield.Create(size);

            battlefield.DisplayField(this.renderer);

            while (this.IsRunning)
            {
                Cell cellToExplode = this.inputHandler.GetCellToExplode(this.renderer);

                while (!battlefield.IsCellInRange(cellToExplode) || !battlefield.IsCellMine(cellToExplode))
                {
                    this.renderer.RenderMessage(GameMessages.InvalidMoveMessage);
                    cellToExplode = this.inputHandler.GetCellToExplode(this.renderer);
                }

                battlefield.DetonateMine(cellToExplode);

                if (battlefield.GetRemainingMinesCount() == 0)
                {
                    this.IsRunning = false;
                }

                battlefield.DisplayField(this.renderer);
            }

            this.renderer.RenderMessage(string.Format(
                GameMessages.GameOverMessage, 
                battlefield.DetonatedMines));
            
            this.inputHandler.Await();
        }
    }
}