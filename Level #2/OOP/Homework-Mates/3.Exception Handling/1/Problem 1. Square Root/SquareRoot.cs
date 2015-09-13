using System;

class SquareRoot
{
    static void Main()
    {
        Console.Write("Enter Integer Number: ");
        try
        {
            int input = int.Parse(Console.ReadLine());
            if (input <0)
	        {
                throw new ArgumentOutOfRangeException();
	        }
            Console.WriteLine("The Square root of {0} is {1}", input, Math.Sqrt(input));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Invalid Number\n" + ex.Message);
            //throw;
        }
        finally { Console.WriteLine("Good bye"); }
    }
}
