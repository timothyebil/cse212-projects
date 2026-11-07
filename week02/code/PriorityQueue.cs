using System;
using System.Collections.Generic;

namespace week02
{
    public class PriorityQueue
    {
        private readonly List<Person> _queue = new List<Person>();

        public int Length => _queue.Count;

        public void Enqueue(string value, int priority)
        {
            var item = new Person(value, priority);
            _queue.Add(item);
        }

        public string Dequeue()
        {
            if (_queue.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            int highPriorityIndex = 0;

            // Strict '>' comparison maintains correct FIFO stability
            for (int i = 1; i < _queue.Count; i++)
            {
                if (_queue[i].Turns > _queue[highPriorityIndex].Turns)
                {
                    highPriorityIndex = i;
                }
            }

            string value = _queue[highPriorityIndex].Name;
            _queue.RemoveAt(highPriorityIndex);

            return value;
        }
    }
}
