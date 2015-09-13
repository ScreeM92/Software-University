using System;
    class Program
    {
        static void Main()
        {
            Console.Write("Enter a positive integer number: ");
            int number = int.Parse(Console.ReadLine());
            int diveder = 2;
            int dividerMax = (int)Math.Sqrt(number);
            bool prime = true;
            if (number > 2)
            {
                while (prime && (diveder <= dividerMax))
                {
                    if (number % diveder == 0)
                    {
                        prime = false;
                    }
                    diveder++;
                }
                Console.WriteLine("Prime? {0}", prime);              
            }
            else
            {
                Console.WriteLine("False");
            }          
        }
    }

