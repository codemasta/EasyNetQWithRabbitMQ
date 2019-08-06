using System;
using EasyNetQ;
using EasyNetQ.Core;

namespace EasyNETQ.Publish
{
    class Program
    {
        static void Main(string[] args)
        {
            var payment1 = new CardPaymentRequestMessage
            {
                CardNumber = "1234567890655544",
                CardHolderName = "Ade Yinka",
                ExpiryDate = "12/12",
                Amount = 99.00m
            };

            var payment2 = new CardPaymentRequestMessage
            {
                CardNumber = "156656656655233",
                CardHolderName = "Sola Kemi",
                ExpiryDate = "10/11",
                Amount = 109.00m
            };

            var payment3 = new CardPaymentRequestMessage
            {
                CardNumber = "095757378387274",
                CardHolderName = "Femi Ajala",
                ExpiryDate = "01/19",
                Amount = 10.00m
            };

            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                Console.WriteLine("Publishing message with publish and subscriber");
                Console.WriteLine();

                bus.Publish(payment1);
                bus.Publish(payment2);
                bus.Publish(payment3);
            }
        }
    }
}
