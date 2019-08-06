using EasyNetQ;
using Request;
using System;

namespace Recieverr
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Receive<CardPaymentRequestMessage>("my.paymentQueue", message => HandleCardPaymentMessage(message));
            }
        }

        private static void HandleCardPaymentMessage(CardPaymentRequestMessage paymentRequestMessage)
        {
            Console.WriteLine(paymentRequestMessage);
        }
    }
}
