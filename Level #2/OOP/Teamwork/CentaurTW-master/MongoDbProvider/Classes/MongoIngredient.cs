using MongoDB.Bson;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentaurFactory.MongoDbProvider
{
    internal class MongoIngredient
    {
        public ObjectId Id { get; set; }

        public MongoDish Dish { get; set; }

        public MongoProduct Product { get; set; }

        public double Quantity { get; set; }

        public MongoIngredient(MongoDish dish, MongoProduct product, double quantity)
        {
            this.Id = ObjectId.GenerateNewId();
            this.Dish = dish;
            this.Product = product;
            this.Quantity = quantity;
        }
    }
}
