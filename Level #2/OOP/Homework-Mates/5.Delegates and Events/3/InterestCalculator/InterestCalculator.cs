using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace InterestCalculator
{
    class InterestCalculator
    {
        //CultureInfo defaul = CultureInfo.InvariantCulture;

        private decimal money;
        private decimal interest;
        private int years;
        private CalculateInterest type;
        private decimal result;

        public InterestCalculator(decimal money, decimal interest, int years, CalculateInterest type)
        {
            this.Money = money;
            this.Interest = interest;
            this.Years = years;
            this.result = type(money, interest, years);
        }
        public delegate decimal CalculateInterest(decimal money, decimal interest, int years);

        public decimal Money
        {
            get { return this.money; }
            set { this.money = value; }
        }

        public decimal Interest
        {
            get { return this.interest; }
            set
            {
                if (value < 0)
                {
                    throw new FormatException("Interest cannot be negative");
                }
                this.interest = value;
            }
        }

        public int Years
        {
            get { return this.years; }
            set
            {
                if (value < 0)
                {
                    throw new FormatException("Years cannot be negative");
                }
                this.years = value;
            }
        }

        public CalculateInterest Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public decimal Result
        {
            get { return this.result; }
            private set { this.result = value; }
        }
        public static decimal GetSimpleInterest(decimal sum, decimal interest, int years)
        {
            decimal res = sum * (1 + (interest * years / 100));
            return res;

        }

        public static decimal GetCompoundInterest(decimal sum, decimal interest, int years)
        {
            decimal res = sum * (decimal)Math.Pow((double)1 + (double)(interest / 12 / 100), years * 12);
            return res;
        }
    }
}
