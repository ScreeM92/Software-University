using System;

    class BoolExpression
    {
        static void Main()
        {
            Console.Write("Number: ");
            int theNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(theNumber%5==0 && theNumber%7==0 &&theNumber!=0);
        }
    }