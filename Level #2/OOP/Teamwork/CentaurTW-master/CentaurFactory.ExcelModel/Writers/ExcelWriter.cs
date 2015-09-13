using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CentaurFactory.ExcelModel.Writer
{
    public static class ExcelWriter
    {
        private static Random rand = new Random();

        public static void CreateReport()
        {
            // Set the file name and get the output directory
            var fileName = "Report-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
            var outputDir = "../../../Reports/ExcelReports/";

            // Create the file
            var file = new FileInfo(outputDir + fileName);

            using (var package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Profit per month");

                // Set headers here
                worksheet.Cells[1, 1].Value = "Month";
                worksheet.Cells[1, 2].Value = "Income";
                worksheet.Cells[1, 3].Value = "Outcome";
                worksheet.Cells[1, 4].Value = "Profit";

                int numberOfColumns = 4;

                //Headers styling
                FormatHeaders(worksheet, numberOfColumns);

                FillData(worksheet, numberOfColumns);
                package.Save();
            }
        }

        private static List<MonthProfit> GetDataToFill()
        {
            List<MonthProfit> profit = new List<MonthProfit>();

            for (int i = 0; i < 50; i++)
            {
                MonthProfit currentProfit = new MonthProfit();
                currentProfit.Income = i * rand.Next(2000000);
                currentProfit.Outcome = i * rand.Next(2000000);
                int month = rand.Next(1, 4);
                switch (month)
                {
                    case 1:
                        currentProfit.Month = "Jan"; break;
                    case 2:
                        currentProfit.Month = "Feb"; break;
                    case 3:
                        currentProfit.Month = "Mar"; break;
                }

                profit.Add(currentProfit);
            }

            return profit;
        }
     
        private static void FillData(ExcelWorksheet worksheet, int numberOfColumns)
        {
            // Loop through all the people
            var profit = GetDataToFill();

            // Keep track of the row that we're on, but skip the header
            int currentRowNumber = 2;

            foreach (var record in profit)
            {
                // Change cell numbers and properties here
                worksheet.Cells[currentRowNumber, 1].Value = record.Month;
                worksheet.Cells[currentRowNumber, 2].Value = record.Income;
                worksheet.Cells[currentRowNumber, 3].Value = record.Outcome;
                worksheet.Cells[currentRowNumber, 4].Value = record.Profit;

                //Ok now format the company row
                FormatRows(worksheet, currentRowNumber, numberOfColumns);

                currentRowNumber++;
            }
        }

        private static void FormatRows(ExcelWorksheet worksheet, int rowNumber, int numberOfColumns)
        {
            using (var range = worksheet.Cells[rowNumber, 1, rowNumber, numberOfColumns])
            {
                range.Style.Font.Bold = false;

                SetBorders(range);

                range.Style.ShrinkToFit = false;
            }
        }

        private static void FormatHeaders(ExcelWorksheet worksheet, int numberOfColumns)
        {
            using (var range = worksheet.Cells[1, 1, 1, numberOfColumns])
            {
                SetBorders(range);
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                range.Style.ShrinkToFit = false;
            }
        }

        private static void SetBorders(ExcelRange range)
        {
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        }
    }
}
