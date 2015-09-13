using System;
    
    class InsideCircleOutsideRectangle
    {
        static void Main()
        {
            Console.Write("X: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Y: ");
            double y = Convert.ToDouble(Console.ReadLine());

            double z = Math.Sqrt(Math.Pow(x-1, 2) + Math.Pow(y-1, 2));
            Console.WriteLine(z <= 1.5 && (inRec(x,y)==false)); //or: (z<=1.5 && y>1)
        }

        static bool inRec(double x1, double y1)
        {
            if (y1 >= -1 && y1 <= 1 && x1 <= 5 && x1 >= -1) return true;
            return false;
        }
    }
