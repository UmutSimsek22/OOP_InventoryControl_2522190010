namespace OOP_InventoryControl_2522190010.Models;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; } = "";
    public string Category { get; set; } = "";
    public string Description { get; set; } = "";
    public double BasePrice { get; set; }
}