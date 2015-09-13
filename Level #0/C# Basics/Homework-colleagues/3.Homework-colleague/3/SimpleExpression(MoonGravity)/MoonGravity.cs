using System;

    class MoonGravity
    {
        static void Main()
        {
            Console.Write("Your weight: ");
            double weight = Convert.ToDouble(Console.ReadLine());
            double moonWeight = (17.0 / 100) * weight;
            Console.WriteLine("Your weight on the moon: {0}", moonWeight);
        }
    }
