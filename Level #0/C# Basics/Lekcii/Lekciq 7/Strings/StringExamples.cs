using System;

class StringExamples
{
    static void Main()
    {
        string str = "SoftUni";
        Console.WriteLine(str);
        for (int i = 0; i < str.Length; i++)
        {
            Console.WriteLine("str[{0}] = {1}", i, str[i]);
        }

        Console.WriteLine(str.IndexOf("Uni")); // 9
        Console.WriteLine(str.IndexOf("uni")); // -1 (not found)

        Console.WriteLine(str.Substring(4,2)); // Un

        Console.WriteLine(str.Replace("Soft", "Hard")); // HarUni

        Console.WriteLine(str.ToLower()); // softuni
        Console.WriteLine(str.ToUpper()); // SOFTUNI

        // This will not compile, because strings are immutable
        // str[5] = 'a';

        string firstName = "Steve";
        string lastName = "Jobs";
        int age = 56;
        string nameAndAge = firstName + " " + lastName + " (age: " + age + ")";
        Console.WriteLine(nameAndAge); // Steve Jobs (age: 56)

        string allLangs = "C#, Java; HTML, CSS; PHP, JavaScript; SQL";
        string[] langs = allLangs.Split(new char[] {',', ';', ' '},
            StringSplitOptions.RemoveEmptyEntries);
        foreach (var lang in langs)
        {
            Console.WriteLine(lang);
        }

        Console.WriteLine("Langs = " + string.Join(", ", langs));

        Console.WriteLine("  \n\n Software  University  ".Trim());
    }
}
