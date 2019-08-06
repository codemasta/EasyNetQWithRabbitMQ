using System;
using EasyNetQ;

namespace Request
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

                var response = bus.Request<CardPaymentRequestMessage, CardPaymentResponseMessage>(payment);
                Console.WriteLine(response.AuthCode);


                Console.WriteLine("Response recieved");
                Console.ReadLine();
            }
        }
    }
}
