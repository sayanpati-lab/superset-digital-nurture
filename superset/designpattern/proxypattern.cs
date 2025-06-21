using System;

namespace ProxyPatternExample
{
    // Step 2: Subject Interface
    public interface IImage
    {
        void Display();
    }

    // Step 3: Real Subject Class - loads image from a "remote server"
    public class RealImage : IImage
    {
        private string filename;

        public RealImage(string filename)
        {
            this.filename = filename;
            LoadFromServer(); // Simulate loading time
        }

        private void LoadFromServer()
        {
            Console.WriteLine($"[Loading] Image '{filename}' from remote server...");
        }

        public void Display()
        {
            Console.WriteLine($"[Displaying] Image: {filename}");
        }
    }

    // Step 4: Proxy Class - adds lazy loading and caching
    public class ProxyImage : IImage
    {
        private RealImage realImage;
        private string filename;

        public ProxyImage(string filename)
        {
            this.filename = filename;
        }

        public void Display()
        {
            if (realImage == null)
            {
                realImage = new RealImage(filename);  // Lazy initialization
            }
            realImage.Display(); // Cached image now displayed
        }
    }

    // Step 5: Test Class
    class Program
    {
        static void Main(string[] args)
        {
            IImage image1 = new ProxyImage("dog.png");
            IImage image2 = new ProxyImage("cat.png");

            Console.WriteLine("== First time displaying dog.png ==");
            image1.Display();

            Console.WriteLine("\n== Displaying dog.png again ==");
            image1.Display(); // Should use cache

            Console.WriteLine("\n== First time displaying cat.png ==");
            image2.Display();

            Console.ReadKey();
        }
    }
}
