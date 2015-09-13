using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeProject
{
    public abstract class BasicShape:IShape
    {
        protected double width;
        protected double height;

        public BasicShape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = ValidationMethods.ValidateValue(value);                
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = ValidationMethods.ValidateValue(value);                
            }
        }

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();

        
        
    }
}
