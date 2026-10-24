namespace Part1_ProceduralToOOP.src;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    public int Stock { get; set; }

    public Product(int id, string name, double price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }


    public void ReduceStock(int quantity)
    {
        if(quantity < 0)
            throw new ArgumentException("Quantity must be positive.");

        if(Stock < quantity)
            throw new ArgumentException($"Not enough stock for product #{Id}");

        Stock -= quantity;
    }
}