namespace Part3_BuilderPattern.src;

public class Order
{
    public DateTime OrderDate { get; set; }
    public string? PaymentMethod { get; set; }
    public string Currency { get; set; } = null!;
    public decimal SubTotal { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TotalAmount => SubTotal - DiscountAmount + TaxAmount;

    public Order(DateTime orderDate, string paymentMethod, string currency, decimal subTotal, 
        decimal discountAmount, decimal taxAmount)
    {
        OrderDate = orderDate;
        PaymentMethod = paymentMethod;
        Currency = currency;
        SubTotal = subTotal;
        DiscountAmount = discountAmount;
        TaxAmount = taxAmount;
    }
}