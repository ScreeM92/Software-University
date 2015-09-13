using System;
using System.Linq;

namespace JustNotJewelryMain
{   
    public class FallingBlock : MovableObject
    {
        public FallingBlock(Coordinates topLeft, Coordinates speed, char[,] body)
            : base(topLeft, speed, body)
        {
            
        }

       
    }
}
