using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace teach
{
    public class CustomerServiceSolution
    {
        private readonly List<Customer> _queue = new();
        private readonly int _maxSize;

        public class Customer
        {
            public string Name { get; }
            public string AccountId { get; }
            public string Problem { get; }

            public Customer(string name, string accountId, string problem)
            {
                Name = name;
                AccountId = accountId;
                Problem = problem;
            }

            public override string ToString() => $"{Name} ({AccountId}) : {Problem}";
        }

        public CustomerServiceSolution(int maxSize)
        {
            // Fix Defect 1: Validate boundaries and safely default invalid sizes to 10
            _maxSize = maxSize <= 0 ? 10 : maxSize;
        }

        public int MaxSize => _maxSize;
        public int CurrentCount => _queue.Count;

        public void AddNewCustomer(string name, string id, string problem)
        {
            // Fix Defect 2: Stop additions immediately when Count equals MaxSize
            if (_queue.Count >= _maxSize)
            {
                Console.WriteLine("Error: Maximum customer queue size reached.");
                return;
            }

            _queue.Add(new Customer(name, id, problem));
        }

        public Customer ServeCustomer()
        {
            // Fix Defect 3: Dequeue the customer by removing them from index 0
            if (_queue.Count == 0)
            {
                Console.WriteLine("Error: No customers left in the queue to serve.");
                return null!;
            }

            var customer = _queue[0];
            _queue.RemoveAt(0);
            return customer;
        }

        public static void RunSuite()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("Running Automated CustomerService Verification Tests");
            Console.WriteLine("==================================================");

            // Test 1: Size Boundary Default Checking
            Console.WriteLine("Running Test 1: Invalid Capacity Instantiation Checking...");
            var serviceInvalid = new CustomerServiceSolution(-5);
            Trace.Assert(serviceInvalid.MaxSize == 10, "Defect 1 Error: Invalid capacity sizing failed to default to 10.");
            Console.WriteLine("-> Test 1 Passed.");

            // Test 2: Full Queue Limit Enforcement
            Console.WriteLine("Running Test 2: Maximum Size Limit Enforcement...");
            var serviceFull = new CustomerServiceSolution(2);
            serviceFull.AddNewCustomer("Alpha", "A1", "Crash");
            serviceFull.AddNewCustomer("Beta", "B2", "Login");
            serviceFull.AddNewCustomer("Gamma", "G3", "Overflow Check"); // Should display error message
            Trace.Assert(serviceFull.CurrentCount == 2, "Defect 2 Error: Queue exceeded maximum allowed size limit boundaries.");
            Console.WriteLine("-> Test 2 Passed.");

            // Test 3: Safe Sequential Dequeue Service
            Console.WriteLine("Running Test 3: Sequential FIFO Customer Removal Verification...");
            var serviceFIFO = new CustomerServiceSolution(5);
            serviceFIFO.AddNewCustomer("Timothy", "T10", "Network Down");
            serviceFIFO.AddNewCustomer("Francis", "F20", "Billing Error");

            var customer1 = serviceFIFO.ServeCustomer();
            Trace.Assert(customer1.Name == "Timothy", "Defect 3 Error: FIFO front extraction failed.");
            Trace.Assert(serviceFIFO.CurrentCount == 1, "Defect 3 Error: Served customer was not popped from the index layout queue.");
            Console.WriteLine("-> Test 3 Passed.");

            Console.WriteLine("\n🎉 All Team Activity automated tests passed successfully!\n");
        }
    }
}
