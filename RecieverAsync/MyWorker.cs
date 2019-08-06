using System;
using Request;

namespace RecieverAsync
{
    public class MyWorker  // class called when message is recieved on the queue
    {
        public CardPaymentResponseMessage Execute(CardPaymentRequestMessage request)
        {
            CardPaymentResponseMessage responseMessage = new CardPaymentResponseMessage();
            responseMessage.AuthCode = "1234";
            Console.WriteLine("Worker activated to process response");
            return responseMessage;
        }
    }
}