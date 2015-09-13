using System;
using System.Collections.Generic;

namespace Persons
{
    class Persons
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>()
            {
                new Person("Pesho", 34),
                new Person("Gosho", 19, "gosho@abv.bg"),
                new Person("Tosho", 25, "tosho@gmail.com"),
            };
            persons.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}