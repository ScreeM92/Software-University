using System;

internal abstract class Shape
{
    public double Width { get; protected set; }
    public double Height { get; protected set; }

    public Shape(double oneSide)
    {
        this.Width = oneSide;
    }

    public Shape(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public virtual double CalculateSurface()
    {
        return -1;
    }
}
