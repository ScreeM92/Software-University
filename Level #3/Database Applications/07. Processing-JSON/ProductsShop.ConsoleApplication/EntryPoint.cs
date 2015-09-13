namespace ProductsShop.ConsoleApplication
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class EntryPoint
    {
        private const string ExportPath = @"..\..\..\Export\";

        public static void Main()
        {
            if (!Directory.Exists(ExportPath))
            {
                Directory.CreateDirectory(ExportPath);
            }

            var context = new ProductsShopContext();

            ProductsInPriceRange(context, 500, 1000);
            SuccessfullySoldProducts(context);
            GetAllCategories(context);
            UsersAndProducts(context);
        }

        private static void ProductsInPriceRange(ProductsShopContext context, decimal lowerLimit, decimal upperLimit)
        {
            const string path = ExportPath + "products_in_range.json";
            var products = context.Products
                .Where(p => p.Price >= lowerLimit && p.Price <= upperLimit && p.Buyer == null)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = (p.Seller.FirstName != null ? p.Seller.FirstName + " " : "") + p.Seller.LastName
                });

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(path, json);

            Console.WriteLine("Products in range file path:\n {0}\n", Path.GetFullPath(path));
        }

        private static void SuccessfullySoldProducts(ProductsShopContext context)
        {
            const string path = ExportPath + "sold_products.json";

            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName ?? string.Empty,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold.Where(p => p.Buyer != null).Select(p => new
                        {
                            name = p.Name ?? string.Empty,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                });

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
            
            File.WriteAllText(path, json);

            Console.WriteLine("Successfully Sold Products file path:\n {0}\n", Path.GetFullPath(path));
        }

        private static void GetAllCategories(ProductsShopContext context)
        {
            const string path = ExportPath + "categories_by_products_count.json";

            var categories = context.Categories
                .OrderByDescending(c => c.Products.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.Products.Count,
                    averagePrice = c.Products.Average(p => p.Price),
                    totalRevenue = c.Products.Sum(p => p.Price)
                });

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            File.WriteAllText(path, json);

            Console.WriteLine("Categories By Products Count file path:\n {0}\n", Path.GetFullPath(path));
        }

        private static void UsersAndProducts(ProductsShopContext context)
        {
            const string path = ExportPath + "users_and_products.xml";

            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count)
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    soldProducts = u.ProductsSold.Where(p => p.Buyer != null).Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                }).ToList();
            
            var doc = new XDocument();
            var rootNode = new XElement("users");
            rootNode.SetAttributeValue("count", users.Count);

            foreach (var user in users)
            {
                var userNode = new XElement("user");
                if (user.FirstName != null)
                {
                    userNode.SetAttributeValue("first-name", user.FirstName);
                }

                userNode.SetAttributeValue("last-name", user.LastName);

                if (user.Age != null)
                {
                    userNode.SetAttributeValue("age", user.Age);
                }

                var soldProductsNode = new XElement("sold-products");
                soldProductsNode.SetAttributeValue("count", user.soldProducts.Count());

                foreach (var product in user.soldProducts)
                {
                    var productNode = new XElement("product");
                    productNode.SetAttributeValue("name", product.Name);
                    productNode.SetAttributeValue("price", product.Price);
                    soldProductsNode.Add(productNode);
                }

                userNode.Add(soldProductsNode);
                rootNode.Add(userNode);
            }

            doc.Add(rootNode);
            doc.Save(path);

            Console.WriteLine("Users And Products file path:\n {0}\n", Path.GetFullPath(path));
        }
    }
}
