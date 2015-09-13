using System;
    class Program
    {
        static void Main()
        {
            long n1 = long.Parse(Console.ReadLine());
            long n2 = long.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            long sum = 0;

            Console.Write(n1 + " " + n2 + " ");

            for (int row = 0; row < k - 2; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    if (true)
                    {
                        sum = n1 + n2;
                        Console.Write(sum + " ");
                        n1 = n2;
                        n2 = sum; 
                    }
                    else
                    {

                    }
                    
                }
            }
        }
    }

