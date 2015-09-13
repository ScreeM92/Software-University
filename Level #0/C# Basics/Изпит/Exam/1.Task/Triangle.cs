using System;
    class Triangle
    {
        static void Main()
        {
            int Ax = int.Parse(Console.ReadLine());
            int Ay = int.Parse(Console.ReadLine());
            int Bx = int.Parse(Console.ReadLine());
            int By = int.Parse(Console.ReadLine());
            int Cx = int.Parse(Console.ReadLine());
            int Cy = int.Parse(Console.ReadLine());

            double A = Math.Sqrt(Math.Pow(Bx - Ax, 2) + Math.Pow(By - Ay, 2));
            double B = Math.Sqrt(Math.Pow(Cx - Bx, 2) + Math.Pow(Cy - By, 2));
            double C = Math.Sqrt(Math.Pow(Cx - Ax, 2) + Math.Pow(Cy - Ay, 2));

            double p = (A + B + C)/2;
            double Area = Math.Sqrt(p*(p - A)*(p - B)*(p - C));

            if (A + B >= C && B + C >= Ax && A + C >= B)

            {
                Console.WriteLine("Yes");
                Console.WriteLine("{0:0.00}", Area);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("{0:0.00}", A);
            }
        }
    }

