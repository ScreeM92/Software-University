namespace BattleFieldTests
{
    using System;
    using Battlefield;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BattlefieldTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCreateBattlefieldWithFieldSizeOverTheMax()
        {
            Battlefield battlefield = Battlefield.Create(11);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCreateBattlefieldWithNegativeFieldSize()
        {
            Battlefield battlefield = Battlefield.Create(-11);
        }

        [TestMethod]
        public void TestCreatingBattelfieldWithValidFieldSize()
        {
            Battlefield battlefield = Battlefield.Create(3);
            Assert.AreEqual(battlefield.FieldSize, 3);
        }

        [TestMethod]
        public void TestIsCellInRange()
        {
            Battlefield battlefield = Battlefield.Create(3);
            Cell cellInRange = new Cell(1, 1);
            Cell cellCoordinatesOverFieldSize = new Cell(4, 4);
            Cell cellNegativeCoordinates = new Cell(-1, -1);
            Assert.IsTrue(battlefield.IsCellInRange(cellInRange), "Cell should be in range");
            Assert.IsFalse(battlefield.IsCellInRange(cellCoordinatesOverFieldSize), "Cell should not be in range");
            Assert.IsFalse(battlefield.IsCellInRange(cellNegativeCoordinates), "Cell should not be in range");
        }
    }
}