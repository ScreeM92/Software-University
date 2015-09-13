using System;

namespace Shapes
{
    abstract class BasicShape : IShape
    {
        private double width;
        private double height;

        public BasicShape(double width, double height)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Width
        {
            get { return this.width; }
            set
            {
                if(Double.IsNaN(value))
                {
                    throw new ArgumentException("Width have to be a number.");
                }
                else
                {
                    this.width = value;
                }
            }
        }

        public double Height
        {
            get { return this.height; }
            set
            {
                if (Double.IsNaN(value))
                {
                    throw new ArgumentException("Height have to be a number.");
                }
                else
                {
                    this.height = value;
                }
            }
        }

        public abstract double CalculateArea()
        {
            throw new NotImplementedException();
        }

        public abstract double CalculatePerimeter()
        {
            throw new NotImplementedException();
        }
    }
}
