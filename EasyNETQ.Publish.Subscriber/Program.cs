using System;
using EasyNetQ;
using EasyNetQ.Core;

namespace EasyNETQ.Publish.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<CardPaymentRequestMessage>("cardPayment", HandleCardPaymentMessage);
            }
        }

        private static void HandleCardPaymentMessage(CardPaymentRequestMessage cardPaymentRequestMessage)
        {
            Console.WriteLine("Payment ");
            Console.WriteLine(cardPaymentRequestMessage);
        }
    }
}
