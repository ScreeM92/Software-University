//namespace BattleFieldTests
//{
//    using System.Collections.Generic;
//    using Battlefield;
//    using Battlefield.Models.Factories;
//    using Microsoft.VisualStudio.TestTools.UnitTesting;

//    [TestClass]
//    public class PatternFactoryTests
//    {
//        [TestMethod]
//        public void TestGenerateFirstDetonationPattern()
//        {
//            var cell = new Cell(2, 4);
//            List<Cell> cellsToDetonate = new List<Cell>
//            {
//                new Cell(1, 3),
//                new Cell(3, 3),
//                new Cell(2, 4),
//                new Cell(1, 5),
//                new Cell(3, 5)
//            };

//            CollectionAssert.AreEqual(PatternFactory.GenerateFirstDetonationPattern(cell), cellsToDetonate);
//        }

//        [TestMethod]
//        public void TestGenerateSecondDetonationPattern()
//        {
//            var cell = new Cell(2, 4);
//            List<Cell> cellsToDetonate = new List<Cell>
//            {
//                new Cell(1, 3),
//                new Cell(3, 3),
//                new Cell(2, 4),
//                new Cell(1, 5),
//                new Cell(3, 5),
//                new Cell(2, 3),
//                new Cell(2, 5),
//                new Cell(1, 4),
//                new Cell(3, 4)
//            };

//            CollectionAssert.AreEqual(PatternFactory.GenerateSecondDetonationPattern(cell), cellsToDetonate);
//        }

//        [TestMethod]
//        public void TestGenerateThirdDetonationPattern()
//        {
//            var cell = new Cell(0, 0);

//            List<Cell> cellsToDetonate = new List<Cell>
//            {

//                new Cell(-1, -1),
//                new Cell(1, -1),
//                new Cell(0, 0),
//                new Cell(-1, 1),
//                new Cell(1, 1),
//                new Cell(0, -1),
//                new Cell(0, 1),
//                new Cell(-1, 0),
//                new Cell(1, 0),
//                new Cell(0, -2),
//                new Cell(0, 2),
//                new Cell(-2, 0),
//                new Cell(2, 0)
//            };

//            CollectionAssert.AreEqual(PatternFactory.GenerateThirdDetonationPattern(cell), cellsToDetonate);
//        }

//        [TestMethod]
//        public void TestGenerateFourthDetonationPattern()
//        {
//            var cell = new Cell(0, 0);

//            List<Cell> cellsToDetonate = new List<Cell>
//            {

//                new Cell(-1, -1),
//                new Cell(1, -1),
//                new Cell(0, 0),
//                new Cell(-1, 1),
//                new Cell(1, 1),
//                new Cell(0, -1),
//                new Cell(0, 1),
//                new Cell(-1, 0),
//                new Cell(1, 0),
//                new Cell(0, -2),
//                new Cell(0, 2),
//                new Cell(-2, 0),
//                new Cell(2, 0),
//                new Cell(-1, -2),
//                new Cell(1, -2),
//                new Cell(-1, 2),
//                new Cell(1, 2),
//                new Cell(-2, -1),
//                new Cell(-2, 1),
//                new Cell(2, -1),
//                new Cell(2, 1)
//            };

//            CollectionAssert.AreEqual(PatternFactory.GenerateFourthDetonationPattern(cell), cellsToDetonate);
//        }

//        [TestMethod]
//        public void TestGenerateFifthDetonationPattern()
//        {
//            var cell = new Cell(0, 0);

//            List<Cell> cellsToDetonate = new List<Cell>
//            {

//                new Cell(-1, -1),
//                new Cell(1, -1),
//                new Cell(0, 0),
//                new Cell(-1, 1),
//                new Cell(1, 1),
//                new Cell(0, -1),
//                new Cell(0, 1),
//                new Cell(-1, 0),
//                new Cell(1, 0),
//                new Cell(0, -2),
//                new Cell(0, 2),
//                new Cell(-2, 0),
//                new Cell(2, 0),
//                new Cell(-1, -2),
//                new Cell(1, -2),
//                new Cell(-1, 2),
//                new Cell(1, 2),
//                new Cell(-2, -1),
//                new Cell(-2, 1),
//                new Cell(2, -1),
//                new Cell(2, 1),



//                new Cell(-2, -2),
//                new Cell(-2, 2),
//                new Cell(2, -2),
//                new Cell(2, 2)
//            };

//            CollectionAssert.AreEqual(PatternFactory.GenerateFifthDetonationPattern(cell), cellsToDetonate);
//        }
//    }
//}
