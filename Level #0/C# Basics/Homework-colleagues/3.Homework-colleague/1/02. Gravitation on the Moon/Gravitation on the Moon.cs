using System;

 class GravitationOnTheMoon
    {
        static void Main()
        {
            Console.WriteLine("Enter your weight in kgs");
            string weight = Console.ReadLine();
            double EarthWeight = double.Parse(weight);
            double MoonWeight = EarthWeight * 0.17;
            Console.WriteLine("Your moon weight is " + MoonWeight + " kg");
        }
    }
