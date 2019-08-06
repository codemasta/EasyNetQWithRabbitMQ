public interface IPayment
{
    decimal Amount { get; set; }
}

public class CardPayment : IPayment
{
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public string ExpiryDate { get; set; }

    public decimal Amount { get; set; }
}

public class PurchaseOrder
{
    public string PoNumber { get; set; }
    public string CompanyName { get; set; }
    public int PaymentDayTerms { get; set; }

    public decimal Amount { get; set; }
}