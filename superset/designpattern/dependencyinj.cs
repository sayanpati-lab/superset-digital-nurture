using System;
using System.Collections.Generic;

namespace DependencyInjectionExample
{
    // Step 2: Define Repository Interface
    public interface ICustomerRepository
    {
        Customer FindCustomerById(int id);
    }

    // Step 3: Implement Concrete Repository
    public class CustomerRepositoryImpl : ICustomerRepository
    {
        private Dictionary<int, Customer> customerData = new Dictionary<int, Customer>()
        {
            {1, new Customer { Id = 1, Name = "Alice", Email = "alice@example.com" }},
            {2, new Customer { Id = 2, Name = "Bob", Email = "bob@example.com" }}
        };

        public Customer FindCustomerById(int id)
        {
            return customerData.ContainsKey(id) ? customerData[id] : null;
        }
    }

    // Customer model class
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    // Step 4: Define Service Class
    public class CustomerService
    {
        private readonly ICustomerRepository _repository;

        // Step 5: Constructor Injection
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public void DisplayCustomer(int id)
        {
            Customer customer = _repository.FindCustomerById(id);
            if (customer != null)
            {
                Console.WriteLine($"Customer Found:\nID: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }
    }

    // Step 6: Test Class
    class Program
    {
        static void Main(string[] args)
        {
            // Inject the repository into the service
            ICustomerRepository repository = new CustomerRepositoryImpl();
            CustomerService service = new CustomerService(repository);

            // Use the service
            Console.WriteLine("== Looking for Customer with ID 1 ==");
            service.DisplayCustomer(1);

            Console.WriteLine("\n== Looking for Customer with ID 3 ==");
            service.DisplayCustomer(3);

            Console.ReadKey();
        }
    }
}
