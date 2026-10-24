namespace Part1_ProceduralToOOP.src;

public class Order
{   
    private readonly List<OrderLine> _orderLines = [];
    public int OrderId { get; set; }
    public Customer Customer { get; set; }
    public DateTime Date { get; set; }
    public bool IsPaid { get; set; }
    

    public List<OrderLine> OrderLines => _orderLines;

    public Order(int orderId, Customer customer, DateTime date)
    {
        OrderId = orderId;
        Customer = customer;
        Date = date;
        IsPaid = false;

    }

    public void AddOrderLine(OrderLine orderLine)
    {
        _orderLines.Add(orderLine);
    }

    public double CalculateOrderTotal()
    {
        double total = 0;
        foreach(var orderLine in _orderLines)
        {
            total += orderLine.CalculateOrderLine();
        }

        return total;
    }


    public void MarkOrderPaid()
    {
        if(IsPaid)
            throw new InvalidOperationException("This order already paid.");

        IsPaid = true;
    }
}