namespace Phonebook
{
    using System;
    using System.Text;
    using Dictionary;

    public class Phonebook
    {
        public static void Main()
        {
            var phonebook = new Dictionary<string, string>();

            ParseContactsData(phonebook);

            var queriesResult = ProceessSearchQueries(phonebook);
            
            Console.WriteLine(new string('-', 70));
            Console.WriteLine(queriesResult);
        }

        private static void ParseContactsData(Dictionary<string, string> phonebook)
        {
            var contactData = Console.ReadLine();

            while (!string.IsNullOrEmpty(contactData) && contactData != "search")
            {
                var rowData = contactData.Split('-');
                phonebook.AddOrReplace(rowData[0], rowData[1]);

                contactData = Console.ReadLine();
            }
        }

        private static string ProceessSearchQueries(Dictionary<string, string> phonebook)
        {
            var contactName = Console.ReadLine();
            var queriesResult = new StringBuilder();

            while (!string.IsNullOrEmpty(contactName))
            {
                var contact = phonebook.Find(contactName);
                queriesResult.AppendLine(contact != null
                    ? string.Format("{0} -> {1}", contact.Key, contact.Value)
                    : string.Format("Contact {0} does not exist.", contactName));

                contactName = Console.ReadLine();
            }

            return queriesResult.ToString();
        }
    }
}