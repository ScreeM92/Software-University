using System;

class Circle : Shape
{
    public Circle(double size) 
        : base(size) 
    {
        this.Height = size;
    }

    public override double CalculateSurface()
    {
        double radius = this.Width / (2 * Math.PI);
        double surface = Math.PI * (radius * radius);
        return surface;
    }
}