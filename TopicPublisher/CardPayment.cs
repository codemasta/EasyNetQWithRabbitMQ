namespace TopicPublisher
{
    public class CardPayment : IPayment
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }

        public decimal Amount { get; set; }
    }
}