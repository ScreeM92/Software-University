using System;

class Rectangles
    {
        static void Main()
        {
            Console.WriteLine("Write the rectangle's width");
            string WidthInput = Console.ReadLine();
            Console.WriteLine("Write the rectangle's height");
            string HeightInput = Console.ReadLine();
            decimal width = decimal.Parse(WidthInput);
            decimal height = decimal.Parse(HeightInput);
            decimal perimeter = (width * 2) + (height * 2);
            decimal area = width * height;
            Console.WriteLine("The perimeter is " + perimeter);
            Console.WriteLine("The area is " + area);
        }
    }
