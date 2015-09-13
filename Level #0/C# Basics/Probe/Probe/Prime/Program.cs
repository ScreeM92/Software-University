using System;
    class Prime
    {
        static void Main()
        {
            Console.WriteLine("Please enter number:");
            int num = int.Parse(Console.ReadLine());
            bool Prime = true;
            if (num % 2 == 0 && num != 0)
            {
                Console.WriteLine(Prime);
            }
            
            else
            {
                Prime = false;
                Console.WriteLine(Prime);
            }
           
        }
    }

