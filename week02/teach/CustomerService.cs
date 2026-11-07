using System;
using System.Collections.Generic;

namespace teach
{
    public class CustomerService
    {
        private readonly List<Customer> _queue = new();
        private readonly int _maxSize;

        public class Customer
        {
            public string Name { get; set; }
            public string AccountId { get; set; }
            public string Problem { get; set; }

            public Customer(string name, string accountId, string problem)
            {
                Name = name;
                AccountId = accountId;
                Problem = problem;
            }

            public override string ToString() => $"{Name} ({AccountId}) : {Problem}";
        }

        public CustomerService(int maxSize)
        {
            // DEFECT 1: Supposed to default to 10 if invalid (<= 0), but incorrectly allows size 0 or negative sizes.
            _maxSize = maxSize; 
        }

        public void AddNewCustomer()
        {
            // DEFECT 2: Checks if Count > maxSize, which allows an extra customer over the limit before throwing an error.
            if (_queue.Count > _maxSize)
            {
                Console.WriteLine("Maximum queue size reached.");
                return;
            }

            Console.Write("Customer Name: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Account Id: ");
            string id = Console.ReadLine() ?? "";
            Console.Write("Problem: ");
            string problem = Console.ReadLine() ?? "";

            _queue.Add(new Customer(name, id, problem));
        }

        public void ServeCustomer()
        {
            // DEFECT 3: Supposed to dequeue (remove) the customer, but only prints them without removing them from index 0.
            if (_queue.Count > 0)
            {
                var customer = _queue[0];
                Console.WriteLine(customer);
            }
            else
            {
                Console.WriteLine("Queue is empty.");
            }
        }
    }
}
