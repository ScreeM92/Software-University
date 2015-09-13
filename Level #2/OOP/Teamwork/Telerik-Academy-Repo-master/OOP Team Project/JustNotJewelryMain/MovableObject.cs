using System;
using System.Linq;

namespace JustNotJewelryMain
{
    public class MovableObject : GameObject
    {
        public Coordinates Speed { get; set; }
        public MovableObject(Coordinates topLeft, Coordinates speed, char[,] body)
            : base(topLeft, body)
        {
            this.Speed = speed;
        }

        public void UpdatePosition()
        {
            this.TopLeft += this.Speed;
        }

        public override void Update()
        {
            this.UpdatePosition();
        }
    }
}
