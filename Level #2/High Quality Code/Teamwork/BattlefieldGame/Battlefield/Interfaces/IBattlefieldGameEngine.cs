namespace Battlefield.Interfaces
{
    /// <summary>
    /// Represents an abstraction for a BattlefieldGameEngine
    /// </summary>
    public interface IBattlefieldGameEngine
    {
        /// <summary>
        /// Gets a value indicating whether the game is running or not
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Main loop of the Battlefield game
        /// </summary>
        void Run();
    }
}