using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeProject
{
    public class Circle:IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                this.radius = ValidationMethods.ValidateValue(value);               
            }
        }

        public double CalculateArea()
        {
            double circleArea = Math.PI * Math.Pow(this.Radius, 2);
            return circleArea;
        }

        public double CalculatePerimeter()
        {
            double circlePerimeter = 2 * Math.PI * this.Radius;
            return circlePerimeter;
        }
    }
}
