using System;

class TestClass
{
    static void Main(string[] args)
    {   
        PrintNumber();
        PrintDateTime();
    }
    
    static void PrintNumber()
    {
        int min = 0;
        int max = 100;
        
        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());
       
        if (number < min || number > max)
        {
            throw new InvalidRangeException<int>(min, max);
        }
            Console.WriteLine("Entered number = {0}", number);
    }
    
    static void PrintDateTime()
    {   
        DateTime min = new DateTime(1945, 4, 8);
        DateTime max = new DateTime(2013, 7, 5);
        
        Console.Write("Enter date: ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        
        if (date < min || date > max)
        {
            throw new InvalidRangeException<DateTime>(min, max);
        }
        
        Console.WriteLine("Entered date = {0}", date);
        
    }
    
}
