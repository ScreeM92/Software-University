using CentaurFactory.Model;

namespace CentaurFactory.MongoDbProvider
{
    internal class MongoUnitType
    {
        private static int ID = 0;

        public int Id { get; set; }

        public string Name { get; set; }

        public MongoUnitType(string unitName)
        {
            ID++;
            this.Id = ID;
            this.Name = unitName;
        }
        
    }
}
