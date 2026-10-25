namespace Part3_BuilderPattern.src;

public class OrderBuilder
{
    private readonly DateTime _orderDate;
    private readonly string _currency;
    private readonly decimal _subTotal;
    private string? _paymentMethod;
    private decimal _discountAmount;
    private decimal _taxAmount;

    public OrderBuilder(DateTime orderDate, string currency, decimal subTotal)
    {
        _orderDate = orderDate;
        _currency = currency;
        _subTotal = subTotal;
    }

    public OrderBuilder WithPaymentMethod(string paymentMethod)
    {
        _paymentMethod = paymentMethod;
        return this;
    }

    public OrderBuilder WithDiscountAmount(decimal discountAmount)
    {
        _discountAmount = discountAmount;
        return this;
    }

    public OrderBuilder WithTaxAmount(decimal taxAmount)
    {
        _taxAmount = taxAmount;
        return this;
    }

    public Order Build()
    {
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

        return new Order(_orderDate, _paymentMethod, _currency, _subTotal, _discountAmount, _taxAmount);
    }

}