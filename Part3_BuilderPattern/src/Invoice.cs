namespace Part3_BuilderPattern.src;

public class Invoice
{ 
  public int InvoiceId { get; set; }
  public string CustomerName { get; set; }
  public string? CustomerEmail { get; set; }
  public string? CustomerPhone { get; set; }
  public Address? ShippingAddress {get; set;}
  public Address? BillingAddress { get; set; }
  public Order Order { get; set; }
  
  public Invoice(int invoiceId, string customerName, string? customerEmail, string? customerPhone, 
  Address? shippingAddress, Address? billingAddress, Order order)
  {
    InvoiceId = invoiceId;
    CustomerName = customerName;
    CustomerEmail = customerEmail;
    CustomerPhone = customerPhone;
    ShippingAddress = shippingAddress;
    BillingAddress = billingAddress;
    Order = order;
  }
}