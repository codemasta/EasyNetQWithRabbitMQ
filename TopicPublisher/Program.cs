using EasyNetQ;
using System;

namespace TopicPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var cardPayment1 = new CardPayment()
            {
                Amount = 24.99m,
                CardHolderName = "Mr Drump",
                CardNumber = "11/12"
            };

            var cardPayment2 = new CardPayment()
            {
                Amount = 24.99m,
                CardHolderName = "Mr Segun",
                CardNumber = "10/11"
            };

            var cardPayment3 = new CardPayment()
            {
                Amount = 24.99m,
                CardHolderName = "Mr Sola",
                CardNumber = "09/10"
            };

            var cardPayment4 = new CardPayment()
            {
                Amount = 24.99m,
                CardHolderName = "Mr Tunde",
                CardNumber = "05/09"
            };

            var purchaseOrder1 = new PurchaseOrder()
            {
                Amount = 134.25m,
                CompanyName = "Compilsoft",
                PaymentDayTerms = 30,
                PoNumber = "1234"
            };

            var purchaseOrder2 = new PurchaseOrder()
            {
                Amount = 134.25m,
                CompanyName = "Compilsoft",
                PaymentDayTerms = 30,
                PoNumber = "1234"
            };

            var purchaseOrder3 = new PurchaseOrder()
            {
                Amount = 134.25m,
                CompanyName = "Compilsoft",
                PaymentDayTerms = 30,
                PoNumber = "1234"
            };

            var purchaseOrder4 = new PurchaseOrder()
            {
                Amount = 134.25m,
                CompanyName = "Compilsoft",
                PaymentDayTerms = 30,
                PoNumber = "1234"
            };

            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                Console.WriteLine("Publishing messages with topic publish");
                Console.WriteLine();

                bus.Publish<IPayment>(cardPayment1 , "payment.cardPayment");
                bus.Publish<IPayment>(purchaseOrder1, "payment.purchaseOrder");
                bus.Publish<IPayment>(cardPayment2, "payment.cardPayment");
                bus.Publish<IPayment>(purchaseOrder2, "payment.purchaseOrder");
            }

        }
    }
}
