using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentaurFactory.ExcelModel
{
    public class MonthProfit
    {
        public string Month { get; set; }

        public double Income { get; set; }

        public double  Outcome { get; set; }

        public double Profit
        {
            get
            {
                return this.Income - this.Outcome;
            }
        }
    }
}
