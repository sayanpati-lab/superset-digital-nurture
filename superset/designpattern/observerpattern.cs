using System;
using System.Collections.Generic;

namespace ObserverPatternExample
{
    // Step 2: Subject Interface
    public interface IStock
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    // Step 4: Observer Interface
    public interface IObserver
    {
        void Update(string stockName, double price);
    }

    // Step 3: Concrete Subject
    public class StockMarket : IStock
    {
        private List<IObserver> observers = new List<IObserver>();
        private string stockName;
        private double stockPrice;

        public void SetStockPrice(string name, double price)
        {
            this.stockName = name;
            this.stockPrice = price;
            Console.WriteLine($"\n[Stock Update] {stockName} is now ${stockPrice}");
            NotifyObservers();
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(stockName, stockPrice);
            }
        }
    }

    // Step 5: Concrete Observer - Mobile App
    public class MobileApp : IObserver
    {
        private string user;

        public MobileApp(string user)
        {
            this.user = user;
        }

        public void Update(string stockName, double price)
        {
            Console.WriteLine($"[MobileApp] {user} received update: {stockName} - ${price}");
        }
    }

    // Step 5: Concrete Observer - Web App
    public class WebApp : IObserver
    {
        private string clientName;

        public WebApp(string clientName)
        {
            this.clientName = clientName;
        }

        public void Update(string stockName, double price)
        {
            Console.WriteLine($"[WebApp] {clientName} received update: {stockName} - ${price}");
        }
    }

    // Step 6: Test Class
    class Program
    {
        static void Main(string[] args)
        {
            StockMarket stockMarket = new StockMarket();

            // Create observers
            IObserver mobileUser = new MobileApp("Alice");
            IObserver webUser = new WebApp("Bob");

            // Register observers
            stockMarket.RegisterObserver(mobileUser);
            stockMarket.RegisterObserver(webUser);

            // Update stock prices
            stockMarket.SetStockPrice("AAPL", 180.25);
            stockMarket.SetStockPrice("GOOGL", 2750.50);

            // Unsubscribe one observer
            stockMarket.RemoveObserver(webUser);

            // Update again to see if only Alice gets the update
            stockMarket.SetStockPrice("TSLA", 722.30);
        }}}