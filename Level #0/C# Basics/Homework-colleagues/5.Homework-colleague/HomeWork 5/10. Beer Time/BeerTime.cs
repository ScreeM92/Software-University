using System;

namespace BeerTime
{
    class BeerTime
    {
        static void Main(string[] args)
        {
            CultureInfo enUS = new CultureInfo("en-US");
            DateTime time;
            DateTime startTime = DateTime.Parse("1:00 PM");
            DateTime endTime = DateTime.Parse("3:00 AM");
            string dateString = Console.ReadLine();

            if (DateTime.TryParseExact(dateString, "h:mm tt", enUS,
                                        DateTimeStyles.None, out time))
            {
                if (time > startTime || time < endTime)
                {
                    Console.WriteLine("beer time");
                }
                else
                {
                    Console.WriteLine("non-beer time");
                }
            }
            else
            {
                Console.WriteLine("invalid time");
            }
        }
    }
}
