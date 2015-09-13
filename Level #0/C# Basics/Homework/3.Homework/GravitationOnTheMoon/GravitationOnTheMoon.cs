using System;
    class GravitationOnTheMoon
    {
        static void Main()
        {
            Console.WriteLine("What is your weight?");
            double weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Your weight on the moon is {0}", (weight*17/100));
        }
    }

