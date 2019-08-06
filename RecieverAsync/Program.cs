using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using EasyNetQ;
using Request;

namespace RecieverAsync
{
    class Program
    {
        static void Main(string[] args)
        {
           // create a group of worker objects
           var workers = new BlockingCollection<MyWorker>();
           for (int i = 0; i < 10; i++)
           {
               workers.Add(new MyWorker());
           }

           using (var bus = RabbitHutch.CreateBus("host=localhost"))
           {
               // respond to request
               bus.RespondAsync<CardPaymentRequestMessage, CardPaymentResponseMessage>(request =>
                   Task.Factory.StartNew(() =>
                   {
                       var worker = workers.Take();
                       try
                       {
                           return worker.Execute(request);

                       }
                       finally
                       {
                           workers.Add(worker);
                       }
                   }));

               Console.WriteLine("Listening for messages. Hit <return> to quit");
               Console.ReadLine();
           }
        }
    }
}
