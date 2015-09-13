namespace ProducstShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public Product()
        {
            this.Categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int SellerId { get; set; }

        //[ForeignKey("SellerId")]
        public virtual User Seller { get; set; }

        public int? BuyerId { get; set; }

        //[ForeignKey("BuyerId")]
        public virtual User Buyer { get; set; }

        public virtual ICollection<Category> Categories { get; set; }


    }
}