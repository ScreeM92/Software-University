namespace ProductsShop.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Newtonsoft.Json;
    using ProducstShop.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsShop.Data.ProductsShopContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "ProductsShop.Data.ProductsShopContext";
        }

        protected override void Seed(ProductsShop.Data.ProductsShopContext context)
        {
            const string usersPath = @"..\..\..\Import\users.xml";
            const string productsPath = @"..\..\..\Import\products.json";
            const string categoriesPath = @"..\..\..\Import\categories.json";

            if (context.Users.Any())
            {
                return;
                
            }

            SeedUsers(context, usersPath);
            context.SaveChanges();

            SeedProducts(context, productsPath);
            context.SaveChanges();

            SeedCategories(context, categoriesPath);
            context.SaveChanges();

            SeedProductsCategories(context);
            context.SaveChanges();
        }

        private static void SeedUsers(ProductsShopContext context, string path)
        {
            var doc = XDocument.Load(path);

            doc.Descendants("user")
                .Select(u => new User
                {
                    FirstName = u.Attribute("first-name") != null ? u.Attribute("first-name").Value : null,
                    LastName = u.Attribute("last-name").Value,
                    Age = u.Attribute("age") != null ? int.Parse(u.Attribute("age").Value) : (int?)null
                })
                .ToList()
                .ForEach(u => context.Users.Add(u));
        }

        private static void SeedProducts(ProductsShopContext context, string productsPath)
        {
            var usersIds = context.Users.Select(u => u.Id).ToList();

            var rnd = new Random();
            var products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(productsPath));

            int i = 0;

            foreach (var item in products)
            {
                item.SellerId = usersIds[rnd.Next(0, usersIds.Count)];
                var buyerId = usersIds[rnd.Next(0, usersIds.Count)];

                if (i % 4 != 0 && item.SellerId != buyerId)
                {
                    item.BuyerId = buyerId;
                }

                i++;
            }

            products.ForEach(p => context.Products.Add(p));
        }

        private static void SeedCategories(ProductsShopContext context, string categoriesPath)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(File.ReadAllText(categoriesPath));

            categories.ForEach(c => context.Categories.Add(c));
        }

        private static void SeedProductsCategories(ProductsShopContext context)
        {
            var products = context.Products;
            var rnd = new Random();

            foreach (var product in products)
            {
                var categoriesIds = context.Categories.Select(c => c.Id).ToList();
                var iterations = rnd.Next(1, int.Parse((categoriesIds.Count / 2).ToString()));

                for (int i = 0; i < iterations; i++)
                {
                    var categoryId = categoriesIds.ElementAt(rnd.Next(0, categoriesIds.Count));
                    var category = context.Categories.First(c => c.Id == categoryId);
                    product.Categories.Add(category);
                    categoriesIds.Remove(categoryId);
                }
            }

            context.SaveChanges();
        }
    }
}