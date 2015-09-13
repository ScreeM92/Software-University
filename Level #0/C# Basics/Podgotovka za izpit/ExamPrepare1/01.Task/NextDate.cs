using System;
using System.Globalization;
    class NextDate
    {
        static void Main()
        {
            string day = Console.ReadLine();
            string month = Console.ReadLine();
            string year = Console.ReadLine();
            DateTime date = DateTime.Parse(string.Format("{0}.{1}.{2}", day, month, year), CultureInfo.CreateSpecificCulture("bg-BG"));
            DateTime nextDate = date.AddDays(1);

            Console.WriteLine(nextDate.ToString("d.M.yyyy"), CultureInfo.CreateSpecificCulture("bg-BG"));
        }    
    }

