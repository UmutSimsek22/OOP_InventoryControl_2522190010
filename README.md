# 📦 Inventory and Warehouse Control System (Assignment 16)

**Student ID:** 2522190010  
**Course:** Object Oriented Programming (OOP) Project  
**Platform:** ASP.NET Core MVC (.NET 8.0)

## 📖 Project Description
This project is an **Object-Oriented Inventory and Warehouse Control System** developed as a final assignment. It simulates a warehouse environment ("TeknoStore") with features like stock tracking, FIFO sales logic, and supplier management.

## 🚀 Features & Technical Details

### 1. Architecture & Design (Stage 1)
- **Composition over Inheritance:** `InventoryItem` class is composed of `Product` and `Supplier` objects.
- **In-Memory Database:** Uses a static `WarehouseData` class for data persistence during runtime.
- **UML Design:** Class structure adheres to OOP principles (Encapsulation, Composition).

### 2. Core Functionality (Stage 2)
- **CRUD Operations:** Add, List, and Delete inventory items.
- **Validation:** Server-side validation for required fields (Email format, Phone, etc.).
- **Localization:** System configured for **Turkish Lira (₺)** currency format.

### 3. Advanced Algorithms (Stage 3)
- **FIFO Sales System:** Automatically sells the items with the nearest expiration date first.
- **Stock Optimization:** Automatically removes items with 0 quantity from the warehouse.
- **Restock Reporting:** Generates alerts for critical stock levels (< 10 units).
- **Safety Checks:** Prevents selling more items than currently available in stock.

## ⚠️ Note on Versions
- This project is designed to be compatible with **.NET 6.0 and .NET 8.0**.
- If you are using **.NET 10**, please update the `<TargetFramework>` in the `.csproj` file accordingly.
- `global.json` has been removed to ensure the project runs with your local SDK version.

## 🛠 How to Run
1. Clone the repository.
2. Open the solution in **JetBrains Rider** or **Visual Studio**.
3. Select the `http` configuration.
4. Run the project and navigate to the localhost URL.

---
