using System;

namespace CustomerOrderSorting
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalPrice { get; set; }

        public override string ToString()
        {
            return $"Order ID: {OrderId}, Customer: {CustomerName}, Total: ${TotalPrice}";
        }
    }

    class Program
    {
        // Bubble Sort by totalPrice
        static void BubbleSort(Order[] orders)
        {
            int n = orders.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (orders[j].TotalPrice > orders[j + 1].TotalPrice)
                    {
                        // Swap
                        var temp = orders[j];
                        orders[j] = orders[j + 1];
                        orders[j + 1] = temp;
                    }
                }
            }
        }

        // Quick Sort by totalPrice
        static void QuickSort(Order[] orders, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(orders, low, high);
                QuickSort(orders, low, pi - 1);
                QuickSort(orders, pi + 1, high);
            }
        }

        static int Partition(Order[] orders, int low, int high)
        {
            decimal pivot = orders[high].TotalPrice;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (orders[j].TotalPrice <= pivot)
                {
                    i++;
                    var temp = orders[i];
                    orders[i] = orders[j];
                    orders[j] = temp;
                }
            }

            var swap = orders[i + 1];
            orders[i + 1] = orders[high];
            orders[high] = swap;

            return i + 1;
        }

        static void Display(string title, Order[] orders)
        {
            Console.WriteLine($"\n📦 {title}");
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
        }

        static void Main(string[] args)
        {
            // Sample data
            Order[] orders = {
                new Order { OrderId = 1, CustomerName = "Alice", TotalPrice = 250.00m },
                new Order { OrderId = 2, CustomerName = "Bob", TotalPrice = 150.50m },
                new Order { OrderId = 3, CustomerName = "Charlie", TotalPrice = 499.99m },
                new Order { OrderId = 4, CustomerName = "Diana", TotalPrice = 300.25m }
            };

            // Bubble Sort
            Order[] bubbleSorted = (Order[])orders.Clone();
            BubbleSort(bubbleSorted);
            Display("Bubble Sort (O(n²))", bubbleSorted);

            // Quick Sort
            Order[] quickSorted = (Order[])orders.Clone();
            QuickSort(quickSorted, 0, quickSorted.Length - 1);
            Display("Quick Sort (O(n log n))", quickSorted);

            // Analysis Summary
            Console.WriteLine("\n📊 Analysis:");
            Console.WriteLine("- Bubble Sort: Simple, but inefficient for large datasets (O(n²)).");
            Console.WriteLine("- Quick Sort: Efficient for large unsorted data (average O(n log n)).");
            Console.WriteLine("- ✅ Quick Sort is preferred for performance-sensitive applications like e-commerce platforms.");

            Console.ReadKey();
        }
    }
}
