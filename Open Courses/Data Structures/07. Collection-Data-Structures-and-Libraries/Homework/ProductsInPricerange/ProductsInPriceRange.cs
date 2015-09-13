namespace ProductsInPricerange
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class ProductsInPriceRange
    {
        private static OrderedMultiDictionary<double, Product> bag;
        private static BigList<Product> products;
        private static Random rnd;

        public static void Main()
        {
            Console.Write("Enter products count: ");
            var productsCount = int.Parse(Console.ReadLine());
            Console.Write("Enter products min price: ");
            var minPrice = double.Parse(Console.ReadLine());
            Console.Write("Enter products max price: ");
            var maxPrice = double.Parse(Console.ReadLine());
            Console.Write("Enter subrange lower limit: ");
            var lowerLimit = double.Parse(Console.ReadLine());
            Console.Write("Enter subrange upper limit: ");
            var upperLimit = double.Parse(Console.ReadLine());

            bag = new OrderedMultiDictionary<double, Product>(true);
            products = new BigList<Product>();
            rnd = new Random();

            FillBag(productsCount, minPrice, maxPrice);
            //FillBag(10000);

            var subrange = bag.Range(lowerLimit, true, upperLimit, true).Take(20);
            FindFirstNthProduct(subrange);
            PrintResult();
        }

        private static void FindFirstNthProduct(IEnumerable<KeyValuePair<double, ICollection<Product>>> subrange)
        {
            foreach (var keyValuePair in subrange)
            {
                if (products.Count >= 20)
                {
                    break;
                }

                foreach (var product in keyValuePair.Value)
                {
                    products.Add(product);
                }
            }
        }

        private static void FillBag(int bagSize, double minPrice, double maxPrice)
        {
            for (int i = 0; i < bagSize; i++)
            {
                var price = rnd.NextDouble() * (maxPrice - minPrice) + minPrice;
                var product = new Product("product" + i, price);
                bag.Add(product.Price, product);
            }
        }

        private static void PrintResult()
        {
            products.ForEach(Console.WriteLine);
        }
    }
}