using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeProject
{
    public class Triangle:BasicShape
    {       
        private double sideC;
        
        public Triangle(double width, double height, double sideC)
            :base(width, height)
        {
            this.SideC = sideC;
            ValidationMethods.ValidateTriangle(height, width, sideC);
            
        }

        public double SideC
        {
            get
            {
                return this.sideC;
            }
            set
            {
                this.sideC = ValidationMethods.ValidateValue(value);
               
            }
        }
        
        public override double CalculateArea()
        {
            double p = (this.width + this.height + this.sideC) / 2;
            double trinagleArea = Math.Sqrt(p * (p - this.Width) * (p - this.Height) * (p - this.sideC));
            return trinagleArea;
        }

        public override double CalculatePerimeter()
        {
            double trianglePerimeter = this.width + this.height + this.sideC;
            return trianglePerimeter;
        }
    }
}
