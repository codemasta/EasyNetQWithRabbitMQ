using System;
using EasyNetQ.Core;

namespace EasyNetQ.Sender.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Waiting for message....");
                using (var bus = RabbitHutch.CreateBus("host=localhost"))
                {
                    bus.Subscribe<TextMessage>("test", HandleTextMessage);
                    Console.WriteLine("Listening for messages. Hit <return> to quit");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void HandleTextMessage(TextMessage textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Got message: {0}", textMessage.Text);
            Console.ResetColor();
        }
    }
}
