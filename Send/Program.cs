using System;
using EasyNetQ;
using Request;

namespace Send
{
    class Program
    {
        static void Main(string[] args) // this has the most use scenario , eg the simswap on maximus, it always the scale out on the recievers and fault tolerant
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

            var purchaseOrder1 = new PurchaseOrder()
            {
                Amount = 199.00m,
                CompanyName = "LegBook",
                PaymentDayTerms = 30,
                PoNumber = "LG123"
            };

            var purchaseOrder2 = new PurchaseOrder()
            {
                Amount = 109.00m,
                CompanyName = "NoseBook",
                PaymentDayTerms = 30,
                PoNumber = "NB123"
            };

            var purchaseOrder3 = new PurchaseOrder()
            {
                Amount = 99.00m,
                CompanyName = "HeadBook",
                PaymentDayTerms = 30,
                PoNumber = "HB123"
            };

            // sending single kind of message
            /*using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                Console.WriteLine("Publishing messages with send and recieve");
                Console.WriteLine();

                bus.Send("my.paymentQueue", payment1);
                bus.Send("my.paymentQueue", payment2);
                bus.Send("my.paymentQueue", payment3);
            }*/

            // sending multiple kind of message
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                Console.WriteLine("Publishing messages with send and recieve");
                Console.WriteLine();

                bus.Send("my.paymentQueue", payment1);
                bus.Send("my.paymentQueue", purchaseOrder1);
                bus.Send("my.paymentQueue", payment2);
                bus.Send("my.paymentQueue", purchaseOrder2);
                bus.Send("my.paymentQueue", payment3);
                bus.Send("my.paymentQueue", purchaseOrder3);
            }
        }
    }
}
