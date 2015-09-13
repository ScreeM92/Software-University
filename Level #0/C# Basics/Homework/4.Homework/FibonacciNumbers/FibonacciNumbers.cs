using System;
    class FibonacciNumbers
    {
        static void Main()
        {
            Console.WriteLine("Insert a number n:");
            int num = int.Parse(Console.ReadLine());
            int fibonacciNum;
            int startNum = 0;
            int secondNum = 1;
            if (num == 1)
            {
                Console.WriteLine(0);
            }
            else if (num == 0)
            {
                Console.WriteLine("Thete is no sequence.");
            }
            else
            {
                Console.Write(0 + " " + 1 + " ");
                for (int i = 0; i < num - 2; i++)
                {
                    fibonacciNum = startNum + secondNum;
                    Console.Write(fibonacciNum + " ");
                    startNum = secondNum;
                    secondNum = fibonacciNum;
                }
            }
        }
    }
