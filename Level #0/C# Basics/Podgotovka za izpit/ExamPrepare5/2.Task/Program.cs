using System;
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            int counter = 0;
            foreach (var letter in text)
            {
                counter+= 2;
            }
        }
    }

