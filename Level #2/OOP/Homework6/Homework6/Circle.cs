using System;

class Circle : BasicShape
{ 

    public Circle(double radius)
        :base(radius)
    {
        this.Radius = radius;
    }

    public override double CalculateArea()
    {
        double area = 2 * Math.PI * this.Radius; ;
        return area;
    }

    public override double CalculatePerimeter()
    {
        double perimeter = Math.PI * this.Radius * this.Radius;
        return perimeter;
    }
}

