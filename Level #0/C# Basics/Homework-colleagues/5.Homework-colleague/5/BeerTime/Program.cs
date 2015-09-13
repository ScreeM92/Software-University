using System;
using System.Globalization;
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the time to check in [HH:MM TT] :");
            string enteredData = Console.ReadLine();
            DateTime myTime = DateTime.ParseExact(enteredData, "hh:mm tt", CultureInfo.InvariantCulture);
            DateTime beerTimeStart = DateTime.ParseExact("01:00 PM", "hh:mm tt", CultureInfo.InvariantCulture);
            DateTime beerTimeEnd = DateTime.ParseExact("03:00 AM", "hh:mm tt", CultureInfo.InvariantCulture);

            if (myTime >= beerTimeStart || myTime < beerTimeEnd )
            {
                Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} is beer time",myTime);
            }
            else if (myTime <= beerTimeStart && myTime >= beerTimeEnd)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} is NOT beer time", myTime);
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
