using System;
using System.Linq;

namespace JustNotJewelryMain
{
    class InfoWall : StaticObject
    {   
        public InfoWall(Coordinates topLeft, char[,] body) 
            : base(topLeft) 
        {
            this.ObjectColor = ConsoleColor.DarkGreen;
            this.Body = body;
        }
    }
}
