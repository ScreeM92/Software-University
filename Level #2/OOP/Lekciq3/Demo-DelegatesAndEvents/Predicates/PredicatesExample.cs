using System;
using System.Collections.Generic;

class PredicatesExample
{
    static void Main()
    {
        List<string> towns = new List<string>() 
        { 
            "Sofia", "Burgas", "Plovdiv", "Varna", "Ruse", "Stara Zagora", "Silistra" 
        };

        // Filter by annonymous method (long syntax)
        List<string> townsWithS = towns.FindAll(delegate(string town)
        {
            return town.StartsWith("S");
        });

        foreach (string town in townsWithS)
        {
            Console.WriteLine(town);
        }

        Console.WriteLine();

        // Filter by lambda expression (short syntax)
        townsWithS = towns.FindAll(town => town.StartsWith("S"));
        townsWithS.ForEach((town) => { Console.WriteLine(town); });
    }
}
