using System;
using System.Linq;

class ArrayOfStrings
{
    static void Main()
    {
        string[] names = { "Peter", "Maria", "Katya", "Todor" };

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine();

        names[0] = names[0] + " (junior)";

        foreach (var name in names.Reverse())
        {
            Console.WriteLine(name);
        }

        names[4] = "Nakov"; // This will cause an exception!
    }
}
