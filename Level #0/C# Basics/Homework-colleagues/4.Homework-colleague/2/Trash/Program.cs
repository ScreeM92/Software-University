using System;

class Program
{
    static void Main()
    {
        //
        // Remove the second character from the string.
        // This character has the index of 1.
        //
        const string value1 = "Dot Net Perls";
        string result1 = value1.Remove(0, 1);

        //
        // Find and remove the first uppercase A from the string.
        // This character can occur at any index.
        //
        const string value2 = "Sam Allen";
        string result2 = value2;
        int index1 = value2.IndexOf('A');
        if (index1 != -1)
        {
            result2 = value2.Remove(index1, 1); // Use integer from IndexOf.
        }

        //
        // Output of the program.
        //
        Console.WriteLine(result1);
        Console.WriteLine(result2);
    }
}