using System;
using System.Globalization;
    class Program
    {
        static void Main()
        {
            CultureInfo cul = new CultureInfo("en-US");
            DateTime startTime = DateTime.Parse("1:00 PM");
            DateTime finishTime = DateTime.Parse("3:00 AM");
            DateTime date;
            Console.WriteLine("Enter a time in format “hh:mm tt” ");
            string dateString = Console.ReadLine();
            if (DateTime.TryParseExact(dateString, "h:mm tt", cul, DateTimeStyles.None, out date))
            {
                if (date >= startTime || date <= finishTime)
                {
                    Console.WriteLine("beer time");
                }
                else
                {
                    Console.WriteLine("no beer time");
                }
            }
            else
            {
                Console.WriteLine("Invalid time");
            }
        }
    }

