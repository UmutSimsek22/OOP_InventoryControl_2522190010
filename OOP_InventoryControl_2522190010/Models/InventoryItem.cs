namespace OOP_InventoryControl_2522190010.Models;

public class InventoryItem
{
    public int Id { get; set; } // Stok Takip ID
    
    public Product ProductDetails { get; set; } = new Product();
    public Supplier SupplierDetails { get; set; } = new Supplier();

/*
 
 InventoryItem sınıfını Product sınıfından inherit (türetmek) yerine
 Product ve Supplier gibi nesnelerin bu sınıfın içine birer property (özellik)
 olacak şekilde tanımladım çünkü; stok kaydı sadece ürüne değil aynı zamanda tedarikçiye de sahip
 Bu sayede ürünün özellikleri değişmeden stoklarını yönetebiliyordum  
 
 Gevşek bağlılık sağladı
has-a ve is-a 
 */

    public int Quantity { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string ShelfLocation { get; set; } = "";
    
    public double TotalValue => Quantity * ProductDetails.BasePrice;
}