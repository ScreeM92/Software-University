using System;

    class NumberComparer
    {
        static void Main()
        {
            Console.Write("Enter a number: ");
            decimal a = decimal.Parse(Console.ReadLine());
            Console.Write("Enter a number: ");
            decimal b = decimal.Parse(Console.ReadLine());
            decimal greater = a - b;
            Console.WriteLine("The greater is: " + (greater > 0 ? a : b));
        }
    }