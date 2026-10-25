namespace Part3_BuilderPattern.src;

public class InvoiceBuilder
{
  private readonly int _invoiceId;
  private readonly string _customerName;
  private string? _customerEmail;
  private string? _customerPhone;
  private Address? _billingAddress;
  private  Address? _shippingAddress;
  private readonly Order _order;

  public InvoiceBuilder(int invoiceId, string customerName, Order order)
  {
    _invoiceId = invoiceId;
    _customerName = customerName;
    _order = order;
  }

  public InvoiceBuilder WithCustomerEmail(string customerEmail)
  {
    _customerEmail = customerEmail;
    return this;
  }

  public InvoiceBuilder WithCustomerPhone(string customerPhone)
  {
    _customerPhone = customerPhone;
    return this;
  }

  public InvoiceBuilder WithBillingAddress(Address billingAddress)
  {
    _billingAddress = billingAddress;
    return this;
  }
  
  public InvoiceBuilder WithShippingAddress(Address shippingAddress)
  {
    _shippingAddress = shippingAddress;
    return this;
  }


  public Invoice Build()
  {
    if(_invoiceId <= 0)
    {
      throw new InvalidOperationException("InvoiceId must be greater than zero.");
    }

    if(string.IsNullOrWhiteSpace(_customerName))
    {
      throw new InvalidOperationException("CustomerName is required.");
    }

    if(_order == null)
    {
      throw new InvalidOperationException("Order is required.");
    }

    return new Invoice(_invoiceId, _customerName, _customerEmail, _customerPhone, _shippingAddress,
     _billingAddress, _order);
  }
}