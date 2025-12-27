using Microsoft.AspNetCore.Mvc;
using OOP_InventoryControl_2522190010.Models;

namespace OOP_InventoryControl_2522190010.Controllers;

public class HomeController : Controller
{
    
    public IActionResult Index(string searchString, string sortOrder)
    {
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
        
        var batches = WarehouseData.Items
            .Where(i => i.ProductDetails.Name.ToLower().Contains(pName.ToLower()) && i.Quantity > 0)
            .OrderBy(i => i.ExpirationDate) // ÖNEMLİ: Tarihe göre sırala (FIFO Mantığı)
            .ToList();

        if (!batches.Any()) 
        {
            return RedirectToAction("Index"); 
        }

        int remaining = qty;
        foreach (var batch in batches)
        {
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
        
        WarehouseData.Items.RemoveAll(i => i.Quantity == 0);

        return RedirectToAction("Index");
    }
}