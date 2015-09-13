using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeProject
{
    public class Rectangle:BasicShape
    {
        public Rectangle(double width, double height)
            : base(width, height) { }

        public override double CalculateArea()
        {
            double rectangleArea = this.Width * this.Height;
            return rectangleArea;
        }

        public override double CalculatePerimeter()
        {
            double rectaglePerimeter = 2 * (this.Width + this.Height);
            return rectaglePerimeter;
        }
    }
}
