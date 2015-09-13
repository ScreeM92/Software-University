using System;


namespace Trapezoid
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("This program estemate the area of trapezoid");
            Console.WriteLine("Please enter the side a");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the side b");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the high h");
            double h = double.Parse(Console.ReadLine());
            Console.WriteLine(new string('*', 70));
            Console.WriteLine("The area of your trapezoid with side a={0} , side b={1} , hight h={2} is {3}", a, b, h, (a + b) * h / 2);
            Console.WriteLine(new string('*',70));
        }
    }
}
