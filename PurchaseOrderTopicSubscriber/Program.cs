using EasyNetQ;
using System;
using TopicPublisher;

namespace PurchaseOrderTopicSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<IPayment>("purchaseOrders", Handler, c => c.WithTopic("payment.purchaseOrder"));

                Console.WriteLine("Listening for (payment.purchaseOrder) message. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        private static void Handler(IPayment purchase)
        {
            if (purchase is PurchaseOrder)
            {
                Console.WriteLine(purchase);
            }
        }
    }
}
