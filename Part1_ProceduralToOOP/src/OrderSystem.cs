namespace Part1_ProceduralToOOP.src;

public class OrderSystem
{
    private readonly List<Customer> _customers = [];
    private readonly List<Product> _products = [];
    private readonly List<Order> _orders = [];

    public void AddCustomer(Customer customer)
    {
        if(customer is null)
            throw new ArgumentNullException(nameof(customer));

        if(FindCustomerById(customer.Id) != null)
            throw new InvalidOperationException($"Customer with id #{customer.Id} already exists.");
        _customers.Add(customer);

    }

    private Customer? FindCustomerById(int customerId)
    {
        foreach(var customer in _customers)
        {
            if(customer.Id == customerId)
                return customer;
        }

        return null;
    }

    public void AddProduct(Product product)
    {
        if(product is null)
            throw new ArgumentNullException(nameof(product));

        if(FindProductById(product.Id) != null)
            throw new InvalidOperationException($"Product with id #{product.Id} already exists.");

        _products.Add(product);
    }
    private Product? FindProductById(int productId)
    {
        foreach(var product in _products)
        {
            if(product.Id == productId)
                return product;
        }

        return null;
    }

    
    public void CreateOrder(int orderId, Customer customer, DateTime date)
    {
        if(FindOrderById(orderId) != null)
            throw new InvalidOperationException($"Order with id #{orderId} already exists.");
        var order = new Order(orderId, customer, date);

        _orders.Add(order);
    }

    private Order? FindOrderById(int orderId)
    {
        foreach(var order in _orders)
        {
            if(order.OrderId == orderId)
                return order;
        }

        return null;
    }

    public void MarkOrderPaid(int orderId)
    {
        var order = FindOrderById(orderId);

        if(order is null)
            throw new ArgumentException($"No Order with id #{orderId} found.");

        order.MarkOrderPaid();
    }

    public double TotalSalesPaidOnly()
    {
        double totalSales = 0;
        foreach(var order in _orders)
        {
            totalSales += order.CalculateOrderTotal();         
        }

        return totalSales;
    }

    public void AddLineToOrder(int orderId, int productId, int quantity)
    {
        var order = FindOrderById(orderId);

        if(order is null)
            throw new ArgumentException($"No order with id #{orderId} found.");

        Product? product = FindProductById(productId);

        if(product is null)
            throw new ArgumentException($"No product with id #{productId} found.");

        product.ReduceStock(quantity);

        OrderLine orderLine = new OrderLine(product, quantity);
        order.AddOrderLine(orderLine);
    }
    
    public void PrintCustomers()
    {
        Console.WriteLine($"=== CUSTOMERS {( _customers.Count )} ===\n");

        foreach(var customer in _customers)
        {
            string vip = customer.IsVip ? "Yes" : "No";
            Console.WriteLine($"#{customer.Id}, {customer.Name}, {customer.Email}, {customer.City}, vip: {vip}");
        }
    }

    public void PrintProducts()
    {

        Console.WriteLine($"=== PRODUCTS {( _products.Count )} ===\n");

        foreach(var product in _products)
        {
            Console.WriteLine($"#{product.Id}, {product.Name}, price: {product.Price}, stock: {product.Stock}");
        }
    }

    public void PrintOrders()
    {
        Console.WriteLine($"=== ORDERS {( _orders.Count )} ===\n");

        foreach(var order in _orders)
        {
            PrintOrder(order.OrderId);
        }
    }

    private void CreateOrderInteractive()
    {
        int orderId, customerId;
        DateTime date;
        Console.Write("Order id: ");
        orderId = int.Parse(Console.ReadLine()!);
        Console.Write("Customer id: ");
        customerId = int.Parse(Console.ReadLine()!);
        Customer? customer = FindCustomerById(customerId);
        Console.Write("Date (YYYY-MM-DD): ");
        date = DateTime.Parse(Console.ReadLine()!);

        if(customer is null)
            throw new InvalidOperationException($"No customer with id #{customerId} found.");

        CreateOrder(orderId, customer, date);
    }
    
    private void AddLineToOrderInteractive()
    {
        int orderId, productId, quantity;
        Console.Write("Order id: ");
        orderId = int.Parse(Console.ReadLine()!);
        Console.Write("Product id: ");
        productId = int.Parse(Console.ReadLine()!);
        Console.Write("Quantity: ");
        quantity = int.Parse(Console.ReadLine()!);

        AddLineToOrder(orderId, productId, quantity);
    }

