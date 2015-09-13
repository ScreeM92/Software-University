using System;

    class PointInCircle
    {
        static void Main()
        {
            Console.Write("X: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Y: ");
            double y = Convert.ToDouble(Console.ReadLine());

            double z = Math.Sqrt(Math.Pow(x,2)+Math.Pow(y,2));
            Console.WriteLine(z<=2);
        }
    }
