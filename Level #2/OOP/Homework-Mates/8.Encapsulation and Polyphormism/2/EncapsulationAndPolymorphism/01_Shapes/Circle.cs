namespace _01_Shapes
{
    using System;

    class Circle : BasicShape,IShape
    {
        public Circle(double width)
            : base(width, width)
        {
        }

        public override double CalculateArea()
        {
            return Math.PI * this.Width * this.Width / 4;
        }

        public override  double CalculatePerimeter()
        {
            return Math.PI * 2 * this.Width / 2;
        }
    }
}
