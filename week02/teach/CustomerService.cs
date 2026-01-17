/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Try to serve a customer when queue is empty
        // Expected Result: Should display "No customers in the queue."
        Console.WriteLine("Test 1");
        var cs = new CustomerService(2);
        cs.ServeCustomer(); // Queue is empty, should show error
        // Defect(s) Found: Missing empty queue check (FIXED)

        Console.WriteLine("=================");

        // Test 2  
        // Scenario: Create queue with invalid size
        // Expected Result: Should default to size 10
        Console.WriteLine("Test 2");
        cs = new CustomerService(-5); // Invalid size
        Console.WriteLine(cs); // Should show max_size=10
        // Defect(s) Found: None - works correctly

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Fill queue to max capacity and try to add more
        // Expected Result: Should display "Maximum Number of Customers in Queue." when full
        Console.WriteLine("Test 3");
        cs = new CustomerService(2); // Max size of 2
        Console.WriteLine("Queue created with max size 2");
        Console.WriteLine(cs);
        Console.WriteLine("Note: AddNewCustomer requires user input.");
        Console.WriteLine("To test: Run interactively and add 3 customers.");
        Console.WriteLine("The 3rd customer should be rejected with error message.");
        // Defect(s) Found: Used > instead of >= (FIXED to >=)

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    public class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("No customers in the queue.");
            return;
        }
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}