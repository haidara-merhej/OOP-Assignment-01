using Part1_ProceduralToOOP.src;


Console.WriteLine("Procedural Order System (no classes / no structs)");
Console.WriteLine("Seed sample data, show a demo, then open the menu.");

OrderSystem orderSystem = new OrderSystem();
orderSystem.seedSampleData();
orderSystem.runDemoScenario();

orderSystem.PrintCustomers();
orderSystem.PrintProducts();
orderSystem.PrintOrders();

Console.WriteLine($"Fixed << setprecision(2)");
Console.WriteLine($"\nPaid sales total after demo: {orderSystem.TotalSalesPaidOnly():F2}\n");

orderSystem.runInteractiveMenu();