namespace Phonebook.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Email
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string EmailAddress { get; set; }
    }
}