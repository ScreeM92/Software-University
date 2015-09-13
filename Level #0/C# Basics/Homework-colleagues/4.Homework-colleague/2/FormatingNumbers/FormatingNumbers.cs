using System;

class FormatingNumbers
    {
        static void Main()
        {
            Console.Write("Enter an integer: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter a number: ");
            decimal b = decimal.Parse(Console.ReadLine());
            Console.Write("Enter a number: ");
            decimal c = decimal.Parse(Console.ReadLine());
            Console.WriteLine("\n|{0,-10:X}|{1}|{2,10:0.00}|{3,-10:0.000}|", a, Convert.ToString(a, 2).PadLeft(10, '0'), b, c);
        }
    }