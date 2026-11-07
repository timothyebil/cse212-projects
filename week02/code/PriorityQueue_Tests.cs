using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace week02
{
    [TestClass]
    public class PriorityQueue_Tests
    {
        /*
         * ====================================================================================
         * PRIORITY QUEUE TEST DOCUMENTATION
         * Student: Timothy Ebil
         * ====================================================================================
         *
         * TEST 1: Standard Priority Dequeue Order
         * Purpose: Verify that items are pulled in strict priority sequence (highest to lowest).
         * Steps: Enqueue("Low", 2), Enqueue("High", 10), Enqueue("Medium", 5)
         * Expected Result: "High", "Medium", "Low"
         * Actual Result Before Fix: "Medium", "High", "Low" (Failed)
         * Defect Found: The search loop did not scan the final element due to an incorrect termination condition index.
         *
         * TEST 2: FIFO Stability for Duplicate High Priorities
         * Purpose: Verify that if two items share the maximum priority, the one enqueued first is returned.
         * Steps: Enqueue("First", 7), Enqueue("Second", 7), Enqueue("Third", 3)
         * Expected Result: "First", "Second", "Third"
         * Actual Result Before Fix: "Second", "First", "Third" (Violated FIFO)
         * Defect Found: The comparison check used `>=` which erroneously replaced the front item with later items.
         *
         * TEST 3: Dequeue Empty Boundary Condition
         * Purpose: Assert that an empty queue throws an InvalidOperationException with the exact message.
         * Expected Result: InvalidOperationException thrown with message: "The queue is empty."
         * Actual Result Before Fix: Threw IndexOutOfRangeException (Failed).
         * Defect Found: No validation check was written to protect an empty state extraction.
         */

        [TestMethod]
        public void TestPriorityQueue_1_StandardSorting()
        {
            var priorityQueue = new PriorityQueue();
            priorityQueue.Enqueue("Low", 2);
            priorityQueue.Enqueue("High", 10);
            priorityQueue.Enqueue("Medium", 5);

            Assert.AreEqual("High", priorityQueue.Dequeue());
            Assert.AreEqual("Medium", priorityQueue.Dequeue());
            Assert.AreEqual("Low", priorityQueue.Dequeue());
        }

        [TestMethod]
        public void TestPriorityQueue_2_FifoStability()
        {
            var priorityQueue = new PriorityQueue();
            priorityQueue.Enqueue("First", 7);
            priorityQueue.Enqueue("Second", 7);
            priorityQueue.Enqueue("Third", 3);

            Assert.AreEqual("First", priorityQueue.Dequeue());
            Assert.AreEqual("Second", priorityQueue.Dequeue());
            Assert.AreEqual("Third", priorityQueue.Dequeue());
        }

        [TestMethod]
        public void TestPriorityQueue_3_EmptyQueueException()
        {
            var priorityQueue = new PriorityQueue();

            try
            {
                priorityQueue.Dequeue();
                Assert.Fail("An exception should have been thrown.");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("The queue is empty.", e.Message);
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception e)
            {
                Assert.Fail($"Wrong exception type thrown: {e.GetType()}");
            }
        }
    }
}
