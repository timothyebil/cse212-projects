using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace learn
{
    /// <summary>
    /// Corrected implementation satisfying all structural queue requirements.
    /// </summary>
    public class SimpleQueueSolution
    {
        private readonly List<int> _queue = new();

        public void Enqueue(int value)
        {
            _queue.Add(value);
        }

        public int Dequeue()
        {
            // Requirement 3: Throw exception if container is completely empty
            if (_queue.Count == 0)
            {
                throw new IndexOutOfRangeException("Defect fixed: Cannot dequeue from an empty boundary.");
            }

            // Requirement 2: Remove and return item cleanly from the front (index 0)
            int value = _queue[0];
            _queue.RemoveAt(0);
            return value;
        }

        public static void RunVerificationTests()
        {
            Console.WriteLine("======================\nQueue Solution Verification\n======================");
            
            Console.WriteLine("Running Test 1 (Single Item Enqueue/Dequeue)...");
            var q1 = new SimpleQueueSolution();
            q1.Enqueue(100);
            Trace.Assert(q1.Dequeue() == 100, "Test 1 Critical Error");
            Console.WriteLine("-> Test 1 Passed.");

            Console.WriteLine("------------------");
            
            Console.WriteLine("Running Test 2 (Multi-Item Sequential FIFO)...");
            var q2 = new SimpleQueueSolution();
            q2.Enqueue(100);
            q2.Enqueue(200);
            q2.Enqueue(300);
            
            Trace.Assert(q2.Dequeue() == 100, "FIFO Dequeue Item 1 Error");
            Trace.Assert(q2.Dequeue() == 200, "FIFO Dequeue Item 2 Error");
            Trace.Assert(q2.Dequeue() == 300, "FIFO Dequeue Item 3 Error");
            Console.WriteLine("-> Test 2 Passed.");

            Console.WriteLine("======================\n");
        }
    }
}
