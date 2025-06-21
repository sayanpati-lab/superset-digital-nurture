using System;
using System.Linq;

namespace ECommerceSearchOptimization
{
    // Big O Analysis (in comments):
    // Linear Search: O(n) - Good for small or unsorted data.
    // Binary Search: O(log n) - Efficient for large, sorted data.

    // Step 2: Product class with searchable attributes
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return $"ID: {ProductId}, Name: {ProductName}, Category: {Category}";
        }
    }

    class Program
    {
        // Step 3: Linear Search by product name
        public static Product LinearSearch(Product[] products, string name)
        {
            foreach (var product in products)
            {
                if (product.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return product;
            }
            return null;
        }

        // Step 3: Binary Search by product name (sorted input)
        public static Product BinarySearch(Product[] products, string name)
        {
            int left = 0;
            int right = products.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int comparison = string.Compare(products[mid].ProductName, name, StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                    return products[mid];
                else if (comparison < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return null;
        }

        // Step 4: Compare results and analyze performance
        static void Main(string[] args)
        {
            // Sample dataset
            Product[] inventory = {
                new Product { ProductId = 101, ProductName = "Mouse", Category = "Electronics" },
                new Product { ProductId = 102, ProductName = "Keyboard", Category = "Electronics" },
                new Product { ProductId = 103, ProductName = "Charger", Category = "Accessories" },
                new Product { ProductId = 104, ProductName = "USB Cable", Category = "Accessories" }
            };

            // Sort for binary search
            Product[] sortedInventory = inventory.OrderBy(p => p.ProductName).ToArray();

            // Search for a product
            string searchTerm = "Keyboard";

            Console.WriteLine("🔍 Searching using Linear Search:");
            var linearResult = LinearSearch(inventory, searchTerm);
            Console.WriteLine(linearResult != null ? $"✅ Found: {linearResult}" : "❌ Product not found.");

            Console.WriteLine("\n🔍 Searching using Binary Search:");
            var binaryResult = BinarySearch(sortedInventory, searchTerm);
            Console.WriteLine(binaryResult != null ? $"✅ Found: {binaryResult}" : "❌ Product not found.");

            // Summary
            Console.WriteLine("\n📊 Analysis:");
            Console.WriteLine("Linear Search: O(n) - No sorting needed, simple to implement.");
            Console.WriteLine("Binary Search: O(log n) - Requires sorted data, much faster on large datasets.");
            Console.WriteLine("Binary search is recommended for large, static product lists.");

            Console.ReadKey();
        }
    }
}
