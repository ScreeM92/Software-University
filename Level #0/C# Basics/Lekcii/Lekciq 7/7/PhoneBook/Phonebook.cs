using System;
using System.Collections.Generic;
using System.Linq;

class Phonebook
{
    static void Main()
    {
        // Create a phone book: a set of pairs of (person name -> phone name)
        Dictionary<string, string> phonebook = new Dictionary<string, string>();

        // Add a few entries in the phonebook
        phonebook["John Smith"] = "+1-555-8976";
        phonebook["Lisa Smith"] = "+1-555-1234";
        phonebook["Sam Doe"] = "+1-555-5030";
        phonebook["Nakov"] = "+359-899-555-592";

        // Print the phonebook
        foreach (var entry in phonebook)
        {
            Console.WriteLine("{0} has phone number {1}", entry.Key, entry.Value);
        }

        // Modify Nakov's number
        phonebook["Nakov"] = "+359-2-981-9819";

        // Delete an existing number
        phonebook.Remove("John Smith");

        Console.WriteLine();

        // Print the phonebook (another way)
        foreach (var name in phonebook.Keys)
        {
            Console.WriteLine("{0} --> {1}", name, phonebook[name]);
        }
    }
}
