using System;

    class Triangle : BasicShape
    {
        private double Depth { get; set; }

        public Triangle(double width, double height, double depth )
            : base(width, height)
        {
            this.Depth = depth;
            if (!TriangleIsValid(Width, Height, Depth))
            {
                throw new ArgumentException("These three sides can not form a triangle.");  
            }
        }

        public override double CalculateArea()
        {
            double area = this.Width * this.Height / 2;
            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = this.Width + this.Height + this.Depth;
            return perimeter;
        }

        private bool TriangleIsValid(double sizeA, double sizeB, double sizeC)
        {
            return this.Height + this.Width > this.Depth && this.Height + this.Depth > this.Width && this.Width + this.Depth > this.Height;
        }
    }

