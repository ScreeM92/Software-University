namespace Battlefield
{
    /// <summary>
    /// Represents a single cell on the battlefield with X and Y coordinates
    /// </summary>
    public struct Cell
    {
        /// <summary>
        /// Initializes a new instance of the Cell struct with given X and Y coordinates
        /// </summary>
        /// <param name="xCoordinate">The X-coordinate of the cell.</param>
        /// <param name="yCoordinate">The Y-coordinate of the cell.</param>
        public Cell(int xCoordinate, int yCoordinate)
            : this()
        {
            this.X = xCoordinate;
            this.Y = yCoordinate;
        }

        /// <summary>
        /// Gets the X-coordinate of a cell on the battlefield
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Gets the Y-coordinate of a cell on the battlefield
        /// </summary>
        public int Y { get; private set; }
    }
}
