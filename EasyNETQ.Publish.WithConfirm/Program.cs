using EasyNetQ.Core;
using System;
using EasyNetQ;

namespace EasyNETQ.Publish.WithConfirm
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

            using (var bus = RabbitHutch.CreateBus("host=localhost;publisherConfirms=true;timeout=10"))
            {
                Console.WriteLine("Publishing message with publish and subscriber");
                Console.WriteLine(" - Enabled publisher confirm");
                Console.WriteLine();

                Publish(bus,payment1);
                Publish(bus,payment2);
                Publish(bus,payment3);

                Console.ReadLine();
            }
        }

        public static void Publish(IBus bus, CardPaymentRequestMessage message)
        {
            bus.PublishAsync(message).ContinueWith(task =>
            {
                if (task.IsCompleted && !task.IsFaulted)
                {
                    Console.WriteLine("Task completed and not faulted");
                }

                if (task.IsFaulted)
                {
                    Console.WriteLine("\n\n");
                    Console.WriteLine(task.Exception);
                    Console.WriteLine("\n\n");
                }
            });
        }
    }
}
