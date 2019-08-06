using EasyNetQ;
using System;
using TopicPublisher;

namespace AccountsTopicSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<IPayment>("accounts", Handler, c => c.WithTopic("payment.*"));

                Console.WriteLine("Listening for (payment.*) message. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        private static void Handler(IPayment payment)
        {
            if (payment is CardPayment)
            {

            }

            if (payment is PurchaseOrder)
            {

            }
        }
    }
}
