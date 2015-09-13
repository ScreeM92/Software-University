using System;
using System.Collections.Generic;
    class Test
    {
        static void Main()
        {
            IList<BasicShape> shapes = new List<BasicShape>()
            {
                new Triangle(15, 10, 20),
                new Rectangle(10, 20),
                new Circle(5)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.CalculateArea());
                Console.WriteLine(shape.CalculatePerimeter());
            }
        }
    }

