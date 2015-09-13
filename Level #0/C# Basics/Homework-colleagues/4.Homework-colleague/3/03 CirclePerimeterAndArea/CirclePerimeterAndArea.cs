/*Write a program that reads the radius r of a circle and prints its perimeter and area 
formatted with 2 digits after the decimal point.*/

using System;

class CirclePerimeterAndArea
{
    static void Main(string[] args)
    {
        Console.Write("Enter radius r of the circle: ");
        float r = float.Parse(Console.ReadLine());

        Console.WriteLine("The perimeter of the circle is {0:0.00}", 2 * Math.PI * r);
        Console.WriteLine("The area of the circle is {0:0.00}", Math.PI * r * r);
    }
}
