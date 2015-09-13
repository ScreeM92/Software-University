namespace Phonebook.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using Models;
    using Newtonsoft.Json;

    class PhonebookMain
    {
        private const string ImportFilePath = @"..\..\..\Import\contacts.json";

        public static void Main()
        {
            var context = new PhonebookEntities();
            var parsedContacts = JsonConvert.DeserializeObject<IList<ContactDTO>>(File.ReadAllText(@"..\..\..\Import\contacts.json"));
            
            
        }
    }
}