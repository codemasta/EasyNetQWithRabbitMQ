using EasyNetQ;
using System;
using TopicPublisher;

namespace CardPaymentTopicSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<IPayment>("cards", Handler, c => c.WithTopic("payment.cardPayment"));

                Console.WriteLine("Listening for (payment.cardpayment) message. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        private static void Handler(IPayment payment)
        {
            if (payment is CardPayment)
            {
                Console.WriteLine(payment);
            }
        }
    }
}
