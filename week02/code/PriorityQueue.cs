using System;
using System.Collections.Generic;

namespace week02
{
    public class PriorityQueue
    {
        private readonly List<Person> _queue = new();

        public int Length => _queue.Count;

        public void Enqueue(string name, int priority)
        {
            var person = new Person(name, priority);
            _queue.Add(person);
        }

        public Person Dequeue()
        {
            if (_queue.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            int highPriorityIndex = 0;
            
            for (int i = 1; i < _queue.Count; i++)
            {
                // Fix: Strict inequality (>) preserves FIFO sequence order for matching priorities
                if (_queue[i].Priority > _queue[highPriorityIndex].Priority)
                {
                    highPriorityIndex = i;
                }
            }

            var person = _queue[highPriorityIndex];
            _queue.RemoveAt(highPriorityIndex);
            
            return person;
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", _queue)}]";
        }
    }
}
