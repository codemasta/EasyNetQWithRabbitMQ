using System;
using EasyNetQ;
using EasyNetQ.Core;

namespace EasyNetQTraining.Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                using (var bus = RabbitHutch.CreateBus("host=localhost"))
                { 
                    bus.Publish(new TextMessage
                    {
                        Text = i + " : Hello World from EasyNetQ"
                    });
                }
            }

            Console.ReadLine();
        }
    }
}