    public void PrintOrder(int orderId)
    {
        var order = FindOrderById(orderId);

        if(order is null)
            throw new InvalidOperationException($"Order with id #{orderId} not found.");

        var paid = order.IsPaid ? "Yes" : "No";
        Console.WriteLine($"#{order.OrderId}, Date: {order.Date}, Customer: {order.Customer.Name}, Paid: {paid}");

        Console.WriteLine("Lines:\n");  
        foreach(OrderLine orderLine in order.OrderLines)
        {
            Console.WriteLine($" -{orderLine.Product.Name}, x{orderLine.Quantity}, @{orderLine.Product.Price}");
            Console.WriteLine($" ={orderLine.CalculateOrderLine()}");
        }

        Console.WriteLine($"\nTotal: {order.CalculateOrderTotal()}");
    }

    public void seedSampleData()
    {
        AddCustomer(new Customer(1, "Mona Ali", "mona@example.com", "Cairo", true));
        AddCustomer(new Customer(2, "Omar Hassan", "omar@example.com", "Alexandria", false));
        AddCustomer(new Customer(3, "Sara Nabil", "sara@example.com", "Giza", false));

        AddProduct(new Product(101, "USB Cable", 50.0, 100));
        AddProduct(new Product(102, "Wireless Mouse", 250.0, 40));
        AddProduct(new Product(103, "Mechanical Keyboard", 1200.0, 15));
        AddProduct(new Product(104, "Laptop Stand", 400.0, 25));
    }

    public void runDemoScenario()
    {
        var customer1 = FindCustomerById(1);
        CreateOrder(1001, customer1!, new DateTime(2026, 9, 15));
        AddLineToOrder(1001, 101, 2);
        AddLineToOrder(1001, 102, 1);
        MarkOrderPaid(1001);

        var customer2 = FindCustomerById(2);
        CreateOrder(1002, customer2!, new DateTime(2026, 9, 15));
        AddLineToOrder(1002, 103, 1);
        AddLineToOrder(1002, 104, 1);

        var customer3 = FindCustomerById(3);
        CreateOrder(1003, customer3!, new DateTime(2026, 9, 16));
        AddLineToOrder(1003, 101, 5);
        MarkOrderPaid(1003);
    }

    public void PrintMenu()
    {
        Console.WriteLine("\n---------- MENU ----------\n");
        Console.WriteLine("1) Print customers\n");
        Console.WriteLine("2) Print products\n");
        Console.WriteLine("3) Print all orders\n");
        Console.WriteLine("4) Print one order by id\n");
        Console.WriteLine("5) Create order\n");
        Console.WriteLine("6) Add line to order\n");
        Console.WriteLine("7) Mark order paid\n");
        Console.WriteLine("8) Show paid sales total\n");
        Console.WriteLine("0) Exit\n");
        Console.WriteLine("Choice: ");
    }

    public void runInteractiveMenu()
    {
        int choice = -1;
        while (choice != 0)
        {
            PrintMenu();
            choice = int.Parse(Console.ReadLine()!);

            if (choice == 1)
            {
                PrintCustomers();
            }
            else if (choice == 2)
            {
                PrintProducts();
            }
            else if (choice == 3)
            {
                PrintOrders();
            }
            else if (choice == 4)
            {
                try
                {
                    int orderId;
                    Console.Write("Order id: ");
                    orderId = int.Parse(Console.ReadLine()!);
                    PrintOrder(orderId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else if (choice == 5)
            {
                try
                {
                    CreateOrderInteractive();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else if (choice == 6)
            {
                try
                {
                    AddLineToOrderInteractive();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else if (choice == 7)
            {
                try
                {
                    int orderId;
                    Console.Write("Order id: ");
                    orderId = int.Parse(Console.ReadLine()!);
                    MarkOrderPaid(orderId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else if (choice == 8)
            {
                Console.WriteLine($"Paid sales total: {TotalSalesPaidOnly():F2}");
            }
            else if (choice == 0)
            {
                Console.WriteLine("Bye.");
            }
            else
            {
                Console.WriteLine("Unknown choice.");
            }
        }
    }
}