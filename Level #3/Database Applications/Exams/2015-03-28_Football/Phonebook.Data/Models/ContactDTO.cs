namespace Phonebook.Data.Models
{
    public class ContactDTO
    {
        public string Name { get; set; }

        public string Position { get; set; }

        public string Company { get; set; }

        public string Url { get; set; }

        public string Notes { get; set; }

        public string[] Emails { get; set; }

        public string[] Phones { get; set; } 
    }
}