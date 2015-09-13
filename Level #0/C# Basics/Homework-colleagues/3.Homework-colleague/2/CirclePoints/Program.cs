using System;


namespace CirclePoints
{
    class Program
    {
        static void Main()
        {
            var circle = new { position = new { x = 0, y = 0 }, radius = (double)2 };
            Console.WriteLine("enter x");
            double pointX = double.Parse(Console.ReadLine());
            Console.WriteLine("enter y");
            double pointY = double.Parse(Console.ReadLine());
            Console.WriteLine(new string('*',25));
            Console.WriteLine(Math.Sqrt(Math.Pow(pointX, 2) + Math.Pow(pointY, 2)) <= circle.radius);
            Console.WriteLine(new string('*', 25));
            

        }
    }
}
