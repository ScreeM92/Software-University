namespace TravelAgency.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;
    using System.Globalization;
    using TravelAgency.Tickets;
    
    [TestClass]
    public class GetTicketsCountTests
    {
        private ITicketCatalog catalog;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            catalog = new TicketCatalog();
        }

        [TestMethod]
        public void Test_GetTicketsCount_WithAirTickets_ShouldReturnTheCorrectCount()
        {
            this.catalog.AddAirTicket(
                flightNumber: "FX215",
                from: "Sofia",
                to: "Athens",
                airline: "Bulgaria Air",
                dateTime: new DateTime(2015, 1, 17, 12, 20, 0),
                price: 200);

            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Air));
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void Test_GetTicketsCount_WithBusTickets_ShouldReturnTheCorrectCount()
        {
            this.catalog.AddBusTicket(
                from: "Sofia",
                to: "Plovdiv",
                travelCompany: "Trakia Travel",
                dateTime: new DateTime(2015, 1, 27, 21, 20, 0),
                price: 11.5M);

            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Air));
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void Test_GetTicketsCount_WithTrainTickets_ShouldReturnTheCorrectCount()
        {
            this.catalog.AddTrainTicket(
                from: "Varna",
                to: "Sofia",
                dateTime: new DateTime(2015, 1, 27, 5, 22, 0),
                price: 24.25M,
                studentPrice: 11.5M);

            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Air));
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Bus));
        }
    }
}
