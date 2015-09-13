using System;
using System.Collections.Generic;
using System.Linq;

class AnimalsMainClass
{
    static void Main()
    {
        var animals = new Animal[]
        {
            new Dog("Sharo", 5),
            new Frog("Frogy", 10),
            new Cat("Masha", 11),
            new TomCat("Tom", 2, Gender.Male),
            new Kitten("Kitty", 3, Gender.Female)
        };

        animals.ToList().ForEach(Console.WriteLine);
        //var animalsBygroups = animals.GroupBy(GetAnimalKind,
        //    (g, a) => new { kind = g, averagAge = a.Average(animal => animal.Age) });
        var animalsBygroups = animals.GroupBy(GetAnimalKind,
            (g, a) => new { kind = g, averagAge = a.Average(animal => animal.Age) });

        foreach (var animalGroup in animalsBygroups)
        {
            Console.WriteLine("The average age of {0}s is {1:f2}.", animalGroup.kind, animalGroup.averagAge);
        }
    }

        public static string GetAnimalKind(Animal animal)
        {
            string kind = "";

            if(animal.GetType().BaseType.Name == "Animal")
            {
                kind = animal.GetType().Name;
            }
            else
            {
                kind = animal.GetType().BaseType.Name;          
            }
            return kind;
        } 
}