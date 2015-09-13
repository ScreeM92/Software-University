using System;
    class ExchangeIfGreater
    {
        static void Main()
        {
            Console.WriteLine("Please enter a:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter b:");
            double b = double.Parse(Console.ReadLine());
            if (a > b)
            {
                Console.Write(b + " " + a);
            }
            else 
            {
                Console.Write(a + " " + b);
            }
            
        }
    }

    

