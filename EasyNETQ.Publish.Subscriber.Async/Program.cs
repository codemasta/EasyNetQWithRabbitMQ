using System;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Core;

namespace EasyNETQ.Publish.Subscriber.Async
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.SubscribeAsync<CardPaymentRequestMessage>("cardPayment",
                    message => Task.Factory.StartNew(() =>
                    {
                        Console.WriteLine("Payment ");
                        Console.WriteLine(message);
                    }).ContinueWith(task =>
                    {
                        if (task.IsCompleted && !task.IsFaulted)
                        {
                            Console.WriteLine("Finished processing all messages");
                        }
                        else
                        {
                            throw new EasyNetQException("Message processing exception - look in the default error queue");
                        }
                    }));
            }
        }

        private static void HandleCardPaymentMessage(CardPaymentRequestMessage cardPaymentRequestMessage)
        {
            Console.WriteLine("Payment ");
            Console.WriteLine(cardPaymentRequestMessage);
        }
    }
}
