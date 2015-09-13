using System;
    class DivideBy7And5
    {
        static void Main()
        {
            Console.WriteLine("Enter number:");
            while (true)
            {
                int count = int.Parse(Console.ReadLine());

                if ((count % 5 == 0) && (count % 7 == 0))
                {
                    Console.WriteLine("True");
                    break;
                }
                else
                {
                    Console.WriteLine("False");
                }

                Console.WriteLine("Enter new number:");
               }
        }
    }

