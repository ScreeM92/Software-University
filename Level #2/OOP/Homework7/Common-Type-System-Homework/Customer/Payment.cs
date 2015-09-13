using System;

    class Payment
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public Payment(string productname, decimal price)
        {
            this.ProductName = productname;
            this.Price = price;
        }

        public override string ToString()
        {
            return string.Format("Product name: {0} \n\r Price: {1}", this.ProductName, this.Price);
        }
    }

