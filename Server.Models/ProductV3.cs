namespace Server.Models;

public class ProductV3
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public decimal Discount { get; set; }
    public decimal FinalPrice { get; set; }
}