namespace OOP_InventoryControl_2522190010.Models;

public static class WarehouseData
{
    public static List<InventoryItem> Items = new List<InventoryItem>()
    {
        new InventoryItem 
        { 
            Id = 1, 
            Quantity = 10, 
            ExpirationDate = DateTime.Now.AddYears(2), 
            ShelfLocation = "A-1",
           
            ProductDetails = new Product { ProductId=101, Name="Laptop", Category="Elektronik", BasePrice=15000 },
            SupplierDetails = new Supplier { SupplierId=50, CompanyName="TechStore", Email="info@tech.com" }
        },
        new InventoryItem 
        { 
            Id = 2, 
            Quantity = 50, 
            ExpirationDate = DateTime.Now.AddDays(10), 
            ShelfLocation = "C-3",
            ProductDetails = new Product { ProductId=102, Name="Süt", Category="Gıda", BasePrice=25 },
            SupplierDetails = new Supplier { SupplierId=51, CompanyName="Çiftlik A.Ş.", Email="sut@ciftlik.com" }
        }
    };
}