using System;
using System.Linq;

namespace JustNotJewelryMain
{
    class StaticObject : GameObject
    {   
        private static readonly char[,] body = new char[,] { { '#' } };
        
        public StaticObject(Coordinates topLeft)
            : base(topLeft, StaticObject.body)
        {
            
        }
        public StaticObject(Coordinates topLeft, ConsoleColor color)
            : this(topLeft)
        {
            this.ObjectColor = color;
        }

        //default constructor
        public StaticObject()            
        {            
            this.ObjectColor = ConsoleColor.White;
            this.isDestroyed = false;
            this.Body = new char[,] { { '#' } };
        }

        public override void Update()
        {
           
        }

        //public override bool Equals(object obj)
        //{
        //    //TO DO cast obj to static objecct
        //    return this.ObjectColor == obj.ObjectColor;
        //}
    }
}
