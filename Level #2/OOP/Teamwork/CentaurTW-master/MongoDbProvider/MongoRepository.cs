using CentaurFactory.Model;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentaurFactory.MongoDbProvider
{
    public class MongoRepository
    {
        private MongoProvider provider;

        public MongoRepository(MongoProvider provider)
        {
            this.provider = provider;
        }

        public IList<Product> GetProducts() 
        {
            IList<MongoProduct> productsDb = provider.LoadData<MongoProduct>();
            IList<Product> result = new List<Product>();
            foreach (MongoProduct product in productsDb)
            {
                result.Add(new Product
                {
                    Name = product.Name,
                    ProductType = new ProductType
                    {
                        Name = product.ProductType.Name
                    },
                    UnitType = new UnitType
                    {
                        Name = product.UnitType.Name
                    },
                    Quantity = product.Quantity
                });
            }

            return result;
        }

        public IList<Ingredient> GetIngredients()
        {
            IList<MongoIngredient> ingredientsDb = provider.LoadData<MongoIngredient>();
            IList<Ingredient> result = new List<Ingredient>();
            foreach (MongoIngredient ingredient in ingredientsDb)
            {
                result.Add(new Ingredient
                {
                    Dish = new Dish()
                    {
                        Name = ingredient.Dish.Name,
                        Price = ingredient.Dish.Price
                    },
                    Product = new Product
                    {
                        Name = ingredient.Product.Name
                    },
                    Quantity = ingredient.Quantity
                });
            }

            return result;
        }

        public IList<UnitType> GetUntTypes()
        {
            IList<MongoUnitType> unitTypesDb = provider.LoadData<MongoUnitType>();
            IList<UnitType> result = new List<UnitType>();
            foreach (MongoUnitType unitType in unitTypesDb)
            {
                result.Add(new UnitType
                {
                    Name = unitType.Name
                });
            }

            return result;
        }

        public IList<ProductType> GetProductTypes()
        {
            IList<MongoProductType> productTypesDb = provider.LoadData<MongoProductType>();
            IList<ProductType> result = new List<ProductType>();
            foreach (MongoProductType productType in productTypesDb)
            {
                result.Add(new ProductType
                {
                    Name = productType.Name
                });
            }

            return result;
        }

        public void InitData()
        {
            var unitTypes = new List<UnitType>()
            {
                new UnitType 
                {
                    Name = "Kilogramme"
                },
                new UnitType 
                {
                    Name = "Litre"
                },
                new UnitType 
                {
                    Name = "Number"
                }
            };

            var productTypes = new List<ProductType>()
            {
                new ProductType 
                {
                    Name = "Fruit"
                },
                new ProductType 
                {
                    Name = "Vegetable"
                },
                new ProductType 
                {
                    Name = "Dairy"
                },
                new ProductType 
                {
                    Name = "Meat"
                }
            };

            var products = new List<Product>()
            { 
               new Product 
               {
                   Name = "Tomatoe",
                   ProductType = productTypes[1],
                   UnitType = unitTypes[0],
                   Quantity = 250
               },
               new Product 
               {
                   Name = "Cucumber",
                   ProductType = productTypes[1],
                   UnitType = unitTypes[0],
                   Quantity = 120
               },
               new Product 
               {
                   Name = "Onion",
                   ProductType = productTypes[1],
                   UnitType = unitTypes[0],
                   Quantity = 120
               },
               new Product 
               {
                   Name = "WhiteCheese",
                   ProductType = productTypes[3],
                   UnitType = unitTypes[0],
                   Quantity = 40
               }
            };

            var dishes = new List<Dish>()
            {
                new Dish() 
                {
                    Name = "Shopska Salata",
                    Price = 3.1,
                }
            };

            var ingredients = new List<Ingredient>()
            {
                new Ingredient()
                {
                    Dish = dishes[0],
                    Product = products[0],
                    Quantity = 0.2
                },
                new Ingredient()
                {
                    Dish = dishes[0],
                    Product = products[1],
                    Quantity = 0.2
                },
                new Ingredient()
                {
                    Dish = dishes[0],
                    Product = products[2],
                    Quantity = 0.2
                },
                new Ingredient()
                {
                    Dish = dishes[0],
                    Product = products[3],
                    Quantity = 0.2
                }
            };

            this.SaveUnitType(unitTypes[0]);
            this.SaveUnitType(unitTypes[1]);
            this.SaveUnitType(unitTypes[2]);

            this.SaveProductType(productTypes[0]);
            this.SaveProductType(productTypes[1]);
            this.SaveProductType(productTypes[2]);
            this.SaveProductType(productTypes[3]);

            this.SaveProduct(products[0]);
            this.SaveProduct(products[1]);
            this.SaveProduct(products[2]);
            this.SaveProduct(products[3]);

            this.SaveDish(dishes[0]);

            this.SaveIngredient(ingredients[0]);
            this.SaveIngredient(ingredients[1]);
            this.SaveIngredient(ingredients[2]);
            this.SaveIngredient(ingredients[3]);
        }

        public void EreaseData()
        {
            provider.DeleteAll<MongoProduct>();
            provider.DeleteAll<MongoProductType>();
            provider.DeleteAll<MongoUnitType>();
            provider.DeleteAll<MongoDish>();
            provider.DeleteAll<MongoIngredient>();
        }

        private void SaveProduct(Product product)
        {
            var query = Query.EQ("Name", product.ProductType.Name);
            MongoProductType type = provider.Find<MongoProductType>(query);

            query = Query.EQ("Name", product.UnitType.Name);
            MongoUnitType unitType = provider.Find<MongoUnitType>(query);

            provider.SaveData(new MongoProduct(product.Name, product.Quantity, unitType, type));
        }

        private void SaveUnitType(UnitType unitType)
        {
            provider.SaveData(new MongoUnitType(unitType.Name));
        }

        private void SaveProductType(ProductType productType)
        {
            provider.SaveData(new MongoProductType(productType.Name));
        }

        private void SaveDish(Dish dish)
        {
            provider.SaveData(new MongoDish(dish.Name, dish.Price));
        }

        private void SaveIngredient(Ingredient ingredient)
        {
            var query = Query.EQ("Name", ingredient.Dish.Name);
            MongoDish dish = provider.Find<MongoDish>(query);

            query = Query.EQ("Name", ingredient.Product.Name);
            MongoProduct product = provider.Find<MongoProduct>(query);

            provider.SaveData(new MongoIngredient(dish, product, ingredient.Quantity));
        }
    }
}
