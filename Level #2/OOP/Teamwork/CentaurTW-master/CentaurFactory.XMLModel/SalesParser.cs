using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;


namespace CentaurFactory.XMLModel
{
    public class SalesParser
    {
        static List<Sale> sales = new List<Sale>();

       public List<Sale> ParseData(string path)
        {
            var sale = new Sale();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList salesCollection = xmlDoc.SelectNodes("ArrayOfSale/Sales/Sale");
            XmlReader reader = XmlReader.Create(path);
            int indexer = 0;

            using (reader)
            {
                foreach (XmlNode saleEntry in salesCollection)
                {
                    indexer++;
                    string month = saleEntry.SelectSingleNode("@month").FirstChild.Value.ToString();


                    XmlNodeList dishesCollection = xmlDoc.SelectNodes("ArrayOfSale/Sales/Sale["+ indexer +"]/dish");

                    List<string> dishCount = new List<string>();
                    List<string> dishCode = new List<string>();

                    foreach (XmlNode dish in dishesCollection)
                    {
                        dishCount.Add(dish.InnerText.ToString());
                        dishCode.Add(dish.SelectSingleNode("@code").FirstChild.Value.ToString());
                        
                    }

                    InitData(month, dishCode, dishCount);
                  
                }
               
            }
            return sales;
        }

        private static void InitData(string month, List<string> dishCode, List<string> dishCount)
        {
           
            DishSale[] dishSales = new DishSale[dishCode.Count];
        
            for (int i = 0; i < dishCode.Count; i++)
            {
                dishSales[i] = new DishSale { CountSold = int.Parse(dishCount[i]), DishCode = dishCode[i] };
            }

            Sale sale = new Sale
            {
                Month = month,
                DishSales = dishSales
            };

            sales.Add(sale);
            Console.WriteLine("Month: {0}", month);
            Console.WriteLine("Codes");
            foreach (var code in dishCode)
            {
                Console.WriteLine(code);
            }

            Console.WriteLine("Counts");
            foreach (var count in dishCount)
            {
                Console.WriteLine(count);
            }

        }
    }
}
