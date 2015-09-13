namespace _08.LinkedQueue.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _07.LinkedQueue;

    [TestClass]
    public class LinkedQueue
    {
        [TestMethod]
        public void CreateEmptyQueue_ShouldCreateSuccessfully()
        {
            var linkedQueue = new LinkedQueue<int>();
            Assert.AreEqual(0, linkedQueue.Count);
        }

        [TestMethod]
        public void CreateQueue_EnqueueSingleElement_ShouldWorkCorrectly()
        {
            var linkedQueue = new LinkedQueue<int>();
            linkedQueue.Enqueue(3);
            Assert.AreEqual(3, linkedQueue.Peak());
            Assert.AreEqual(1, linkedQueue.Count);
        }

        [TestMethod]
        public void CreateQueue_EnqueueSomeElements_ShouldWorkCorrectly()
        {
            var linkedQueue = new LinkedQueue<int>();
            linkedQueue.Enqueue(2);
            linkedQueue.Enqueue(6);

            Assert.AreEqual(2, linkedQueue.Count);
            Assert.AreEqual(2, linkedQueue.Dequeue());
            Assert.AreEqual(6, linkedQueue.Dequeue());
        }

        [TestMethod]
        public void CreateQueue_EnqueueLotsOfElements_ShouldWorkCorrectly()
        {
            var linkedQueue = new LinkedQueue<int>();
            Assert.AreEqual(0, linkedQueue.Count);

            for (int i = 0, count = 1; i < 1000; i += 2, count++)
            {
                linkedQueue.Enqueue(i);
                Assert.AreEqual(count, linkedQueue.Count);
            }
        }

        [TestMethod]
        public void CreateQueue_PeakFirstElement_ShouldWorkCorrectly()
        {
            var linkedQueue = new LinkedQueue<int>();
            linkedQueue.Enqueue(2);
            linkedQueue.Enqueue(6);

            Assert.AreEqual(2, linkedQueue.Peak());
        }

        [TestMethod]
        public void CreateQueue_DequeueSingleElement_ShouldWorkCorrectly()
        {
            var linkedQueue = new LinkedQueue<int>();
            linkedQueue.Enqueue(4);
            linkedQueue.Enqueue(6);
            linkedQueue.Enqueue(1);

            Assert.AreEqual(4, linkedQueue.Dequeue());
            Assert.AreEqual(2, linkedQueue.Count);
        }

        [TestMethod]
        public void CreateQueue_DequeueSomeElements_ShouldWorkCorrectly()
        {
            var linkedQueue = new LinkedQueue<int>();
            linkedQueue.Enqueue(2);
            linkedQueue.Enqueue(6);
            linkedQueue.Enqueue(1);

            Assert.AreEqual(2, linkedQueue.Dequeue());
            Assert.AreEqual(6, linkedQueue.Dequeue());
            Assert.AreEqual(1, linkedQueue.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateQueue_DequeueEmptyQueue_ShouldThrowException()
        {
            var linkedQueue = new LinkedQueue<int>();
            linkedQueue.Dequeue();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateQueue_PeakEmptyQueue_ShouldThrowException()
        {
            var linkedQueue = new LinkedQueue<int>();
            linkedQueue.Peak();
        }

        [TestMethod]
        public void CreateQueue_ReturnQueueAsArray_ShouldWorkCorrectly()
        {
            var linkedQueue = new LinkedQueue<int>();
            linkedQueue.Enqueue(3);
            linkedQueue.Enqueue(7);
            linkedQueue.Enqueue(0);

            var queueArr = linkedQueue.ToArray();
            var expectedArr = new[] { 3, 7, 0 };

            CollectionAssert.AreEqual(queueArr, expectedArr);
        }

        [TestMethod]
        public void CreateQueue_TestQueueEnumerable_ShouldWorkCorrectly()
        {
            var linkedQueue = new LinkedQueue<int>();
            linkedQueue.Enqueue(3);
            linkedQueue.Enqueue(7);
            linkedQueue.Enqueue(0);

            var values = new []{3, 7, 0};
            var i = 0;

            foreach (var element in linkedQueue)
            {
                Assert.AreEqual(values[i], element);
                i++;
            }
        }

        [TestMethod]
        public void CreateEmptyQueueOfDates_ReturnQueueAsArray_ShouldWorkCorrectly()
        {
            var linkedQueue = new LinkedQueue<DateTime>();

            var queueArr = linkedQueue.ToArray();
            var expectedArr = new DateTime[] { };

            CollectionAssert.AreEqual(queueArr, expectedArr);
        }
    }
}