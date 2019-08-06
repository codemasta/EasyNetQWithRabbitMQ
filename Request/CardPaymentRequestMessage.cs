namespace Request
{
    public class CardPaymentRequestMessage
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }
        public decimal Amount { get; set; }
        public override string ToString()
        {
            return "Payment = <" + CardNumber + "," + CardHolderName + "," + ExpiryDate + "," + Amount + ">";
        }
    }
}