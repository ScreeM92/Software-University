namespace _01_Shapes
{
    using System;

    public class Rectangle : BasicShape, IShape
    {
        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }

        public override double CalculatePerimeter()
        {
            return (this.Height + this.Width) * 2;
        }
    }
}
