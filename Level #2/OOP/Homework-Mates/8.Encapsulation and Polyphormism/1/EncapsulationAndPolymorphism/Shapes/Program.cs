using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape triangleOne = new Triangle(2.5, 2, 60);
            IShape triangleTwo = new Triangle(3.1, 2.1, 90);

            IShape rectangleOne = new Rectangle(2.5, 2);
            IShape rectangleTwo = new Rectangle(3.1, 2.1);

            IShape circleOne = new Circle(2.5);
            IShape circleTwo = new Circle(2.1);

            IShape[] shapes = new IShape[6] { triangleOne, triangleTwo, rectangleOne, rectangleTwo, circleOne, circleTwo };

            foreach (var shape in shapes)
            {
                Console.WriteLine("{0,-20}: Perimeter: {1:N2}, Area: {2:N2}",
                    shape.GetType().Name, shape.CalculatePerimeter(), shape.CalculateArea());
            }
        }
    }
}
