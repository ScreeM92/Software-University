namespace TravelAgency.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TravelAgency.Tickets;
    using System.Threading;
    using System.Globalization;

    [TestClass]
    public class AirTicketTests
    {
        private ITicketCatalog catalog;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            catalog = new TicketCatalog();
        }

        [TestMethod]
        public void Test_AddAirTicket_ShouldAddTheTicket()
        {
            string message = this.catalog.AddAirTicket(
                flightNumber: "FX215",
                from: "Sofia",
                to: "Athens",
                airline: "Bulgaria Air",
                dateTime: new DateTime(2015, 1, 17, 12, 20, 0),
                price: 200);

            Assert.AreEqual("Ticket added", message);
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Air));
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void Test_AddAirTicket_ShouldBeTheCorrectTicket()
        {
            this.catalog.AddAirTicket(
                flightNumber: "FX215",
                from: "Sofia",
                to: "Athens",
                airline: "Bulgaria Air",
                dateTime: new DateTime(2015, 1, 17, 12, 20, 0),
                price: 200);

            string message = this.catalog.FindTickets("Sofia", "Athens");

            Assert.AreEqual("[17.01.2015 12:20; air; 200.00]", message);
        }

        [TestMethod]
        public void Test_AddDuplicateAirTicket_ShouldReturnErrorMessage()
        {
            this.catalog.AddAirTicket(
                flightNumber: "FX215",
                from: "Sofia",
                to: "Athens",
                airline: "Bulgaria Air",
                dateTime: new DateTime(2015, 1, 17, 12, 20, 0),
                price: 200);
            string message = this.catalog.AddAirTicket(
                flightNumber: "FX215",
                from: "Sofia",
                to: "Athens",
                airline: "Bulgaria Air",
                dateTime: new DateTime(2015, 1, 17, 12, 20, 0),
                price: 200);

            Assert.AreEqual("Duplicate ticket", message);
        }

        [TestMethod]
        public void Test_DeleteAirTicket_ShouldDeleteTheTicket()
        {
            this.catalog.AddAirTicket(
                flightNumber: "FX215",
                from: "Sofia",
                to: "Athens",
                airline: "Bulgaria Air",
                dateTime: new DateTime(2015, 1, 17, 12, 20, 0),
                price: 200);
            string message = this.catalog.DeleteAirTicket("FX215");

            Assert.AreEqual("Ticket deleted", message);
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Air));
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void Test_DeleteDeletedAirTicket_ShouldReturnErrorMessage()
        {
            this.catalog.AddAirTicket(
                flightNumber: "FX215",
                from: "Sofia",
                to: "Athens",
                airline: "Bulgaria Air",
                dateTime: new DateTime(2015, 1, 17, 12, 20, 0),
                price: 200);
            this.catalog.DeleteAirTicket("FX215");
            string message = this.catalog.DeleteAirTicket("FX215");

            Assert.AreEqual("Ticket does not exist", message);
        }

        [TestMethod]
        public void Test_DeleteNonExistingAirTicket_ShouldReturnErrorMessage()
        {
            string message = this.catalog.DeleteAirTicket("FX215");

            Assert.AreEqual("Ticket does not exist", message);
        }
    }
}
