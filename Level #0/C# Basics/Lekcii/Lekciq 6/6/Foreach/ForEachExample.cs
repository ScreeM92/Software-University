using System;

class ForEachExample
{
    static void Main()
    {
        string[] days = new string[] { 
            "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" 
        };
        foreach (var day in days)
        {
            Console.WriteLine(day);
        }
    }
}
