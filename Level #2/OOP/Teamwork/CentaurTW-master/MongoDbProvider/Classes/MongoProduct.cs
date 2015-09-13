namespace CentaurFactory.MongoDbProvider
{
    using CentaurFactory.Model;
    using MongoDB.Bson;

    internal class MongoProduct
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public MongoProductType ProductType { get; set; }

        public MongoUnitType UnitType { get; set; }

        public int Quantity { get; set; }

        public MongoProduct(string productName, int quantity, MongoUnitType unitType, MongoProductType productType)
        {
            this.Id = ObjectId.GenerateNewId();
            this.UnitType = unitType;
            this.ProductType = productType;
            this.Name = productName;
            this.Quantity = quantity;
        }
    }
}
