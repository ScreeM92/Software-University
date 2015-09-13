using System;
using System.Linq;
using System.Collections.Generic;

    class Test
    {
        static void Main()
        {
            IList<Animals> animals = new List<Animals>()
            {
                new Cat("Masha", 3, Gender.female),
                new Dog("Doncho", 15, Gender.male),
                new Frog("Froggy", 4, Gender.female),
                new Kitten("Kitty", 1),
                new Tomcat("Tom", 333)
            };

            //animals.Average(s => s.Age).ToString().ToList().ForEach(s => Console.Write(s.ToString()));

            var animalsAverageAge =
                from animal in animals
                group animal by (animal is Cat) ? typeof(Cat) : animal.GetType() into g
                select new { GroupName = g.Key, AverageAge = g.ToList().Average(av => av.Age) };

            foreach (var animal in animalsAverageAge)
            {
                Console.WriteLine("{0} - average age: {1:N2}", animal.GroupName.Name, animal.AverageAge);
            }
        }
    }

