using System;

namespace _01.Customer
{
    class Payment
    {
        public string productName;
        public decimal productPrice;

        public Payment(string productName, decimal productPrice)
        {
            this.ProductPrice = productPrice;
            this.ProductName = productName;
        }

        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        public object Clone()
        {
            Payment newPayment = this.MemberwiseClone() as Payment;
            if (null == newPayment)
            {
                throw new ArgumentNullException("Cloned object can not be casted to type Payment!");
            }

            return newPayment;
        }

        public override string ToString()
        {
            return string.Format("[{0} - {1}]", this.ProductName, this.ProductPrice);
        }
    }
}
