using System;
using System.Linq;

namespace JustNotJewelryMain
{
    public abstract class GameObject : IRenderable
    {
        public Coordinates TopLeft { get; set; }
        public char[,] Body { private get; set; }
        public ConsoleColor ObjectColor { get; set; }
        private static ConsoleColor defaultColor = ConsoleColor.White;
        public bool isDestroyed { get; set; }

        public GameObject(Coordinates topLeft, char[,] body)
        {
            this.TopLeft = topLeft;
            this.Body = body;
            this.ObjectColor = GameObject.defaultColor;
            this.isDestroyed = false;
        }

        //default constructor
        public GameObject()
        {            
            this.ObjectColor = GameObject.defaultColor;
            this.isDestroyed = false;
        }
        

        public abstract void Update();

        public virtual char[,] GetImage()
        {
            return this.Body;
        }

        public virtual Coordinates GetTopLeftCorner()
        {
            return this.TopLeft;
        }
    }
}
