using Part3_BuilderPattern.src;

Invoice invoice = new InvoiceBuilder(1, "John Doe", DateTime.Now, "USD", 100.00m)
    .WithCustomerEmail("john.doe@example.com")
    .WithPaymentMethod("Credit Card")
    .WithDiscountAmount(10.00m)
    .WithTaxAmount(8.00m)
    .Build();


Console.WriteLine($"Invoice ID: {invoice.InvoiceId}");
Console.WriteLine($"Customer Name: {invoice.CustomerName}");
Console.WriteLine($"Customer Email: {invoice.CustomerEmail}");
Console.WriteLine($"Order Date: {invoice.OrderDate}");
Console.WriteLine($"Currency: {invoice.Currency}");
Console.WriteLine($"SubTotal: {invoice.SubTotal}");
Console.WriteLine($"Payment Method: {invoice.PaymentMethod}");
Console.WriteLine($"Discount Amount: {invoice.DiscountAmount}");
Console.WriteLine($"Tax Amount: {invoice.TaxAmount}");
Console.WriteLine($"Total Amount: {invoice.TotalAmount}");