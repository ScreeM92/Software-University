using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentaurFactory.MySqlPRovider
{
    public class DishReport
    {
        public string Month { get; set; }

        public double DeliveredPrice { get; set; }

        public double SoldPrice { get; set; }

        public string Code { get; set; }
    }
}
