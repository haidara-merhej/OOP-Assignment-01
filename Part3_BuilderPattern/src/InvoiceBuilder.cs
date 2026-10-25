namespace Part3_BuilderPattern.src;

public class InvoiceBuilder
{
  private readonly int _invoiceId;
  private readonly string _customerName;
  private string? _customerEmail;
  private string? _customerPhone;
  private string? _billingStreet;
  private string? _billingCity;
  private  string? _billingState;
  private  string? _billingZipCode;
  private  string? _billingCountry;
  private  string? _shippingStreet;
  private  string? _shippingCity;
  private  string? _shippingState;
  private  string? _shippingZipCode;
  private  string? _shippingCountry;
  private readonly DateTime _orderDate;
  private string _paymentMethod;
  private readonly string _currency;
  private readonly decimal _subTotal;
  private decimal _discountAmount;
  private decimal _taxAmount;

  public InvoiceBuilder(int invoiceId, string customerName, DateTime orderDate, string currency, decimal subTotal)
  {
    _invoiceId = invoiceId;
    _customerName = customerName;
    _orderDate = orderDate;
    _currency = currency;
    _subTotal = subTotal;
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

  public InvoiceBuilder WithBillingStreet(string billingStreet)
  {
    _billingStreet = billingStreet;
    return this;
  }
  public InvoiceBuilder WithBillingCity(string billingCity)
  {
    _billingCity = billingCity;
    return this;
  }
  public InvoiceBuilder WithBillingState(string billingState)
  {
    _billingState = billingState;
    return this;
  }
  public InvoiceBuilder WithBillingZipCode(string billingZipCode)
  {
    _billingZipCode = billingZipCode;
    return this;
  }
  public InvoiceBuilder WithBillingCountry(string billingCountry)
  {
    _billingCountry = billingCountry;
    return this;
  }
  public InvoiceBuilder WithShippingStreet(string shippingStreet)
  {
    _shippingStreet = shippingStreet;
    return this;
  }
  public InvoiceBuilder WithShippingCity(string shippingCity)
  {
    _shippingCity = shippingCity;
    return this;
  }
  public InvoiceBuilder WithShippingState(string shippingState)
  {
    _shippingState = shippingState;
    return this;
  }
  public InvoiceBuilder WithShippingZipCode(string shippingZipCode)
  {
    _shippingZipCode = shippingZipCode;
    return this;
  }
  public InvoiceBuilder WithShippingCountry(string shippingCountry)
  {
    _shippingCountry = shippingCountry;
    return this;
  }


  public InvoiceBuilder WithPaymentMethod(string paymentMethod)
  {
    _paymentMethod = paymentMethod;
    return this;
  }

  public InvoiceBuilder WithDiscountAmount(decimal discountAmount)
  {
    _discountAmount = discountAmount;
    return this;
  }

  public InvoiceBuilder WithTaxAmount(decimal taxAmount)
  {
    _taxAmount = taxAmount;
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

    if(string.IsNullOrWhiteSpace(_paymentMethod))
    {
      throw new InvalidOperationException("PaymentMethod is required.");
    }

    if(string.IsNullOrWhiteSpace(_currency))
    {
      throw new InvalidOperationException("Currency is required.");
    }

    if(_subTotal < 0)
    {
      throw new InvalidOperationException("SubTotal cannot be negative.");
    }

    if(_discountAmount < 0)
    {
      throw new InvalidOperationException("DiscountAmount cannot be negative.");
    }

    if(_taxAmount < 0)
    {
      throw new InvalidOperationException("TaxAmount cannot be negative.");
    }



    return new Invoice(_invoiceId, _customerName, _customerEmail, _customerPhone, _billingStreet, _billingCity,
     _billingState, _billingZipCode, _billingCountry, _shippingStreet, _shippingCity, _shippingState, _shippingZipCode,
      _shippingCountry, _orderDate, _paymentMethod, _currency, _subTotal, _discountAmount, _taxAmount);
  }
}