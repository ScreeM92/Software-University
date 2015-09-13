namespace TravelAgency.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Parser
    {
        public static string ToDefaultDateTimeString(this DateTime dateTime)
        {
            string formattedDateTime =  string.Format(Constants.DefaultDateTimeFormat, dateTime);
            return formattedDateTime;
        }

        public static DateTime ParseDateTime(string dateTimeAsString)
        {
            DateTime result = DateTime.ParseExact(
                dateTimeAsString,
                Constants.DefaultDateTimeFormatForParsing,
                CultureInfo.InvariantCulture);
            return result;
        }

        public static string ToDefaultPriceString(this decimal price)
        {
            return string.Format(Constants.DefaultPriceFormat, price);
        }
    }
}
