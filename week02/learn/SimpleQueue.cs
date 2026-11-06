using System;
using System.Collections.Generic;

namespace learn
{
    /// <summary>
    /// Implements a FIFO queue containing standard internal bugs for defect detection.
    /// </summary>
    public class SimpleQueue
    {
        private readonly List<int> _queue = new();

        public void Enqueue(int value)
        {
            _queue.Add(value);
        }

        public int Dequeue()
        {
            // DEFECT 1: Boundary check error. Restricts dequeue when exactly 1 item remains.
            if (_queue.Count <= 1) 
                throw new IndexOutOfRangeException("Queue index boundary error.");

            // DEFECT 2: Removes from index 1 instead of index 0, violating FIFO principles.
            int value = _queue[1]; 
            _queue.RemoveAt(1);
            return value;
        }
    }
}
