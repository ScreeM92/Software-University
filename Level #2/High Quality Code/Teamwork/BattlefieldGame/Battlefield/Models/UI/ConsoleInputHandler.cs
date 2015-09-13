namespace Battlefield.Models.UI
{
    using System;
    using Interfaces;

    /// <summary>
    /// A class for receiving user input from the console
    /// </summary>
    public class ConsoleInputHandler : IInputHandler
    {
        // TODO Make this handler return strings and leave the parsing and checking to the engine

        /// <summary>
        /// A method which reads input from the console in order to set the battlefield size
        /// </summary>
        /// <param name="renderer">Renderer responsible for showing messages on the output</param>
        /// <returns>A valid size of the battlefield entered by the user.</returns>
        public int GetBattlefieldSize(IRenderer renderer)
        {
            int size;

            renderer.RenderMessage(GameMessages.BattlefieldSizePrompt);
            var tempFieldSize = Console.ReadLine();

            while ((!int.TryParse(tempFieldSize, out size))
                   || (size < Battlefield.MinFieldSize)
                   || (size > Battlefield.MaxFieldSize))
            {
                renderer.RenderMessage(GameMessages.BattlefieldSizePrompt);
                tempFieldSize = Console.ReadLine();
            }

            return size;
        }

        /// <summary>
        /// A method which reads user input in order to create a cell object which should be detonated.
        /// </summary>
        /// <param name="renderer">Renderer responsible for showing messages on the output</param>
        /// <returns>A cell object which should be detonated.</returns>
        public Cell GetCellToExplode(IRenderer renderer)
        {
            int xCoordinate;
            int yCoordinate;

            renderer.RenderMessage(GameMessages.CoordinatesPrompt);
            var coordinates = Console.ReadLine().Split();

            while (coordinates.Length != 2
                   || !int.TryParse(coordinates[1], out xCoordinate)
                   || !int.TryParse(coordinates[0], out yCoordinate))
            {
                renderer.RenderMessage(GameMessages.InvalidMoveMessage);
                renderer.RenderMessage(GameMessages.BattlefieldSizePrompt);
                coordinates = Console.ReadLine().Split();
            }

            return new Cell(xCoordinate, yCoordinate);
        }

        /// <summary>
        /// Blocking operation which waits for the user to enter some input.
        /// </summary>
        public void Await()
        {
            Console.ReadKey();
        }
    }
}
