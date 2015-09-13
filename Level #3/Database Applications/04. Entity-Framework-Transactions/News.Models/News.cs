using System.ComponentModel.DataAnnotations;

namespace NewsDb.Models
{
    public class News
    {
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string Content { get; set; }
    }
}