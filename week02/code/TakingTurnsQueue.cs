using System;
using System.Collections.Generic;

namespace week02
{
    public class TakingTurnsQueue
    {
        private readonly Queue<Person> _queue = new Queue<Person>();

        public int Length => _queue.Count;

        public void AddPerson(string name, int turns)
        {
            var person = new Person(name, turns);
            _queue.Enqueue(person);
        }

        public Person GetNextPerson()
        {
            if (_queue.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            Person person = _queue.Dequeue();

            if (person.Turns > 1)
            {
                person.Turns--;
                _queue.Enqueue(person);
            }
            else if (person.Turns <= 0)
            {
                _queue.Enqueue(person);
            }

            return person;
        }
    }
}
