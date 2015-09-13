namespace CentaurFactory.ExcelModel.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.IO;
    using Wintellect.PowerCollections;

    public class ExcelParser
    {
        private MultiDictionary<string, DeliveryInfo> deliveries;
        //private MultiDictionary<string, Dish> dishes;
        //private MultiDictionary<string, Sale> sales;


        public ExcelParser()
        {
            this.deliveries = new MultiDictionary<string, DeliveryInfo>(true);
            //this.dishes = new MultiDictionary<string, Dish>(true);
            //this.sales = new MultiDictionary<string, Sale>(true);
        }

        public MultiDictionary<string, DeliveryInfo> Deliveries
        {
            get
            {
                return this.deliveries;
            }
            set
            {
                this.deliveries = value;
            }
        }

        //public MultiDictionary<string, Dish> Dishes
        //{
        //    get
        //    {
        //        return this.dishes;
        //    }
        //    set
        //    {
        //        this.dishes = value;
        //    }
        //}

        //public MultiDictionary<string, Sale> Sales
        //{
        //    get
        //    {
        //        return this.sales;
        //    }
        //    set
        //    {
        //        this.sales = value;
        //    }
        //}

        public void ReadFilesAndFolders(string path, int indent)
        {
            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                var fileName = new FileInfo(file).Name;
                ReadExcelFile(path, fileName);
            }

            var directories = Directory.GetDirectories(path);

            foreach (var directory in directories)
            {
                ReadFilesAndFolders(directory, indent + 2);
            }
        }

        private void ReadExcelFile(string path, string fileName)
        {
            OleDbConnectionStringBuilder excelConnectionString = ConfigureConnectionString(path, fileName);

            OleDbConnection excelConnection = new OleDbConnection(excelConnectionString.ConnectionString);
            excelConnection.Open();

            var dirName = GetDirName(path);
            var className = GetClassName(fileName);

            var cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", excelConnection);

            var reader = cmd.ExecuteReader();
            using (reader)
            {
                if(className.ToLower() == "Deliveries".ToLower())
                {
                    ParseDeliveryInfo(reader, dirName);
                }
                //else if (className.ToLower() == "Dishes".ToLower())
                //{
                //    ParseDishes(reader, dirName);
                //}
                //else if (className.ToLower() == "Sales".ToLower())
                //{
                //    ParseSales(reader, dirName);

                //}

                throw new ArgumentException("class name is not valid", "className");
            }
        }

        private static string GetClassName(string fileName)
        {
            var indexOfFileNameEnd = fileName.IndexOf('-');
            var className = fileName.Substring(0, indexOfFileNameEnd - 0);
            return className;
        }

        private static string GetDirName(string path)
        {
            var indexOfDir = path.LastIndexOf('\\');
            var dirName = path.Substring(indexOfDir + 1);
            return dirName;
        }

        private void ParseDeliveryInfo(OleDbDataReader reader, string dirName)
        {
            while (reader.Read())
            {
                var productId = int.Parse(reader["ProductId"].ToString());
                var quantity = int.Parse(reader["Quantity"].ToString());
                var pricePerUnit = decimal.Parse(reader["Price Per Unit"].ToString());
                var month = int.Parse(reader["Month"].ToString());
                var year = int.Parse(reader["Year"].ToString());
                var date = DateTime.Parse(dirName).ToShortDateString();

                this.Deliveries.Add(date, new DeliveryInfo()
                {
                    ProductId = productId,
                    Quantity = quantity,
                    PricePerUnit = pricePerUnit,
                    Month = month,
                    Year = year
                });
            }
        }

        //private void ParseDishes(OleDbDataReader reader, string dirName)
        //{
        //    while (reader.Read())
        //    {
        //        var dishId = int.Parse(reader["DishId"].ToString());
        //        var name = (string)reader["Name"];
        //        var price = decimal.Parse(reader["Price"].ToString());
        //        var date = DateTime.Parse(dirName).ToShortDateString();

        //        this.Dishes.Add(date, new Dish()
        //        {
        //            DishId = dishId,
        //            Name = name,
        //            Price = price
        //        });
        //    }
        //}

        //private void ParseSales(OleDbDataReader reader, string dirName)
        //{
        //    while (reader.Read())
        //    {
        //        var productId = int.Parse(reader["ProductId"].ToString());
        //        var unitCount = int.Parse(reader["Units Count"].ToString()); ;
        //        var month = int.Parse(reader["Month"].ToString());
        //        var year = int.Parse(reader["Year"].ToString());
        //        var date = DateTime.Parse(dirName).ToShortDateString();

        //        this.Sales.Add(date, new Sale()
        //        {
        //            ProductId = productId,
        //            UnitCount = unitCount,
        //            Month = month,
        //            Year = year
        //        });
        //    }
        //}

        private static OleDbConnectionStringBuilder ConfigureConnectionString(string path, string fileName)
        {
            OleDbConnectionStringBuilder excelConnectionString = new OleDbConnectionStringBuilder();

            excelConnectionString.Provider = "Microsoft.Jet.OLEDB.4.0"; ;
            excelConnectionString.DataSource = path + "\\" + fileName; // @"D:\Telerik\Repos\CentaurTW\CentaurFactory.ConsoleClient\Report-Jul-2013\20-Jul-2013\Deliveries-20-Jul-2013.xls";
            excelConnectionString.Add("Extended Properties", "Excel 8.0;HDR=Yes;IMEX=2");

            return excelConnectionString;
        }

    }
}
