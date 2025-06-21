using System;

namespace EmployeeManagementSystem
{
    // Step 2: Employee class
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"ID: {EmployeeId}, Name: {Name}, Position: {Position}, Salary: ${Salary}";
        }
    }

    class Program
    {
        // Step 3: Array to store employees (fixed size)
        const int MaxEmployees = 100;
        static Employee[] employees = new Employee[MaxEmployees];
        static int count = 0;

        // Add employee - Time: O(1)
        static void AddEmployee(Employee emp)
        {
            if (count < MaxEmployees)
            {
                employees[count++] = emp;
                Console.WriteLine($"✅ Added: {emp.Name}");
            }
            else
            {
                Console.WriteLine("❌ Cannot add more employees. Array is full.");
            }
        }

        // Search employee by ID - Time: O(n)
        static Employee SearchEmployee(int id)
        {
            for (int i = 0; i < count; i++)
            {
                if (employees[i].EmployeeId == id)
                    return employees[i];
            }
            return null;
        }

        // Traverse - Time: O(n)
        static void TraverseEmployees()
        {
            Console.WriteLine("\n📋 Employee List:");
            if (count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(employees[i]);
            }
        }

        // Delete employee by ID - Time: O(n)
        static void DeleteEmployee(int id)
        {
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                if (employees[i].EmployeeId == id)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine($"❌ Employee with ID {id} not found.");
                return;
            }

            // Shift elements left
            for (int i = index; i < count - 1; i++)
            {
                employees[i] = employees[i + 1];
            }
            employees[--count] = null;

            Console.WriteLine($"🗑️ Deleted employee with ID {id}");
        }

        // Main test logic
        static void Main(string[] args)
        {
            // Step 3: Add employees
            AddEmployee(new Employee { EmployeeId = 1, Name = "Alice", Position = "Manager", Salary = 75000 });
            AddEmployee(new Employee { EmployeeId = 2, Name = "Bob", Position = "Developer", Salary = 60000 });
            AddEmployee(new Employee { EmployeeId = 3, Name = "Charlie", Position = "HR", Salary = 50000 });

            // Traverse
            TraverseEmployees();

            // Search
            Console.WriteLine("\n🔍 Searching for employee with ID 2:");
            var emp = SearchEmployee(2);
            Console.WriteLine(emp != null ? $"✅ Found: {emp}" : "❌ Not found.");

            // Delete
            Console.WriteLine("\n🗑️ Deleting employee with ID 2:");
            DeleteEmployee(2);

            // Final list
            TraverseEmployees();

            // Step 4: Complexity Analysis
            Console.WriteLine("\n📊 Time Complexity Analysis:");
            Console.WriteLine("Add: O(1), Search: O(n), Traverse: O(n), Delete: O(n)");
            Console.WriteLine("🔎 Arrays are fast for access but not dynamic.");
            Console.WriteLine("👉 Use List<Employee> if dynamic resizing is needed.");

            Console.ReadKey();
        }
    }
}
