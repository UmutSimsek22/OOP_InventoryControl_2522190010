namespace OOP_InventoryControl_2522190010.Models;

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = "Pending";
    public string ProductOrdered { get; set; } = ""; // Hangi üründen istendi
    public int Amount { get; set; }
}