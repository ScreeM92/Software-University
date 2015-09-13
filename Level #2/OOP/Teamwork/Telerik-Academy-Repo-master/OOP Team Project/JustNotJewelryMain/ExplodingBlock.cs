using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustNotJewelryMain
{
    class ExplodingBlock : FallingBlock
    {
        public ExplodingBlock(Coordinates topLeft, char[,] body)
            : base(topLeft, new Coordinates(1, 0), body)
        {

        }
    }
}
