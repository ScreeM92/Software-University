namespace XML_InternationalMatches
{
    using System;

    public class InternationalMatch
    {
        public string HomeCountryCode { get; set; }

        public string HomeCountry { get; set; }

        public int? HomeGoals { get; set; }

        public string AwayCountryCode { get; set; }

        public string AwayCountry { get; set; }

        public int? AwayGoals { get; set; }

        public string League { get; set; }

        public DateTime? MatchDate { get; set; }
    }
}