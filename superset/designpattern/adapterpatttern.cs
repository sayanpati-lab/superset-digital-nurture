using System;

namespace AdapterPatternExample
{
    // Step 2: Define the Target Interface
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    // Step 3: Adaptee Classes (third-party gateways with different interfaces)

    // PayPal uses its own method
    public class PayPalGateway
    {
        public void MakePayment(decimal money)
        {
            Console.WriteLine($"[PayPal] Processing payment of ${money}");
        }
    }

    // Stripe uses a completely different method name
    public class StripeGateway
    {
        public void Charge(decimal totalAmount)
        {
            Console.WriteLine($"[Stripe] Charging ${totalAmount}");
        }
    }

    // Razorpay also uses a unique method
    public class RazorpayGateway
    {
        public void ExecuteTransaction(decimal amountInRupees)
        {
            Console.WriteLine($"[Razorpay] Executing ₹{amountInRupees} transaction");
        }
    }

    // Step 4: Adapter Classes

    public class PayPalAdapter : IPaymentProcessor
    {
        private PayPalGateway _paypal = new PayPalGateway();

        public void ProcessPayment(decimal amount)
        {
            _paypal.MakePayment(amount);
        }
    }

    public class StripeAdapter : IPaymentProcessor
    {
        private StripeGateway _stripe = new StripeGateway();

        public void ProcessPayment(decimal amount)
        {
            _stripe.Charge(amount);
        }
    }

    public class RazorpayAdapter : IPaymentProcessor
    {
        private RazorpayGateway _razorpay = new RazorpayGateway();

        public void ProcessPayment(decimal amount)
        {
            _razorpay.ExecuteTransaction(amount);
        }
    }

    // Step 5: Test Class
    class Program
    {
        static void Main(string[] args)
        {
            IPaymentProcessor paypal = new PayPalAdapter();
            IPaymentProcessor stripe = new StripeAdapter();
            IPaymentProcessor razorpay = new RazorpayAdapter();

            Console.WriteLine("Processing payments with different gateways:\n");

            paypal.ProcessPayment(100.00m);
            stripe.ProcessPayment(250.50m);
            razorpay.ProcessPayment(799.99m);

            Console.ReadKey();
        }
    }
}
