using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeProject
{
    public class ShapeProject
    {
        static void Main()
        {
            IShape[] shapes = new IShape[]
            {
                new Triangle(1.5, 2.5, 3.5),
                new Rectangle(5.3, 3),
                new Circle(3.66)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.GetType().Name + " [Area: {0:f2}, Perimeter: {1:f2}]", shape.CalculateArea(), shape.CalculatePerimeter());
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
