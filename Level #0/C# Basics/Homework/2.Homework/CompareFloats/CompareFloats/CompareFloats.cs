using System;

class CompareFloats
{
    /*Write a program that safely compares floating-point numbers with precision eps = 0.000001. Note that we cannot directly
* compare two floating-point numbers a and b by a==b because of the nature of the floating-point arithmetic. Therefore, we
* assume two numbers are equal if they are more closely to each other than a fixed constant eps.*/
    static void Main()
    {
        Console.WriteLine("Enter the first number");
        double FirstNumber = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the second number");
        double SecondNumber = double.Parse(Console.ReadLine());
        bool compare = (Math.Abs(FirstNumber - SecondNumber) < 0.000001);
        Console.WriteLine();
        if (compare)
        {
            Console.WriteLine((compare) + ": Numbers are equal with a precision of 0.000001.");
        }
        else 
        {
            Console.WriteLine((compare) + ": Numbers are not equal with a precision of 0.000001.");
        }

    }
}

