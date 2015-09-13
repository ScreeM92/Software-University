using CentaurFactory.Model;

namespace CentaurFactory.MongoDbProvider
{
    internal class MongoProductType
    {
        private static int ID = 0;

        public int Id { get; set; }

        public string Name { get; set; }

        public MongoProductType(string productTypeName)
        {
            ID++;
            this.Id = ID;
            this.Name = productTypeName;
        }
    }
}
