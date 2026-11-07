using System;
using System.Collections.Generic;

namespace week02
{
    public class TakingTurnsQueue
    {
        private readonly List<Person> _queue = new();

        public int Length => _queue.Count;

        public void AddPerson(string name, int turns)
        {
            var person = new Person(name, turns);
            _queue.Add(person);
        }

        public Person GetNextPerson()
        {
            if (_queue.Count == 0)
            {
                throw new InvalidOperationException("No one in the queue.");
            }

            // Fix: Remove from front (index 0) to maintain true FIFO behavior
            Person person = _queue[0];
            _queue.RemoveAt(0);

            // Infinite turn check logic boundary (turns <= 0 means they stay forever)
            if (person.Turns <= 0)
            {
                _queue.Add(person);
            }
            else
            {
                person.Turns--;
                if (person.Turns > 0)
                {
                    _queue.Add(person);
                }
            }

            return person;
        }
    }
}
