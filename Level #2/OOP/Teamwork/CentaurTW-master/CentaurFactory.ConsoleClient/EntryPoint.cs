namespace CentaurFactory.ConsoleClient
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using MongoDB.Driver.GridFS;
    using MongoDB.Driver.Linq;

    using MongoDB.Bson.IO;
    using MongoDB.Bson.Serialization;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.Conventions;
    using MongoDB.Bson.Serialization.IdGenerators;
    using MongoDB.Bson.Serialization.Options;
    using MongoDB.Bson.Serialization.Serializers;
    using MongoDB.Driver.Wrappers;
    using System.Collections.Generic;
    using System.Linq;
    using System.Configuration;
    using CentaurFactory.MongoDbProvider;
    using Ionic.Zip;

    using CentaurFactory.ExcelModel;
    using CentaurFactory.ExcelModel.Parsers;
    using CentaurFactory.SqlServerProvider;

    using Newtonsoft.Json;
    using Telerik.OpenAccess;
    using MySqlPRovider;
    using System.IO;
using System.Collections;
using CentaurFactory.Model;

    using CentaurFactory.XMLModel;

    public class EntryPoint
    {
        private static MongoProvider mongoProvider = new MongoProvider(ConfigurationManager.AppSettings["mongoDB"], "centaur_restaurant_db");

        public static void Option1()
        {
            var mongoRepo = new MongoRepository(mongoProvider);
            mongoRepo.EreaseData();
            mongoRepo.InitData();

            Console.WriteLine("Config data saved to Mongo DB");
        }

        public static void Option2()
        {
            var mongoRepo = new MongoRepository(mongoProvider);
            var allProductsInDb = mongoRepo.GetProducts();
            var allIngredientsInDB = mongoRepo.GetIngredients();
            
            Console.WriteLine("Config data read from Mongo DB");

            var sqlServerRepo = new SqlServerRepository("SQLServer");
            sqlServerRepo.AddProducts(allProductsInDb);
            sqlServerRepo.AddIngredients(allIngredientsInDB);

            Console.WriteLine("Confog data written into MSSQL");
        }

        public static void Option3()
        {
            Console.WriteLine("Data loaded from Excel 2003");
            Console.WriteLine("Data written into MSSQL");
        }

        public static void Option4()
        {
            Console.WriteLine("Data loaded from XML");
            Console.WriteLine("Data written into MSSQL");
        }

        public static void Option5()
        {
            Console.WriteLine("Confog data read from Mongo DB");
            Console.WriteLine("Confog data written into MSSQL");
        }

        public static void Option6()
        {
            Console.WriteLine("Data loaded from MSSQL");
            Console.WriteLine("Data written in MySQL");
            Console.WriteLine("Data exported to JSON");
        }

        public static void Option7()
        {
            Console.WriteLine("Data loaded from SQLite");
            Console.WriteLine("Data loaded from MySQL");
            Console.WriteLine("Data exported to XLSX");
        }

        public static void Option8()
        {
            Console.WriteLine("PDF file exported");
        }

        public static void Option9()
        {
            Console.WriteLine("XML file exported.");
        }

        public static void Main()
        {
            Menu menu = new Menu();
            menu.AddItem("1", "Init MongoDB", Option1);
            menu.AddItem("2", "TransferData from MongoDb to MSSQL", Option2);
            menu.AddItem("3", "TransferData from Zipped Excel 2003 (xls) to MSSQL", Option3);
            menu.AddItem("4", "TransferData from XML to MSSQL and MongoDB", Option4);
            menu.AddItem("5", "Create report to MySQL and write JSON", Option5);
            menu.AddItem("6", "Export data from SQLite and MySQL to Excel 2007(xlsx)", Option6);
            menu.AddItem("7", "Generate PDF report", Option7);
            menu.AddItem("8", "Generate XML report", Option8);
            menu.AddEndItem("9", "Exit");
            menu.Start();

            /* To be able to run this code you need first to download mongodb server local on your computer.
               this is the link for windows 64 
               https://fastdl.mongodb.org/win32/mongodb-win32-x86_64-2008plus-2.6.4.zip .
               Before you start up the bin/mongod.exe file(this is the server) you need to 
               create a new 'data/db' directory in C:/ and than you start the mongod.exe file.
               Then you can run the program successfully. */

            //var mongoClient = new MongoClient("mongodb://192.168.0.100/");
            //var mongoServer = mongoClient.GetServer();
            //var centaurRestaurantDb = mongoServer.GetDatabase("CentaurRestaurantDb");
            //var mongoProvider = new MongoProvider(ConfigurationManager.AppSettings["mongoDB"], "centaur_restaurant_db");
            //var mongoRepo = new MongoRepository(mongoProvider);

            // uncomment to load data to mongo db
            //mongoRepo.InitData();

            //var allProductsInDb = mongoRepo.GetProducts();
            //var sqlServerRepo = new SqlServerRepository("SQLServer");
            //sqlServerRepo.AddProducts(allProductsInDb);

            // uncomment to clear the data
            //mongoRepo.EreaseData();

            //var allProductsInDb = mongoRepo.GetProducts();
            //var allUnitTypesInDb = mongoRepo.GetUntTypes();
            //var allProductTypesInDb = mongoRepo.GetProductTypes();
            //foreach (var item in allUnitTypesInDb)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //foreach (var item in allProductsInDb)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //foreach (var item in allProductTypesInDb)
            //{
            //    Console.WriteLine(item.ToString());
            //}

<<<<<<< HEAD

            SalesParser salesParser = new SalesParser();
            List<CentaurFactory.XMLModel.Sale> sales = salesParser.ParseData("..\\..\\..\\CentaurFactory.XMLModel\\Sales.xml");

            UpdateDatabase();
=======
            //UpdateDatabase();
>>>>>>> 718026ce0ae7f0f99173f75cd9b76d00ecfd2e11

            // ExtractZipFiles();

            //DataContext data = new DataContext();
            //ExportReportToJsonFiles(data);



        }

        /// <summary>
        /// Extracts the zip file into a given directory
        /// </summary>
        /// <param name="path"></param>
        private static void ExtractZipFiles()
        {
            string zipToUnpack = "../../Report-Jul-2013.zip";
            string unpackDirectory = "../../";

            using (ZipFile zip = ZipFile.Read(zipToUnpack))
            {
                foreach (ZipEntry entry in zip)
                {
                    entry.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }

        private static void UpdateDatabase()
        {
            using (var context = new MySqlPRovider.CentaurFactoryModel())
            {
                var schemaHandler = context.GetSchemaHandler();
                EnsureDB(schemaHandler);
                //context.Add();
            }
        }

        private static void EnsureDB(ISchemaHandler schemaHandler)
        {
            string script = null;
            if (schemaHandler.DatabaseExists())
            {
                script = schemaHandler.CreateUpdateDDLScript(null);
            }
            else
            {
                schemaHandler.CreateDatabase();
                script = schemaHandler.CreateDDLScript();
            }

            if (!string.IsNullOrEmpty(script))
            {
                schemaHandler.ExecuteDDLScript(script);
            }
        }

        public static void ExportReportToJsonFiles(DataContext data)
        {
            var products = data.Products.Select(p => new
            {
                id = p.Id,
                name = p.Name,
                productType = p.ProductType,
                ingerdients = p.Ingredients,
                unitType = p.UnitType,
                qunatity = p.Quantity
            });

            Array.ForEach(Directory.GetFiles("..\\..\\..\\Reports\\Json-Reports\\"), File.Delete);

            var serializer = new JsonSerializer();
            foreach (var product in products)
            {
                string path = "..\\..\\..\\Reports\\Json-Reports\\" + product.id + ".json";

                using (var fileStream = new FileStream(path, FileMode.CreateNew))
                {
                    using (var sw = new StreamWriter(fileStream))
                    {
                        using (var writer = new JsonTextWriter(sw))
                        {
                            writer.Formatting = Formatting.Indented;
                            serializer.Serialize(writer, product);
                        }
                    }
                }
            }
        }

        public IEnumerable<DishReport> GetDishReports(IEnumerable<Sale> sales, IEnumerable<Ingredient> ingredients, DeliveryInfo delivery)
        {
            List<DishReport> reports = new List<DishReport>();



            return reports;
        }
    }
}
