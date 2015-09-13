using System;
using System.Linq;

namespace JustNotJewelryMain
{
    interface IInput
    {
        event EventHandler OnLeftArrowPress;
        event EventHandler OnRightArrowPress;
        event EventHandler OnSpacebarPress;

        void ProcessInput();
    }
}
