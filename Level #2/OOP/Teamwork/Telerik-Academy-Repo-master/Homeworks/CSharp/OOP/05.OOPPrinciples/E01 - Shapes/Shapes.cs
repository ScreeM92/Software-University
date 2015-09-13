using System;

class Shapes
{
    static void Main(string[] args)
    {
        Shape[] shapes = new Shape[] 
        {
            new Triangle(2.4, 7.4),
            new Rectangle(5, 8),
            new Circle(6)
        };

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.CalculateSurface());
        }

    }
}