namespace Phonebook.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Phone
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string PhoneNumber { get; set; }
    }
}