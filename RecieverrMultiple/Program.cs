using System;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Core;
using Request;
using CardPaymentRequestMessage = Request.CardPaymentRequestMessage;

namespace RecieverrMultiple
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Receive("my.paymentsqueue", c =>
                        c.Add<CardPaymentRequestMessage>(message => HandleCardPaymentMessage(message))
                        .Add<PurchaseOrder>(message => HandlePurcahseOrderPaymentMessage(message)));

                Console.WriteLine("Listening for message.");
            }
        }

        private static void HandlePurcahseOrderPaymentMessage(PurchaseOrder message)
        {
           Console.WriteLine(message);
        }

        private static void HandleCardPaymentMessage(CardPaymentRequestMessage message)
        {
            Console.WriteLine(message);
        }
    }
}
