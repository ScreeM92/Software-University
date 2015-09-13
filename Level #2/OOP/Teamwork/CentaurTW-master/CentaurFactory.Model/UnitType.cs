using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentaurFactory.Model
{
    public class UnitType
    {
        public UnitType()
        {
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string ToString()
        {
            return "Unit name: " + this.Name;
        }

        public virtual ICollection<Product> Products { get; set; }
    }
}
