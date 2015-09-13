namespace Battlefield
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Models;
    using Models.Factories;

    /// <summary>
    /// A class representing a battlefield where actions take place.
    /// </summary>
    public sealed class Battlefield : IBattlefield
    {
        /// <summary>
        /// A constant holding the minimum field size allowed.
        /// </summary>
        public const int MinFieldSize = 1;

        /// <summary>
        /// A constant holding the maximum field size allowed.
        /// </summary>
        public const int MaxFieldSize = 10;

        /// <summary>
        /// A constant representing the minimum percentage of cells on the battlefield which should be mines.
        /// </summary>
        private const double MinBombsPercentage = 0.15;

        /// <summary>
        /// A constant representing the maximum percentage of cells on the battlefield which should be mines.
        /// </summary>
        private const double MaxBombsPercentage = 0.30;

        /// <summary>
        /// A Random responsible for creating mines on random cells on the battlefield.
        /// </summary>
        private readonly IRandomNumberGenerator Rand;

        /// <summary>
        /// An instance of a battlefield
        /// </summary>
        private static Battlefield instance;

        /// <summary>
        /// A char matrix holding the values of all cells on the battlefield
        /// </summary>
        private char[,] field;

        /// <summary>
        /// The size of the battlefield.
        /// </summary>
        private int fieldSize;

        /// <summary>
        /// Initializes a new instance of the Battlefield class.
        /// </summary>
        /// <param name="size">The size (width and height) of the battlefield</param>
        private Battlefield(int size, IRandomNumberGenerator randomNumberGenerator)
        {
            this.Rand = randomNumberGenerator;
            this.FieldSize = size;
            this.InitField();
            this.InitMines();
        }

        /// <summary>
        /// Initializes a new instance of the Battlefield class.
        /// </summary>
        /// <param name="size">The size (width and height) of the battlefield</param>
        private Battlefield(int size)
            : this(size, new RandomNumberGenerator())
        {
        }

        /// <summary>
        /// Gets the number of detonated mines on the battlefield.
        /// </summary>
        public int DetonatedMines { get; private set; }

        /// <summary>
        /// Gets the field size of a battlefield.
        /// </summary>
        public int FieldSize
        {
            get
            {
                return this.fieldSize;
            }

            private set
            {
                if (value < 0 || 10 < value)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("The field size should be in the range [{0} ... {1}].", MinFieldSize, MaxFieldSize),
                        "fieldSize");
                }

                this.fieldSize = value;
            }
        }

        /// <summary>
        /// Static method which returns an instance of a battlefield.
        /// </summary>
        /// <param name="size">The size of the battlefield.</param>
        /// <returns>An instance of a battlefield.</returns>
        public static Battlefield Create(int size)
        {
            return instance ?? (instance = new Battlefield(size));
        }

        /// <summary>
        /// Displays the battle field on the console
        /// </summary>
        /// <param name="renderer">A renderer responsible for showing messages on the output</param>
        public void DisplayField(IRenderer renderer)
        {
            // top side numbers
            renderer.Output.AppendFormat("{0}", new string(' ', 2));
            for (int i = 0; i < this.FieldSize; i++)
            {
                renderer.Output.AppendFormat(" {0}", i);
            }

            renderer.Output.AppendLine();

            renderer.Output.AppendFormat("{0}", new string(' ', 2));
            for (int i = 0; i < 2 * this.FieldSize; i++)
            {
                renderer.Output.Append("-");
            }

            renderer.Output.AppendLine();

            // top side numbers
            for (int i = 0; i < this.FieldSize; i++)
            {
                // left side numbers
                renderer.Output.AppendFormat("{0}|", i);
                for (int j = 0; j < this.FieldSize; j++)
                {
                    renderer.Output.AppendFormat(" {0}", this.field[i, j]);
                }

                renderer.Output.AppendLine();
            }

            renderer.RenderOutput();
        }

        /// <summary>
        ///  Checks if the Cell is a mine
        /// </summary>
        /// <param name="cell">An object containing coordinates</param>
        /// <returns>True or False</returns>
        public bool IsCellMine(Cell cell)
        {
            return '1' <= this.field[cell.Y, cell.X] && this.field[cell.Y, cell.X] <= '5';
        }

        /// <summary>
        /// Checks if the battlefield contains a cell with certain coordinates.
        /// </summary>
        /// <param name="cell">An object containing coordinates</param>
        /// <returns>True or False</returns>
        public bool IsCellInRange(Cell cell)
        {
            bool isXCoordinateInRange = 0 <= cell.X && cell.X < this.FieldSize;
            bool isYCoordinateInRange = 0 <= cell.Y && cell.Y < this.FieldSize;

            return isXCoordinateInRange && isYCoordinateInRange;
        }

        /// <summary>
        /// Method that explodes cells from a given detonated cell
        /// </summary>
        /// <param name="detonatedCell">The cell that have been detonated</param>
        public void DetonateMine(Cell detonatedCell)
        {
            /*
             * We pass the detonated cell to the method cellsToExplode and get the
             * cells that have to explode
             */
            IEnumerable<Cell> cellsToExplode = this.GetCellsToExplode(detonatedCell);

            foreach (var cell in cellsToExplode)
            {
                this.DetonateCell(cell);
            }

            this.DetonatedMines++;
        }

        /// <summary>
        /// Gets the number of remaining mines in the battlefield
        /// </summary>
        /// <returns>Count of mines left</returns>
        public int GetRemainingMinesCount()
        {
            int count = 0;

            foreach (var cell in this.field)
            {
                if (cell != 'X' && cell != '-')
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Gets the number of mines that will be placed on the battlefield
        /// </summary>
        /// <returns>A valid number of mines in the specified range.</returns>
        public int GetInitialMinesCount()
        {
            int minesLowerLimit = (int)Math.Floor(MinBombsPercentage * this.FieldSize * this.FieldSize);
            int minesUpperLimit = (int)Math.Floor(MaxBombsPercentage * this.FieldSize * this.FieldSize);

            int minesCount = Rand.GetRandomNumber(minesLowerLimit, minesUpperLimit + 1);

            return minesCount;
        }

        /// <summary>
        /// Method that from a detonated cell returns the cells to explode after detonation
        /// </summary>
        /// <param name="cellToDetonate">A cell object representing a cell on the battlefield which should be detonated.</param>
        /// <returns>List of cells to explode</returns>
        private IEnumerable<Cell> GetCellsToExplode(Cell cellToDetonate)
        {
            IEnumerable<Cell> cellsToExplode;

            switch (this.field[cellToDetonate.Y, cellToDetonate.X] - '0')
            {
                case 1:
                    cellsToExplode = PatternFactory.GenerateFirstDetonationPattern(cellToDetonate);
                    break;
                case 2:
                    cellsToExplode = PatternFactory.GenerateSecondDetonationPattern(cellToDetonate);
                    break;
                case 3:
                    cellsToExplode = PatternFactory.GenerateThirdDetonationPattern(cellToDetonate);
                    break;
                case 4:
                    cellsToExplode = PatternFactory.GenerateFourthDetonationPattern(cellToDetonate);
                    break;
                case 5:
                    cellsToExplode = PatternFactory.GenerateFifthDetonationPattern(cellToDetonate);
                    break;
                default:
                    throw new ArgumentException("Cell value is invalid.");
            }

            return cellsToExplode;
        }

        /// <summary>
        /// Initializes the battlefield
        /// </summary>
        private void InitField()
        {
            this.field = new char[this.FieldSize, this.FieldSize];

            for (int row = 0; row < this.FieldSize; row++)
            {
                for (int column = 0; column < this.FieldSize; column++)
                {
                    this.field[row, column] = '-';
                }
            }
        }

        /// <summary>
        /// Initializes the mines on the battlefield
        /// </summary>
        private void InitMines()
        {
            int minesCount = this.GetInitialMinesCount();

            for (int i = 0; i < minesCount; i++)
            {
                bool isMinePlaced = false;

                while (!isMinePlaced)
                {
                    var tempXCoordinate = Rand.GetRandomNumber(0, this.FieldSize - 1);
                    var tempYCoordinate = Rand.GetRandomNumber(0, this.FieldSize - 1);

                    if (this.field[tempXCoordinate, tempYCoordinate] == '-')
                    {
                        this.field[tempXCoordinate, tempYCoordinate] = (char)(Rand.GetRandomNumber(1, 6) + '0');
                    }
                    else
                    {
                        isMinePlaced = true;
                    }
                }
            }
        }

        /// <summary>
        /// Detonates a single cell on the battlefield
        /// </summary>
        /// <param name="cellToDetonate">An object containing the coordinates of the detonated mine</param>
        private void DetonateCell(Cell cellToDetonate)
        {
            if (this.IsCellInRange(cellToDetonate))
            {
                this.field[cellToDetonate.Y, cellToDetonate.X] = 'X';
            }
        }
    }
}