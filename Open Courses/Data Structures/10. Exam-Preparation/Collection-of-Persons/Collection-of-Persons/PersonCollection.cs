namespace CollectionOfPersons
{
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PersonCollection : IPersonCollection
    {
        private readonly Dictionary<string, Person> personsByEmail = new Dictionary<string, Person>();
        private readonly Dictionary<string, SortedSet<Person>> personsByEmailDomain = new Dictionary<string, SortedSet<Person>>();
        private readonly Dictionary<string, SortedSet<Person>> personsByNameAndTown = new Dictionary<string, SortedSet<Person>>();
        private readonly OrderedDictionary<int, SortedSet<Person>> personsByAge = new OrderedDictionary<int, SortedSet<Person>>();
        private readonly Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personsByTown = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();

        public bool AddPerson(string email, string name, int age, string town)
        {
            if (this.FindPerson(email) != null)
            {
                return false;
            }

            var person = new Person
            {
                Email = email,
                Name = name,
                Age = age,
                Town = town
            };

            var emailDomain = this.ExtractEmailDomain(email);
            this.personsByEmail.Add(email, person);
            this.personsByEmailDomain.AppendValueToKey(emailDomain, person);
            this.personsByNameAndTown.AppendValueToKey(this.CombineNameAndTown(name, town), person);
            this.personsByAge.AppendValueToKey(person.Age, person);
            this.personsByTown.EnsureKeyExists(town);
            this.personsByTown[town].AppendValueToKey(age, person);

            return true;
        }

        public int Count
        {
            get { return this.personsByEmail.Count; }
        }

        public Person FindPerson(string email)
        {
            Person person;
            this.personsByEmail.TryGetValue(email, out person);

            return person;
        }

        public bool DeletePerson(string email)
        {
            var person = this.FindPerson(email);
            if (person == null)
            {
                return false;
            }

            this.personsByEmail.Remove(email);
            var emailDomain = this.ExtractEmailDomain(email);
            this.personsByEmailDomain[emailDomain].Remove(person);
            this.personsByNameAndTown[this.CombineNameAndTown(person.Name, person.Town)].Remove(person);
            this.personsByAge[person.Age].Remove(person);
            this.personsByTown[person.Town][person.Age].Remove(person);

            return true;
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            var persons = this.personsByEmailDomain.GetValuesForKey(emailDomain);

            return persons;
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            var persons = this.personsByNameAndTown.GetValuesForKey(this.CombineNameAndTown(name, town));

            return persons;
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            var personsInRange = this.personsByAge
                .Range(startAge, true, endAge, true)
                .SelectMany(age => age.Value); ;

            return personsInRange;
        }

        public IEnumerable<Person> FindPersons(
            int startAge, int endAge, string town)
        {
            if (!this.personsByTown.ContainsKey(town))
            {
                return new List<Person>();
            }

            var personsInRange = this.personsByTown[town]
                .Range(startAge, true, endAge, true)
                .SelectMany(a => a.Value);

            return personsInRange;
        }

        private string ExtractEmailDomain(string email)
        {
            var emailDomain = email.Substring(email.LastIndexOf('@') + 1, email.Length - email.LastIndexOf('@') - 1);

            return emailDomain;
        }

        private string CombineNameAndTown(string name, string town)
        {
            return name + "_" + town;
        }
    }
}