using System;
using System.Collections.Generic;

namespace InventoryManagementSystem
{
    // Product class
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"ID: {ProductId}, Name: {ProductName}, Qty: {Quantity}, Price: ${Price}";
        }
    }

    // Inventory management logic
    public class Inventory
    {
        private Dictionary<int, Product> products = new Dictionary<int, Product>();

        // Add new product
        public void AddProduct(Product product)
        {
            if (!products.ContainsKey(product.ProductId))
            {
                products[product.ProductId] = product;
                Console.WriteLine($"✅ Added: {product.ProductName}");
            }
            else
            {
                Console.WriteLine($"⚠️ Product with ID {product.ProductId} already exists.");
            }
        }

        // Update existing product
        public void UpdateProduct(Product product)
        {
            if (products.ContainsKey(product.ProductId))
            {
                products[product.ProductId] = product;
                Console.WriteLine($"🔄 Updated: {product.ProductName}");
            }
            else
            {
                Console.WriteLine($"❌ No product found with ID {product.ProductId}.");
            }
        }

        // Delete product
        public void DeleteProduct(int productId)
        {
            if (products.Remove(productId))
            {
                Console.WriteLine($"🗑️ Deleted product with ID {productId}");
            }
            else
            {
                Console.WriteLine($"❌ Product with ID {productId} not found.");
            }
        }

        // Display all products
        public void DisplayInventory()
        {
            Console.WriteLine("\n📦 Inventory List:");
            if (products.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }

            foreach (var product in products.Values)
            {
                Console.WriteLine(product);
            }
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();

            // Add products
            inventory.AddProduct(new Product { ProductId = 1, ProductName = "Mouse", Quantity = 100, Price = 15.99m });
            inventory.AddProduct(new Product { ProductId = 2, ProductName = "Keyboard", Quantity = 50, Price = 25.49m });

            // Display
            inventory.DisplayInventory();

            // Update product
            inventory.UpdateProduct(new Product { ProductId = 1, ProductName = "Wireless Mouse", Quantity = 80, Price = 18.99m });

            // Delete product
            inventory.DeleteProduct(2);

            // Final state
            inventory.DisplayInventory();

            Console.ReadKey();
        }
    }
}
