namespace Part1_ProceduralToOOP.src;

public class OrderLine
{
    public Product Product { get; set; }
    public int Quantity { get; set; }

    public OrderLine(Product product, int quantiy)
    {
        Product = product;
        Quantity = quantiy;
    }

    public double CalculateOrderLine()
    {
        return Product.Price * Quantity;
    }
    
}