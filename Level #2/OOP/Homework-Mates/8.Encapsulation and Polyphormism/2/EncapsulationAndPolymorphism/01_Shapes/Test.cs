using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shapes
{
    public class Test
    {
        public static void Main()
        {
            IShape triangle1 = new Triangle(2, 2, 60);
            IShape triangle2 = new Triangle(3.6, 5.1, 90);

            IShape rectangle1 = new Rectangle(1, 2);
            IShape rectangle2 = new Rectangle(12, 2.5);

            IShape circle1 = new Circle(3);
            IShape circle2 = new Circle(2.5);

            IShape[] shapes = new IShape[6] { triangle1, triangle2, rectangle1, rectangle2, circle1, circle2 };

            foreach (var shape in shapes)
            {
                Console.WriteLine(
                    "{0,-10}: Perimeter: {1:N2}, Area: {2:N2}",
                    shape.GetType().Name,
                    shape.CalculatePerimeter(),
                    shape.CalculateArea());
            }
        }
    }
}
