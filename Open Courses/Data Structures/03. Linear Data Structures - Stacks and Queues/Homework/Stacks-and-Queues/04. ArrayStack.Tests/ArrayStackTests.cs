namespace _04.ArrayStack.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _03.ArrayStack;
    using System;

    [TestClass]
    public class ArrayStackTests
    {
        [TestMethod]
        public void CreateEmptyStack_DefaultCapacity_ShouldCreateSuccessfully()
        {
            var stack = new ArrayStack<int>();
            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(16, stack.Capacity);
        }

        [TestMethod]
        public void CreateEmptyStack_CustomCapacity_ShouldCreateSuccessfully()
        {
            var stack = new ArrayStack<int>(128);
            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(128, stack.Capacity);
        }

        [TestMethod]
        public void CreateStack_PushSingleElement_ShouldWorkCorrectly()
        {
            var stack = new ArrayStack<int>();
            stack.Push(3);
            Assert.AreEqual(3, stack.Peak());
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        public void CreateStack_PushSomeElements_ShouldWorkCorrectly()
        {
            var stack = new ArrayStack<int>();
            stack.Push(2);
            stack.Push(6);

            Assert.AreEqual(2, stack.Count);
            Assert.AreEqual(6, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
        }

        [TestMethod]
        public void CreateStack_PushLotsOfElements_ShouldWorkCorrectly()
        {
            var stack = new ArrayStack<int>();
            Assert.AreEqual(0, stack.Count);

            for (int i = 0, count = 1; i < 1000; i += 2, count++)
            {
                stack.Push(i);
                Assert.AreEqual(count, stack.Count);
            }
        }

        [TestMethod]
        public void CreateStack_PeakTopElement_ShouldWorkCorrectly()
        {
            var stack = new ArrayStack<int>();
            stack.Push(2);
            stack.Push(6);

            Assert.AreEqual(6, stack.Peak());
        }

        [TestMethod]
        public void CreateStack_PopSingleElement_ShouldWorkCorrectly()
        {
            var stack = new ArrayStack<int>();
            stack.Push(2);
            stack.Push(6);
            stack.Push(1);
            
            Assert.AreEqual(1, stack.Pop());
            Assert.AreEqual(2, stack.Count);
        }

        [TestMethod]
        public void CreateStack_PopSomeElements_ShouldWorkCorrectly()
        {
            var stack = new ArrayStack<int>();
            stack.Push(2);
            stack.Push(6);
            stack.Push(1);

            Assert.AreEqual(1, stack.Pop());
            Assert.AreEqual(6, stack.Pop());
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateStack_PopEmptyStack_ShouldThrowException()
        {
            var stack = new ArrayStack<int>();
            stack.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateStack_PeakEmptyStack_ShouldThrowException()
        {
            var stack = new ArrayStack<int>();
            stack.Peak();
        }

        [TestMethod]
        public void CreateStack_TestGrowCapacity_ShouldWorkCorrectly()
        {
            var stack = new ArrayStack<int>(2);
            stack.Push(2);
            stack.Push(-11);
            stack.Push(23);
            Assert.AreEqual(4, stack.Capacity);
        }

        [TestMethod]
        public void CreateStack_ReturnStackAsArray_ShouldWorkCorrectly()
        {
            var stack = new ArrayStack<int>();
            stack.Push(3);
            stack.Push(7);
            stack.Push(0);

            var stackArr = stack.ToArray();
            var expectedArr = new []{0, 7, 3};

            CollectionAssert.AreEqual(stackArr, expectedArr);
        }

        [TestMethod]
        public void CreateEmptyStackOfDates_ReturnStackAsArray_ShouldWorkCorrectly()
        {
            var stack = new ArrayStack<DateTime>();

            var stackArr = stack.ToArray();
            var expectedArr = new DateTime[]{};

            CollectionAssert.AreEqual(stackArr, expectedArr);
        }
    }
}