using System;
using System.Linq;

namespace JustNotJewelryMain
{
    class Text : StaticObject
    {   
        public Text(Coordinates topLeft, char[,] body) 
            : base(topLeft) 
        {
            this.Body = body;
        }
    }
}
