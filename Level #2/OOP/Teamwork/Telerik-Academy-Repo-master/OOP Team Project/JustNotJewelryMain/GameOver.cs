using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustNotJewelryMain
{
    static class GameOver
    {
        public static bool HasGameEnded(GameObject obj, Renderer renderer)
        {
            return obj.TopLeft.Row == 5 &&
                renderer.GridMatrix[obj.TopLeft.Row + obj.GetImage().GetLength(1), obj.TopLeft.Col] != ' ';
        }

        public static void OnGameOver(string message, ConsoleColor color, short coordCol, short CoordRow)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(coordCol, CoordRow);

            Console.WriteLine(message);
        }
    }
}
