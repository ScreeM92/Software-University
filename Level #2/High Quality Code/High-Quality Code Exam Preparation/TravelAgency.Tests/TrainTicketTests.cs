namespace TravelAgency.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TravelAgency.Tickets;
    using System.Threading;
    using System.Globalization;

    [TestClass]
    public class TrainTicketTests
    {
        private ITicketCatalog catalog;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            catalog = new TicketCatalog();
        }

        [TestMethod]
        public void Test_AddTrainTicket_ShouldAddTheTicket()
        {
            string message = this.catalog.AddTrainTicket(
                from: "Varna",
                to: "Sofia",
                dateTime: new DateTime(2015, 1, 27, 5, 22, 0),
                price: 24.25M,
                studentPrice: 11.5M);

            Assert.AreEqual("Ticket added", message);
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Air));
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void Test_AddTrainTicket_ShouldBeTheCorrectTicket()
        {
            this.catalog.AddTrainTicket(
               from: "Varna",
               to: "Sofia",
               dateTime: new DateTime(2015, 1, 27, 5, 22, 0),
               price: 24.25M,
               studentPrice: 11.5M);
            string message = this.catalog.FindTickets("Varna", "Sofia");

            Assert.AreEqual("[27.01.2015 05:22; train; 24.25]", message);
        }

        [TestMethod]
        public void Test_AddDuplicateTrainTicket_ShouldReturnErrorMessage()
        {
            this.catalog.AddTrainTicket(
               from: "Varna",
               to: "Sofia",
               dateTime: new DateTime(2015, 1, 27, 5, 22, 0),
               price: 24.25M,
               studentPrice: 11.5M);
            string message = this.catalog.AddTrainTicket(
               from: "Varna",
               to: "Sofia",
               dateTime: new DateTime(2015, 1, 27, 5, 22, 0),
               price: 24.25M,
               studentPrice: 11.5M);

            Assert.AreEqual("Duplicate ticket", message);
        }

        [TestMethod]
        public void Test_DeleteTrainTicket_ShouldDeleteTheTicket()
        {
            this.catalog.AddTrainTicket(
               from: "Varna",
               to: "Sofia",
               dateTime: new DateTime(2015, 1, 27, 5, 22, 0),
               price: 24.25M,
               studentPrice: 11.5M);
            string message = this.catalog.DeleteTrainTicket(
                "Varna",
                "Sofia",
                new DateTime(2015, 1, 27, 5, 22, 0));


            Assert.AreEqual("Ticket deleted", message);
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Air));
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void Test_DeleteDeletedTrainTicket_ShouldReturnErrorMessage()
        {
            this.catalog.AddTrainTicket(
               from: "Varna",
               to: "Sofia",
               dateTime: new DateTime(2015, 1, 27, 5, 22, 0),
               price: 24.25M,
               studentPrice: 11.5M);
            this.catalog.DeleteTrainTicket(
                "Varna",
                "Sofia",
                new DateTime(2015, 1, 27, 21, 20, 0));
            string message = this.catalog.DeleteTrainTicket(
                "Varna",
                "Sofia",
                new DateTime(2015, 1, 27, 21, 20, 0));

            Assert.AreEqual("Ticket does not exist", message);
        }

        [TestMethod]
        public void Test_DeleteNonExistingTrainTicket_ShouldReturnErrorMessage()
        {
            string message = this.catalog.DeleteTrainTicket(
                "Varna",
                "Sofia",
                new DateTime(2015, 1, 27, 21, 20, 0));

            Assert.AreEqual("Ticket does not exist", message);
        }
    }
}
