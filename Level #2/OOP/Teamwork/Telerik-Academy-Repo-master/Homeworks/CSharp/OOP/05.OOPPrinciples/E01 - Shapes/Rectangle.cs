using System;

class Rectangle : Shape
{
    public Rectangle(double width, double height) : base(width, height) { }
    
    public override double CalculateSurface()
    {
        double surface = (this.Height * this.Width) / 2;
        return surface;
    }
}
