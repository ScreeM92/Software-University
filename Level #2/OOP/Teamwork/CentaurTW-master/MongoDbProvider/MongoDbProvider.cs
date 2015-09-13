using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentaurFactory.MongoDbProvider
{
    public class MongoProvider
    {
        private MongoClient mongoClient;
        private MongoServer mongoServer;
        private MongoDatabase dataBase;

        public MongoProvider(string connectionString, string dataBaseName)
        {
            mongoClient = new MongoClient(connectionString);
            mongoServer = mongoClient.GetServer();
            dataBase = mongoServer.GetDatabase(dataBaseName);
        }

        public void SaveData<T>(T value)
        {
            var result = dataBase.GetCollection<T>(typeof(T).Name).Save(value);
        }

        public IList<T> LoadData<T>()
        {
            return dataBase.GetCollection<T>(typeof(T).Name).AsQueryable().ToList();
        }

        public void DeleteAll<T>()
        {
            dataBase.GetCollection<T>(typeof(T).Name).RemoveAll();
        }

        public T Find<T>(IMongoQuery query)
        {
            return dataBase.GetCollection<T>(typeof(T).Name).FindAs<T>(query).ToList().FirstOrDefault();
        }
    }
}
