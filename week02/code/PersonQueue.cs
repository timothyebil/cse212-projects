using System;
using System.Collections.Generic;

namespace week02
{
    /// <summary>
    /// A correct First-In, First-Out (FIFO) implementation of a Person Queue.
    /// </summary>
    public class PersonQueue
    {
        private readonly List<Person> _queue = new();

        public int Length => _queue.Count;

        public void Enqueue(Person person)
        {
            // Fix: Add to the end of the list instead of inserting at index 0 (Stack behavior)
            _queue.Add(person);
        }

        public Person Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Error: Cannot dequeue from an empty queue.");
            }

            var person = _queue[0];
            _queue.RemoveAt(0);
            return person;
        }

        public bool IsEmpty()
        {
            return Length == 0;
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", _queue)}]";
        }
    }
}
