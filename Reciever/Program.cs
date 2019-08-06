using System;
using EasyNetQ;
using Request;

namespace Reciever
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Respond<CardPaymentRequestMessage, CardPaymentResponseMessage>(Responder);

                Console.WriteLine("Listening for messages. Hit <return> to quit");
                Console.ReadLine();
            }
        }

        private static CardPaymentResponseMessage Responder(CardPaymentRequestMessage arg)
        {
            return new CardPaymentResponseMessage(){ AuthCode = "1234"};
        }
    }
}
