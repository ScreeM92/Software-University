using System;
using System.Linq;

class DefiningAndUsingClasses
{
    static void Main()
    {
        Person[] people = new Person[]
        {
            new Person() { FirstName = "Larry", LastName = "Page", Age = 40},
            new Person() { FirstName = "Steve", LastName = "Jobs", Age = 56},
            new Person() { FirstName = "Bill", LastName = "Gates", Age = 58},
            new Person() { FirstName = "Larry", LastName = "Ellison", Age = 69},
            new Person() { FirstName = "Mark", LastName = "Zuckerberg", Age = 29},
            new Person() { FirstName = "Svetlin", LastName = "Nakov", Age = 25},
        };

        // Print all persons who are younger than 50
        Console.WriteLine("Young people: ");
        foreach (var p in people)
        {
            if (p.Age < 50)
            {
                Console.WriteLine("{0} {1} (age: {2})", p.FirstName, p.LastName, p.Age);
            }
        }

        // Print all persons who are younger than 50 (functional style)
        Console.WriteLine("\nYoung people (again): ");

        var youngPeople = people.Where(p => p.Age < 50);
        foreach (var p in youngPeople)
        {
            Console.WriteLine("{0} {1} (age: {2})", p.FirstName, p.LastName, p.Age);
        }
    }
}
