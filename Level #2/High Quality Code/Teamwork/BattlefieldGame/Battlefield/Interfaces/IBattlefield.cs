namespace Battlefield.Interfaces
{
    /// <summary>
    /// Represents an abstraction for Battlefields.
    /// </summary>
    public interface IBattlefield
    {
        /// <summary>
        /// Gets the number of detonated mines on the battlefield.
        /// </summary>
        int DetonatedMines { get; }

        /// <summary>
        /// Gets the field size of a battlefield.
        /// </summary>
        int FieldSize { get; }

        /// <summary>
        /// Displays the battlefield on the output
        /// </summary>
        /// <param name="renderer">The renderer responsible for displaying the field on the output</param>
        void DisplayField(IRenderer renderer);

        /// <summary>
        /// Method that explodes cells from a given detonated cell
        /// </summary>
        /// <param name="detonatedCell">The cell that have been detonated</param>
        void DetonateMine(Cell detonatedCell);

        /// <summary>
        /// Gets the number of remaining mines in the battlefield
        /// </summary>
        /// <returns>Count of mines left</returns>
        int GetRemainingMinesCount();

        /// <summary>
        /// Gets the number of mines that will be placed on the battlefield
        /// </summary>
        /// <returns>A valid number of mines to be placed on the battlefield</returns>
        int GetInitialMinesCount();

        /// <summary>
        /// Checks if the battlefield contains a cell with certain coordinates.
        /// </summary>
        /// <param name="cell">An object containing coordinates</param>
        /// <returns>True or False</returns>
        bool IsCellInRange(Cell cell);

        /// <summary>
        ///  Checks if the Cell is a mine
        /// </summary>
        /// <param name="cell">An object containing coordinates</param>
        /// <returns>True or False</returns>
        bool IsCellMine(Cell cell);
    }
}