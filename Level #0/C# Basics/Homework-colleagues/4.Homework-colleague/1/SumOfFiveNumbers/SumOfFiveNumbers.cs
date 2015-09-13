using System;

class SumOfFiveNumbers
{
    static void Main()
    {
        Console.Write("Number one: ");
        double numberOne = double.Parse(Console.ReadLine());
        Console.Write("Number two: ");
        double numberTwo = double.Parse(Console.ReadLine());
        Console.Write("Number three: ");
        double numberThree = double.Parse(Console.ReadLine());
        Console.Write("Number four: ");
        double numberFour = double.Parse(Console.ReadLine());
        Console.Write("Number five: ");
        double numberFive = double.Parse(Console.ReadLine());

        double sum = numberOne + numberTwo + numberThree + numberFour + numberFive;

        Console.WriteLine("{0} + {1} + {2} + {3} + {4} = {5}", numberOne, numberTwo, numberThree, numberFour, numberFive, sum);
    }
}
