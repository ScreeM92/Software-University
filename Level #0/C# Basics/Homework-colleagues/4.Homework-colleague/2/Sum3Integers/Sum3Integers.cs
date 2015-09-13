using System;

class Sum3Integers
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter an integer: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Enter an integer: ");
        int c = int.Parse(Console.ReadLine());
        int sum = a + b + c;
        Console.WriteLine("The sum of the integers is: {0}", sum);
    }
}
// I know the example says 5.5 + 4.5 + 20.1 but I decided to write the application with integers as is required in the description