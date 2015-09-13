using System;

public abstract class BasicShape :IShape
{
    private double width;
    private double height;
    private double radius;   

    public double Radius
    {
        get
        {
            return this.radius;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Radius", "Radius can not be a negative number");
            }

            this.radius = value;
        }
    }
    public double Width
    {
        get
        {
            return this.width;
        }

        protected set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Width", "Width can not be a negative number.");
            }

            this.width = value;
        }
    }

    public double Height
    {
        get
        {
            return this.height;
        }

        protected set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Height", "Height can not be a negative number");
            }

            this.height = value;
        }
    }

    public BasicShape(double width, double height)
    {
        this.Height = height;
        this.Width = width;
    }

    public BasicShape(double radius)
    {
        this.Radius = radius;
    }

    public virtual double CalculateArea()
    {
        return 0;
    }

    public virtual double CalculatePerimeter()
    {
        return 0;
    }
}