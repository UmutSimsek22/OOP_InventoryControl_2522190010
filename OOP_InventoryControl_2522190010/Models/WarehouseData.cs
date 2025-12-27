namespace OOP_InventoryControl_2522190010.Models;

public static class WarehouseData
{
    // Teknoloji Mağazası Örnek Verileri
    public static List<InventoryItem> Items = new List<InventoryItem>()
    {
        // 1. Ürün: Laptop
        new InventoryItem 
        { 
            Id = 1, 
            Quantity = 5, 
            ExpirationDate = DateTime.Now.AddYears(5), // Elektroniklerin SKT'si uzun olur
            ShelfLocation = "A-1 (Laptop Reyonu)",
            
            ProductDetails = new Product 
            { 
                ProductId = 101, 
                Name = "Gaming Laptop RTX 4060", 
                Category = "Bilgisayar", 
                Description = "Yüksek performanslı oyun bilgisayarı",
                BasePrice = 35000 
            },
            SupplierDetails = new Supplier 
            { 
                SupplierId = 50, 
                CompanyName = "MSI Türkiye", 
                Email = "satis@msi.com.tr" 
            }
        },

        // 2. Ürün: Ekran Kartı
        new InventoryItem 
        { 
            Id = 2, 
            Quantity = 12, 
            ExpirationDate = DateTime.Now.AddYears(3), 
            ShelfLocation = "B-2 (Bileşenler)",
            
            ProductDetails = new Product 
            { 
                ProductId = 205, 
                Name = "NVIDIA GeForce RTX 4090", 
                Category = "Ekran Kartı", 
                Description = "24GB VRAM profesyonel ekran kartı",
                BasePrice = 75000 
            },
            SupplierDetails = new Supplier 
            { 
                SupplierId = 51, 
                CompanyName = "NVIDIA Dist.", 
                Email = "support@nvidia.com" 
            }
        },

        // 3. Ürün: Oyuncu Monitörü
        new InventoryItem 
        { 
            Id = 3, 
            Quantity = 8, 
            ExpirationDate = DateTime.Now.AddYears(4), 
            ShelfLocation = "C-1 (Monitörler)",
            
            ProductDetails = new Product 
            { 
                ProductId = 301, 
                Name = "27' 165Hz IPS Monitör", 
                Category = "Çevre Birimleri", 
                Description = "1ms tepki süreli oyuncu monitörü",
                BasePrice = 8500.50 
            },
            SupplierDetails = new Supplier 
            { 
                SupplierId = 52, 
                CompanyName = "TeknoMarket", 
                Email = "b2b@teknomarket.com" 
            }
        }
    };
}