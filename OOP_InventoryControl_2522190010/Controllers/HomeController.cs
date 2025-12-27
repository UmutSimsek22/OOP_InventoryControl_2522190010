using Microsoft.AspNetCore.Mvc;
using OOP_InventoryControl_2522190010.Models; // Namespace'ine dikkat et

namespace OOP_InventoryControl_2522190010.Controllers;

public class HomeController : Controller
{
    // LİSTELEME + ARAMA + SIRALAMA + TOPLAM DEĞER
    public IActionResult Index(string searchString, string sortOrder)
    {
        var items = WarehouseData.Items;

        // 1. ARAMA ALGORİTMASI (Search)
        // Aranan kelime ürün adında veya kategorisinde var mı?
        if (!string.IsNullOrEmpty(searchString))
        {
            searchString = searchString.ToLower();
            items = items.Where(i => i.ProductDetails.Name.ToLower().Contains(searchString) 
                                  || i.ProductDetails.Category.ToLower().Contains(searchString)).ToList();
        }

        // 2. SIRALAMA ALGORİTMASI (Sort)
        switch (sortOrder)
        {
            case "qty_desc": // Miktara göre çoktan aza
                items = items.OrderByDescending(i => i.Quantity).ToList(); 
                break;
            case "date_asc": // SKT'ye göre yakından uzağa
                items = items.OrderBy(i => i.ExpirationDate).ToList(); 
                break;
            default: // Varsayılan: ID sırası
                items = items.OrderBy(i => i.Id).ToList(); 
                break;
        }

        // 3. TOPLAM DEĞER (Total Value)
        ViewBag.TotalValue = items.Sum(i => i.TotalValue);
        
        return View(items);
    }

    // EKLEME SAYFASI AÇMA (GET)
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    // EKLEME İŞLEMİ KAYDETME (POST)
    [HttpPost]
    public IActionResult Add(InventoryItem newItem)
    {
        // Otomatik ID atama
        newItem.Id = WarehouseData.Items.Any() ? WarehouseData.Items.Max(i => i.Id) + 1 : 1;
        
        // Listeye ekle
        WarehouseData.Items.Add(newItem);
        
        return RedirectToAction("Index");
    }

    // SİLME İŞLEMİ
    public IActionResult Delete(int id)
    {
        var item = WarehouseData.Items.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            WarehouseData.Items.Remove(item);
        }
        return RedirectToAction("Index");
    }
}