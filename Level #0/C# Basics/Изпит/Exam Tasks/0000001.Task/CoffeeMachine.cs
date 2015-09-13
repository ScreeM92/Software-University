using System;
    class CoffeeMachine
    {
        static void Main()
        {
            int N1 = int.Parse(Console.ReadLine());
            int N2 = int.Parse(Console.ReadLine());
            int N3 = int.Parse(Console.ReadLine());
            int N4 = int.Parse(Console.ReadLine());
            int N5 = int.Parse(Console.ReadLine());
            double A = double.Parse(Console.ReadLine());
            double P = double.Parse(Console.ReadLine());

            double sumN1 = N1 * 0.05;
            double sumN2 = N2 * 0.10;
            double sumN3 = N3 * 0.20;
            double sumN4 = N4 * 0.50;
            double sumN5 = N5 * 1.00;

            double sumN = sumN1 + sumN2 + sumN3 + sumN4 + sumN5;
            double totalSum = sumN + P;

            if (P > A)
            {
                Console.WriteLine("More {0:F2}", P - A);
            }
            else if (A <= totalSum )
            {
                Console.WriteLine("Yes {0:F2}",totalSum - A );
            }
            else if (A > totalSum)
            {
                Console.WriteLine("No {0:F2}", A - totalSum);
            }
            
        }
    }

