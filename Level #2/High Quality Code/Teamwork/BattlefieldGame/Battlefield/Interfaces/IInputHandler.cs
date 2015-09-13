namespace Battlefield.Interfaces
{
    /// <summary>
    /// An abstraction for an input handler responsible for receiving input from the user
    /// </summary>
    public interface IInputHandler
    {
        /// <summary>
        /// A method which reads input from the console in order to set the battlefield size
        /// </summary>
        /// <param name="renderer">Renderer responsible for showing messages on the output</param>
        /// <returns>A valid size of the battlefield entered by the user.</returns>
        int GetBattlefieldSize(IRenderer renderer);

        /// <summary>
        /// A method which reads user input in order to create a cell object which should be detonated.
        /// </summary>
        /// <param name="renderer">Renderer responsible for showing messages on the output</param>
        /// <returns>A cell object which should be detonated.</returns>
        Cell GetCellToExplode(IRenderer renderer);

        /// <summary>
        /// Blocking operation which waits for the user to enter some input.
        /// </summary>
        void Await();
    }
}