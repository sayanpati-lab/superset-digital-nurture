using System;

namespace StrategyPatternExample
{
    // Step 2: Strategy Interface
    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }

    // Step 3: Concrete Strategy - Credit Card
    public class CreditCardPayment : IPaymentStrategy
    {
        private string cardNumber;
        private string cardHolder;

        public CreditCardPayment(string cardNumber, string cardHolder)
        {
            this.cardNumber = cardNumber;
            this.cardHolder = cardHolder;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid ${amount} using Credit Card [{cardNumber}], Card Holder: {cardHolder}");
        }
    }

    // Step 3: Concrete Strategy - PayPal
    public class PayPalPayment : IPaymentStrategy
    {
        private string email;

        public PayPalPayment(string email)
        {
            this.email = email;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid ${amount} using PayPal account [{email}]");
        }
    }

    // Step 4: Context Class
    public class PaymentContext
    {
        private IPaymentStrategy paymentStrategy;

        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            paymentStrategy = strategy;
        }

        public void Pay(decimal amount)
        {
            if (paymentStrategy == null)
            {
                Console.WriteLine("No payment method selected!");
                return;
            }
            paymentStrategy.Pay(amount);
        }
    }

    // Step 5: Test Class
    class Program
    {
        static void Main(string[] args)
        {
            PaymentContext context = new PaymentContext();

            Console.WriteLine("== Paying with Credit Card ==");
            context.SetPaymentStrategy(new CreditCardPayment("1234-5678-9876-5432", "Alice"));
            context.Pay(250.75m);

            Console.WriteLine("\n== Paying with PayPal ==");
            context.SetPaymentStrategy(new PayPalPayment("alice@example.com"));
            context.Pay(120.00m);

            Console.WriteLine("\n== Attempting to pay with no strategy ==");
            context.SetPaymentStrategy(null);
            context.Pay(50.00m);

            Console.ReadKey();
        }
    }
}
