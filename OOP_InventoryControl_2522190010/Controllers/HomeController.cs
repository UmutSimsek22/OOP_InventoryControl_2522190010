using Microsoft.AspNetCore.Mvc;
using OOP_InventoryControl_2522190010.Models;

namespace OOP_InventoryControl_2522190010.Controllers;

public class HomeController : Controller
{
    public IActionResult Index(string searchString, string sortOrder)
    {
    /*
     Bu aşamadan ise kullanıcının aradığı ürünü daha kolay bulması için LINQ sorguları
     ile sıralama algoritması ekledim.
     Where ve OrderBy komutları sayesinde binlerce ürün olmasına rağmen 
     anında arama ve sıralama yapılabilir
     */
        var items = WarehouseData.Items;

        if (!string.IsNullOrEmpty(searchString))
        {
            searchString = searchString.ToLower();
            items = items.Where(i => i.ProductDetails.Name.ToLower().Contains(searchString) 
                                  || i.ProductDetails.Category.ToLower().Contains(searchString)).ToList();
        }

        switch (sortOrder) 
        {
            case "qty_desc": items = items.OrderByDescending(i => i.Quantity).ToList(); break;
            case "date_asc": items = items.OrderBy(i => i.ExpirationDate).ToList(); break;
            default: items = items.OrderBy(i => i.Id).ToList(); break;
        }

        ViewBag.TotalValue = items.Sum(i => i.TotalValue);
        return View(items);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Add(InventoryItem newItem)
    {
        if (!ModelState.IsValid) //Veri bütünlüğü için Server-side validation kullandığım için
                                 //burada kullanıcının stoğu veya e-postayı yanlış girmesi
                                 //durumunda hata vermesini sağlayan ve hatalı ürünün eklenmesini
                                 //engelleyen kod bloğumuz bulunmakta
        {
            return View(newItem);
        }

        newItem.Id = WarehouseData.Items.Any() ? WarehouseData.Items.Max(i => i.Id) + 1 : 1;
        WarehouseData.Items.Add(newItem);  
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var item = WarehouseData.Items.FirstOrDefault(i => i.Id == id);
        if (item != null) WarehouseData.Items.Remove(item);
        return RedirectToAction("Index");
    }
    
    public IActionResult RestockReport()
    {
        var criticalItems = WarehouseData.Items.Where(i => i.Quantity < 10).ToList();
        return View(criticalItems);
    }

    public IActionResult Optimize()
    {
        WarehouseData.Items.RemoveAll(i => i.Quantity == 0);
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult SellFIFO(string pName, int qty)
    {
    /*
     En teknik kısım bence burası, stok düşme işlemi yerine; FIFO(first in first out) kullandım
     */
        var batches = WarehouseData.Items
            .Where(i => i.ProductDetails.Name.ToLower().Contains(pName.ToLower()) && i.Quantity > 0)
            .OrderBy(i => i.ExpirationDate)
            .ToList();   //Son kullanma tarihi en yakın olanları getiriyorum

        int totalStock = batches.Sum(x => x.Quantity);
        
        // Yetersiz Stok Kontrolü
        if (totalStock < qty)
        {
        /*
         Burada satılmak istenen miktardan yeteri kadar var mı kontrolü yapılıyor 
         */
            TempData["Error"] = $"Yetersiz Stok! İstenen: {qty}, Mevcut: {totalStock}";
            return RedirectToAction("Index");
        }

        int remaining = qty;
        foreach (var batch in batches)
        {
        /*
         Burada ise satılmak istenen ürünü son kullanma tarihi en yakın üründen başlayacak 
         şekilde satmaya başlıyoruz
         */
            if (remaining <= 0) break;

            if (batch.Quantity >= remaining)
            {
                batch.Quantity -= remaining;
                remaining = 0;
            }
            else
            {
                remaining -= batch.Quantity;
                batch.Quantity = 0;
            }
        }
        //Optimizasyon için biten ürünlerin silinmesini sağlıyoruz 
        WarehouseData.Items.RemoveAll(i => i.Quantity == 0);

        TempData["Success"] = "Satış başarıyla tamamlandı.";
        return RedirectToAction("Index");
    }
}