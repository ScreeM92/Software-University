using System;
    class Program
    {
        static void Main()
        {
            string str = Console.ReadLine();
            int num;
            bool correct = int.TryParse(str, out num);
            Console.WriteLine(correct ? "The number is " + num*2 : "Invalid number");
        }
    }

