namespace ProductsInPricerange
{
    using System;

    public class Product : IComparable<Product>
    {
        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public int CompareTo(Product obj)
        {
            return this.Price.CompareTo(obj.Price);
        }

        public override string ToString()
        {
            var product = string.Format("{0:N2} {1}", this.Price, this.Name);

            return product;
        }
    }
}