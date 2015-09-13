namespace CollectionOfPersons
{
    using System.Collections.Generic;
    using System.Linq;

    public class PersonCollectionSlow : IPersonCollection
    {
        private readonly IList<Person> persons = new List<Person>();

        public int Count
        {
            get { return this.persons.Count; }
        }

        public bool AddPerson(string email, string name, int age, string town)
        {
            if (this.persons.Any(p => p.Email == email))
            {
                return false;
            }

            this.persons.Add(new Person
            {
                Email = email,
                Name = name,
                Age = age,
                Town = town
            });

            return true;
        }

        public Person FindPerson(string email)
        {
            var person = this.persons.FirstOrDefault(p => p.Email == email);

            return person;
        }

        public bool DeletePerson(string email)
        {
            if (this.persons.All(p => p.Email != email))
            {
                return false;
            }

            this.persons.Remove(this.FindPerson(email));

            return true;
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            return this.persons
                .Where(p => p.Email.Substring(p.Email.LastIndexOf('@') + 1, p.Email.Length - p.Email.LastIndexOf('@') - 1) == emailDomain)
                .OrderBy(p => p.Email)
                .ToList();
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            return this.persons
                .Where(p => p.Name == name && p.Town == town)
                .OrderBy(p => p.Email)
                .ToList();
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            return this.persons
                .Where(p => p.Age >= startAge && p.Age <= endAge)
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Email)
                .ToList();
        }

        public IEnumerable<Person> FindPersons(
            int startAge, int endAge, string town)
        {
            return this.persons
                .Where(p => p.Age >= startAge && p.Age <= endAge && p.Town == town)
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Email)
                .ToList();
        }
    }
}