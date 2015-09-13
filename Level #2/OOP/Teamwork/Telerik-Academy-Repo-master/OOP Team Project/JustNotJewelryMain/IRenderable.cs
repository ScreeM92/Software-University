using System;
using System.Linq;

namespace JustNotJewelryMain
{
    interface IRenderable
    {
        Coordinates GetTopLeftCorner();
        char[,] GetImage();
    }
}
