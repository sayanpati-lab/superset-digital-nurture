using System;

namespace DecoratorPatternExample
{
    // Step 2: Define the Component Interface
    public interface INotifier
    {
        void Send(string message);
    }

    // Step 3: Concrete Component (base functionality)
    public class EmailNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"[Email] Notification sent: {message}");
        }
    }

    // Step 4: Abstract Decorator
    public abstract class NotifierDecorator : INotifier
    {
        protected INotifier wrappedNotifier;

        public NotifierDecorator(INotifier notifier)
        {
            wrappedNotifier = notifier;
        }

        public virtual void Send(string message)
        {
            wrappedNotifier.Send(message);
        }
    }

    // Step 4: Concrete Decorator - SMS
    public class SMSNotifierDecorator : NotifierDecorator
    {
        public SMSNotifierDecorator(INotifier notifier) : base(notifier) { }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine($"[SMS] Notification sent: {message}");
        }
    }

    // Step 4: Concrete Decorator - Slack
    public class SlackNotifierDecorator : NotifierDecorator
    {
        public SlackNotifierDecorator(INotifier notifier) : base(notifier) { }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine($"[Slack] Notification sent: {message}");
        }
    }

    // Step 5: Test Class
    class Program
    {
        static void Main(string[] args)
        {
            // Basic email notification
            INotifier emailNotifier = new EmailNotifier();

            // Email + SMS
            INotifier smsEmailNotifier = new SMSNotifierDecorator(emailNotifier);

            // Email + SMS + Slack
            INotifier allChannelNotifier = new SlackNotifierDecorator(smsEmailNotifier);

            Console.WriteLine("== Sending Notification with Email only ==");
            emailNotifier.Send("Server is up.");

            Console.WriteLine("\n== Sending Notification with Email + SMS ==");
            smsEmailNotifier.Send("High memory usage detected.");

            Console.WriteLine("\n== Sending Notification with Email + SMS + Slack ==");
            allChannelNotifier.Send("Critical alert: Service down!");

            Console.ReadKey();
        }
    }
}
