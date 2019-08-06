namespace Request
{
    public class PurchaseOrder
    {
        public decimal Amount { get; set; }
        public string CompanyName { get; set; }
        public int PaymentDayTerms { get; set; }
        public string PoNumber { get; set; }
    }
}