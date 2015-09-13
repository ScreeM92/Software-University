using CentaurFactory.Model;
using CentaurFactory.SqlServerProvider.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentaurFactory.SqlServerProvider
{
    public class SqlServerRepository
    {
        private DataContext context;

        public SqlServerRepository(string connectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Config>());

            context = new DataContext(connectionString);
        }

        public void AddProducts(IEnumerable<Product> products)
        {
            foreach (Product product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();
        }

        public void AddIngredients(IEnumerable<Ingredient> ingredients)
        {
            foreach (Ingredient ingredient in ingredients)
            {
                var product = context.Products.First(x => x.Name == ingredient.Product.Name);
                var dish = context.Dishes.FirstOrDefault(x => x.Name == ingredient.Dish.Name);
                if (dish == null)
                {
                    dish = new Dish()
                    {
                        Name = ingredient.Dish.Name,
                        Price = ingredient.Dish.Price
                    };
                }

                context.Ingredients.Add(new Ingredient
                {
                    Dish = dish,
                    Product = product,
                    Quantity = ingredient.Quantity
                });

                context.SaveChanges();
            }
        }
    }
}
