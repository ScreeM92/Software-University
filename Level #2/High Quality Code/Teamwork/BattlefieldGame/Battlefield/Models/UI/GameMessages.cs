namespace Battlefield.Models.UI
{
    /// <summary>
    /// A static class holding game messages as constants
    /// </summary>
    public static class GameMessages
    {
        /// <summary>
        /// The default welcome message of the game
        /// </summary>
        public const string WelcomeMessage = "Welcome to the Battlefield game!";

        /// <summary>
        /// The default message to show when the user tries to make an invalid move
        /// </summary>
        public const string InvalidMoveMessage = "---Invalid Move---";

        /// <summary>
        /// The default message to show when the game ends
        /// </summary>
        public const string GameOverMessage = "Game Over. Detonated Mines: {0}";

        /// <summary>
        /// A message prompting the user to enter the size of the board
        /// </summary>
        public const string BattlefieldSizePrompt = "Enter legal size of board: ";

        /// <summary>
        /// A message prompting the user to enter valid coordinates of a cell to detonate
        /// </summary>
        public const string CoordinatesPrompt = "Enter coordinates: ";
    }
}
