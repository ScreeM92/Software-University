namespace TravelAgency.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;
    using System.Globalization;

    [TestClass]
    public class FindTicketsInIntervalTests
    {
        private ITicketCatalog catalog;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            catalog = new TicketCatalog();
        }

        [TestMethod]
        public void Test_FindTicketsInIntervalWithOneTicket_ShouldReturnTheCorrectTicket()
        {
            this.catalog.AddAirTicket(
                flightNumber: "FX215",
                from: "Sofia",
                to: "Athens",
                airline: "Bulgaria Air",
                dateTime: new DateTime(2015, 1, 17, 12, 20, 0),
                price: 200);

            string message = this.catalog.FindTicketsInInterval(
                new DateTime(2015, 1, 17, 0, 0, 0),
                new DateTime(2015, 1, 18, 0, 0, 0));
            Assert.AreEqual("[17.01.2015 12:20; air; 200.00]", message);
        }

        [TestMethod]
        public void Test_FindTicketsInInterval_ShouldReturnOnlyTheCorrectTickets()
        {
            this.catalog.AddAirTicket(
                flightNumber: "FX215",
                from: "Sofia",
                to: "Athens",
                airline: "Bulgaria Air",
                dateTime: new DateTime(2015, 1, 17, 12, 20, 0),
                price: 200);
            this.catalog.AddBusTicket(
                from: "Sofia",
                to: "Plovdiv",
                travelCompany: "Trakia Travel",
                dateTime: new DateTime(2015, 1, 27, 21, 20, 0),
                price: 11.5M);
            this.catalog.AddTrainTicket(
               from: "Varna",
               to: "Sofia",
               dateTime: new DateTime(2015, 3, 17, 5, 22, 0),
               price: 24.25M,
               studentPrice: 11.5M);

            string message = this.catalog.FindTicketsInInterval(
                new DateTime(2015, 1, 27, 0, 0, 0),
                new DateTime(2015, 1, 28, 0, 0, 0));
            Assert.AreEqual("[27.01.2015 21:20; bus; 11.50]", message);
        }

        [TestMethod]
        public void Test_FindTicketsInIntervalInEmptyCatalog_ShouldReturnErrorMessage()
        {
            string message = this.catalog.FindTicketsInInterval(
                new DateTime(2015, 1, 17, 0, 0, 0),
                new DateTime(2015, 1, 18, 0, 0, 0));
            Assert.AreEqual("Not found", message);
        }

        [TestMethod]
        public void Test_FindWrongTicketsInInterval_ShouldReturnNoTickets()
        {
            this.catalog.AddAirTicket(
                flightNumber: "FX215",
                from: "Sofia",
                to: "Athens",
                airline: "Bulgaria Air",
                dateTime: new DateTime(2015, 1, 17, 12, 20, 0),
                price: 200);
            this.catalog.AddBusTicket(
                from: "Sofia",
                to: "Plovdiv",
                travelCompany: "Trakia Travel",
                dateTime: new DateTime(2015, 1, 27, 21, 20, 0),
                price: 11.5M);
            this.catalog.AddTrainTicket(
               from: "Varna",
               to: "Sofia",
               dateTime: new DateTime(2015, 1, 27, 5, 22, 0),
               price: 24.25M,
               studentPrice: 11.5M);

            string message = this.catalog.FindTicketsInInterval(
                new DateTime(2014, 1, 1, 0, 0, 0),
                new DateTime(2014, 12, 31, 0, 0, 0));
            Assert.AreEqual("Not found", message);
        }

        [TestMethod]
        public void Test_FindTickets_ShouldSortProperly()
        {
            this.catalog.AddAirTicket(
                flightNumber: "FX215",
                from: "Sofia",
                to: "Athens",
                airline: "Bulgaria Air",
                dateTime: new DateTime(2015, 1, 17, 12, 20, 0),
                price: 200);
            this.catalog.AddAirTicket(
                flightNumber: "FX210",
                from: "Sofia",
                to: "Athens",
                airline: "Lufthanza",
                dateTime: new DateTime(2015, 1, 17, 12, 20, 0),
                price: 100);
            this.catalog.AddBusTicket(
                from: "Sofia",
                to: "Athens",
                travelCompany: "Trakia Travel",
                dateTime: new DateTime(2015, 1, 17, 12, 20, 0),
                price: 11.5M);
            this.catalog.AddTrainTicket(
               from: "Sofia",
               to: "Athens",
               dateTime: new DateTime(2015, 1, 17, 12, 21, 0),
               price: 24.25M,
               studentPrice: 11.5M);

            this.catalog.AddBusTicket(
                from: "Sofia",
                to: "Athens",
                travelCompany: "Trakia Travel",
                dateTime: new DateTime(2015, 1, 27, 21, 20, 0),
                price: 11.5M);
            this.catalog.AddTrainTicket(
               from: "Sofia",
               to: "Athens",
               dateTime: new DateTime(2015, 1, 27, 5, 22, 0),
               price: 24.25M,
               studentPrice: 11.5M);

            string message = this.catalog.FindTicketsInInterval(
                new DateTime(2014, 1, 17, 0, 0, 0),
                new DateTime(2016, 1, 18, 0, 0, 0));
            Assert.AreEqual("[17.01.2015 12:20; air; 100.00] [17.01.2015 12:20; air; 200.00] [17.01.2015 12:20; bus; 11.50] [17.01.2015 12:21; train; 24.25] [27.01.2015 05:22; train; 24.25] [27.01.2015 21:20; bus; 11.50]", message);
        }
    }
}
