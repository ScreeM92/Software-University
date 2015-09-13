namespace TravelAgency.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TravelAgency.Tickets;
    using System.Threading;
    using System.Globalization;

    [TestClass]
    public class BusTicketTests
    {
        private ITicketCatalog catalog;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            catalog = new TicketCatalog();
        }

        [TestMethod]
        public void Test_AddBusTicket_ShouldAddTheTicket()
        {
            string message = this.catalog.AddBusTicket(
                from: "Sofia",
                to: "Plovdiv",
                travelCompany: "Trakia Travel",
                dateTime: new DateTime(2015, 1, 27, 21, 20, 0),
                price: 11.5M);

            Assert.AreEqual("Ticket added", message);
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Air));
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void Test_AddBusTicket_ShouldBeTheCorrectTicket()
        {
            this.catalog.AddBusTicket(
                from: "Sofia",
                to: "Plovdiv",
                travelCompany: "Trakia Travel",
                dateTime: new DateTime(2015, 1, 27, 21, 20, 0),
                price: 11.5M);

            string message = this.catalog.FindTickets("Sofia", "Plovdiv");

            Assert.AreEqual("[27.01.2015 21:20; bus; 11.50]", message);
        }

        [TestMethod]
        public void Test_AddDuplicateBusTicket_ShouldReturnErrorMessage()
        {
            this.catalog.AddBusTicket(
                from: "Sofia",
                to: "Plovdiv",
                travelCompany: "Trakia Travel",
                dateTime: new DateTime(2015, 1, 27, 21, 20, 0),
                price: 11.5M);
            string message = this.catalog.AddBusTicket(
                from: "Sofia",
                to: "Plovdiv",
                travelCompany: "Trakia Travel",
                dateTime: new DateTime(2015, 1, 27, 21, 20, 0),
                price: 11.5M);

            Assert.AreEqual("Duplicate ticket", message);
        }

        [TestMethod]
        public void Test_DeleteBusTicket_ShouldDeleteTheTicket()
        {
            this.catalog.AddBusTicket(
                from: "Sofia",
                to: "Plovdiv",
                travelCompany: "Trakia Travel",
                dateTime: new DateTime(2015, 1, 27, 21, 20, 0),
                price: 11.5M);
            string message = this.catalog.DeleteBusTicket(
                "Sofia",
                "Plovdiv",
                "Trakia Travel",
                new DateTime(2015, 1, 27, 21, 20, 0));

            Assert.AreEqual("Ticket deleted", message);
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Air));
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void Test_DeleteDeletedBusTicket_ShouldReturnErrorMessage()
        {
            this.catalog.AddBusTicket(
                from: "Sofia",
                to: "Plovdiv",
                travelCompany: "Trakia Travel",
                dateTime: new DateTime(2015, 1, 27, 21, 20, 0),
                price: 11.5M);
            this.catalog.DeleteBusTicket(
                "Sofia",
                "Plovdiv",
                "Trakia Travel",
                new DateTime(2015, 1, 27, 21, 20, 0));
            string message = this.catalog.DeleteBusTicket(
                "Sofia",
                "Plovdiv",
                "Trakia Travel",
                new DateTime(2015, 1, 27, 21, 20, 0));

            Assert.AreEqual("Ticket does not exist", message);
        }

        [TestMethod]
        public void Test_DeleteNonExistingTrainTicket_ShouldReturnErrorMessage()
        {
            string message = this.catalog.DeleteBusTicket(
                "Sofia",
                "Plovdiv",
                "Trakia Travel",
                new DateTime(2015, 1, 27, 21, 20, 0));

            Assert.AreEqual("Ticket does not exist", message);
        }
    }
}
