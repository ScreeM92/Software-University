using System;
class CircleAndRectangle
{
    static void Main()
    {
        Console.Write("x =");
        double x = double.Parse(Console.ReadLine());
        Console.Write("y =");
        double y = double.Parse(Console.ReadLine());
        bool isInCircle = (x - 1) * (x - 1) + (y - 1) * (y - 1) <= (1.5 * 1.5);
        bool isInSideRectangle = (-1 <= x && x <= 5) && (-1 <= y && y <= 1);
        if (isInCircle && !isInSideRectangle)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}

