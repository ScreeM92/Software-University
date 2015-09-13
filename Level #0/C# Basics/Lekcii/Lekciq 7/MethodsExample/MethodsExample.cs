using System;

class MethodsExample
{
    static void Main()
    {
        for (int i = 1; i <= 10; i++)
        {
            PrintHyphens(i);
        }
    }

    static void PrintHyphens(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write('-');
        }
        Console.WriteLine();
    }

}
