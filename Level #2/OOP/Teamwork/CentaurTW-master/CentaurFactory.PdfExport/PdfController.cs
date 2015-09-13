namespace CentaurFactory.PdfExport
{
    using System;
    using System.Collections.Generic;
    using iTextSharp.text;
    using iTextSharp.text.pdf;

    using CentaurFactory.XMLModel;
    using System.IO;

    public class PdfController
    {

        public void CreatePdfReport(IDictionary<string, decimal> dishPrices, ICollection<Sale> salesForMonthX)
        {
            var unitsSoldPerDish = new Dictionary<string, int>();
            foreach (var sale in salesForMonthX)
            {
                foreach (var dish in sale.DishSales)
                {
                    if (unitsSoldPerDish.ContainsKey(dish.DishCode))
                    {
                        unitsSoldPerDish[dish.DishCode] = 0;
                    }

                    unitsSoldPerDish[dish.DishCode] += dish.CountSold;

                }
            }

            CreatePdf(unitsSoldPerDish);
        }

        public void CreatePdf(IDictionary<string, int> dishesCounts)
        {
            string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            try
            {
                using (FileStream fs = new FileStream(appRootDir + "/PDFs/" + "Chapter1_Example1.pdf", FileMode.Create, FileAccess.Write, FileShare.None))

                using (Document doc = new Document())

                using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                {
                    doc.Open();

                    foreach (var item in dishesCounts)
                    {

                        doc.Add(new Paragraph(string.Format("{0} -> {1}", item.Key, item.Value)));
                    }

                    doc.Close();
                }
            }
            catch (DocumentException de)
            {
                throw de;
            }
            catch (IOException ioe)
            {
                throw ioe;
            }
        }
    }
}
