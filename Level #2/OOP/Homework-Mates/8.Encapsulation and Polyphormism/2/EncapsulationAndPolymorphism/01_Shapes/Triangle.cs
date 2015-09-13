namespace _01_Shapes
{
    using System;

    class Triangle : BasicShape, IShape
    {
        private double angle;

        public Triangle(double width, double height, double angle)
            : base(width, height)
        {
            this.Angle = angle;
        }

        public double Angle
        {
            get
            {
                return this.angle;
            }

            set
            {
                if (value < 0 || value >360)
                {
                    throw new ArgumentOutOfRangeException("angle", "Angle can't be negative or can;t be bigger than 360! ");
                }

                this.angle = value;
            }
        }


        public override double CalculateArea()
        {
            return (Math.Sin(this.angle * Math.PI / 180) * this.Width * this.Height) / 2;

        }

        public override double CalculatePerimeter()
        {
            return this.Width + this.Height
                   + Math.Sqrt(
                       (this.Width * this.Width) + (this.Height * this.Height)
                       - (2 * this.Height * this.Width * Math.Cos(this.angle * Math.PI / 180)));
        }

    }
}
