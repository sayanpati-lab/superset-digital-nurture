using System;

namespace LibraryManagementSystem
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"ID: {BookId}, Title: {Title}, Author: {Author}";
        }
    }

    class Program
    {
        // Linear Search - O(n)
        static Book LinearSearch(Book[] books, string title)
        {
            foreach (var book in books)
            {
                if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                    return book;
            }
            return null;
        }

        // Binary Search - O(log n) - assumes sorted by title
        static Book BinarySearch(Book[] books, string title)
        {
            int left = 0;
            int right = books.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int comparison = string.Compare(books[mid].Title, title, StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                    return books[mid];
                else if (comparison < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return null;
        }

        // Utility to sort books by title (needed for binary search)
        static void SortBooksByTitle(Book[] books)
        {
            Array.Sort(books, (a, b) => string.Compare(a.Title, b.Title, StringComparison.OrdinalIgnoreCase));
        }

        static void Main(string[] args)
        {
            // Step 2: Book data
            Book[] books = {
                new Book { BookId = 1, Title = "Data Structures", Author = "Mark Allen" },
                new Book { BookId = 2, Title = "Algorithms", Author = "Robert Sedgewick" },
                new Book { BookId = 3, Title = "Operating Systems", Author = "Andrew Tanenbaum" },
                new Book { BookId = 4, Title = "Computer Networks", Author = "James Kurose" }
            };

            // Step 3: Linear search
            Console.WriteLine("🔎 Linear Search for 'Algorithms':");
            var result1 = LinearSearch(books, "Algorithms");
            Console.WriteLine(result1 != null ? $"✅ Found: {result1}" : "❌ Book not found.");

            // Step 3: Binary search (requires sorting)
            SortBooksByTitle(books); // important for binary search
            Console.WriteLine("\n🔍 Binary Search for 'Operating Systems':");
            var result2 = BinarySearch(books, "Operating Systems");
            Console.WriteLine(result2 != null ? $"✅ Found: {result2}" : "❌ Book not found.");

            // Step 4: Analysis
            Console.WriteLine("\n📊 Time Complexity Comparison:");
            Console.WriteLine("Linear Search: O(n) - Works on unsorted data.");
            Console.WriteLine("Binary Search: O(log n) - Requires sorted data.");
            Console.WriteLine("\n📌 Use Linear Search for small/unsorted datasets.");
            Console.WriteLine("📌 Use Binary Search for large/sorted datasets.");

            Console.ReadKey();
        }
    }
}
