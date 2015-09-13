using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentaurFactory.Model
{
    public class Product
    {
        public Product()
        {
            this.Ingredients = new HashSet<Ingredient>();
        }

        public int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ProductType ProductType { get; set; }

        public virtual UnitType UnitType { get; set; }

        public virtual int Quantity { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }

        public virtual string ToString()
        {
            return "Product: " + this.Name;
        }
    }
}
