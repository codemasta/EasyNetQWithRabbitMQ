using Request;
using System;
using EasyNetQ;

namespace RequestAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            var payment = new CardPaymentRequestMessage()
            {
                CardNumber = "1234567890544433",
                CardHolderName = "Mr Seun",
                ExpiryDate = "12/12",
                Amount = 99.00m
            };

            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                Console.WriteLine("Publishing messages with request and response");
                Console.WriteLine();

                var task = bus.RequestAsync<CardPaymentRequestMessage, CardPaymentResponseMessage>(payment);
                task.ContinueWith(response => { Console.WriteLine("Got response : '{0}'", response.Result.AuthCode); });
                Console.ReadLine();
            }
        }
    }
}
