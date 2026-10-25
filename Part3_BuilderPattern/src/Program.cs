using Part3_BuilderPattern.src;

Order order = new OrderBuilder(DateTime.Now, "USD", 100.00m)
    .WithPaymentMethod("Credit Card")
    .WithDiscountAmount(10.00m)
    .WithTaxAmount(8.00m)
    .Build();

Address shippingAddress = new AddressBuilder("123 Main St", city: "New York", country: "USA")
    .WithState("NY")
    .WithZip("10001")
    .Build();

Address billingAddress = new AddressBuilder("456 Oak Ave", city: "Los Angeles", country: "USA")
    .WithState("CA")
    .WithZip("90210")
    .Build();

Invoice invoice = new InvoiceBuilder(1, "John Doe", order)
    .WithCustomerEmail("john.doe@example.com")
    .WithShippingAddress(shippingAddress)
    .WithBillingAddress(billingAddress)
    .Build();


Console.WriteLine($"Invoice ID: {invoice.InvoiceId}");
Console.WriteLine($"Customer Name: {invoice.CustomerName}");
Console.WriteLine($"Customer Email: {invoice.CustomerEmail}");
Console.WriteLine($"Shipping Address: {invoice.ShippingAddress?.Street}, {invoice.ShippingAddress?.City}, {invoice.ShippingAddress?.State}, {invoice.ShippingAddress?.ZipCode}, {invoice.ShippingAddress?.Country}");
Console.WriteLine($"Billing Address: {invoice.BillingAddress?.Street}, {invoice.BillingAddress?.City}, {invoice.BillingAddress?.State}, {invoice.BillingAddress?.ZipCode}, {invoice.BillingAddress?.Country}");
Console.WriteLine($"Order Date: {invoice.Order.OrderDate}");
Console.WriteLine($"Currency: {invoice.Order.Currency}");
Console.WriteLine($"SubTotal: {invoice.Order.SubTotal}");
Console.WriteLine($"Payment Method: {invoice.Order.PaymentMethod}");
Console.WriteLine($"Discount Amount: {invoice.Order.DiscountAmount}");
Console.WriteLine($"Tax Amount: {invoice.Order.TaxAmount}");
Console.WriteLine($"Total Amount: {invoice.Order.TotalAmount}");