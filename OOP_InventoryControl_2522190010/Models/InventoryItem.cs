namespace OOP_InventoryControl_2522190010.Models;

public class InventoryItem
{
    public int Id { get; set; } // Stok Takip ID
    
    public Product ProductDetails { get; set; } = new Product();
    public Supplier SupplierDetails { get; set; } = new Supplier();

    public int Quantity { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string ShelfLocation { get; set; } = "";
    
    public double TotalValue => Quantity * ProductDetails.BasePrice;
}