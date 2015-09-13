using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentaurFactory.Model
{
    public class Ingredient
    {
        public int Id { get; set; }

        public Dish Dish { get; set; }

        public Product Product { get; set; }

        public double Quantity { get; set; }
    }
}
