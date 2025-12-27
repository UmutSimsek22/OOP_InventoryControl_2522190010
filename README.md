# 📦 Inventory and Warehouse Control System (Assignment 16)

**Student ID:** 2522190010  
**Course:** Object Oriented Programming (OOP) Project  
**Platform:** ASP.NET Core MVC (.NET 8.0)

## 📖 Project Description
This project is an **Object-Oriented Inventory and Warehouse Control System** designed as part of Assignment 16. It simulates a real-world warehouse environment for a technology store ("TeknoStore"). The system allows tracking products, managing stock levels, and applying advanced algorithms for sales and restocking using **C#** and **ASP.NET Core MVC**.

## 🚀 Features by Stages

### Stage 1: Architecture Design
- **Composition over Inheritance:** The `InventoryItem` class is composed of `Product` and `Supplier` objects to minimize coupling.
- **Models:** Designed core classes (`Product`, `Supplier`, `InventoryItem`, `Order`) representing the warehouse domain.
- **In-Memory Database:** Implemented a static `WarehouseData` class to simulate persistent storage.

### Stage 2: Basic Implementation (CRUD)
- **Product Management:** Add, remove, and list inventory items.
- **Search Algorithm:** Filter products by *Name* or *Category* (Case-insensitive).
- **Sorting Algorithm:** Sort inventory by *Quantity* (Descending) or *Expiration Date* (Ascending).
- **Financial Calculation:** Dynamically computes the **Total Inventory Value**.

### Stage 3: Advanced Algorithms
- **FIFO (First-In-First-Out) Sales System:** Automatically deducts stock from the oldest batch (nearest Expiration Date) when a sale is made.
- **Smart Restock Recommendations:** Detects critical stock levels (< 10) and generates supplier-specific order suggestions.
- **Storage Optimization:** Automatically cleans up empty slots (Quantity = 0) to optimize warehouse space.

## 🛠 Technologies Used
- **C#** (Backend Logic)
- **ASP.NET Core MVC** (Web Framework)
- **HTML5 / Bootstrap 5** (Frontend Styling)
- **Git & GitHub** (Version Control)

## 📷 How to Run
1. Clone the repository.
2. Open the solution in **JetBrains Rider** or **Visual Studio**.
3. Select the `http` run configuration (to avoid SSL issues).
4. Run the project and navigate to the localhost URL.

---
*Developed by Umut Şimşek 2522190010 for the Fall 2024-2025 Semester.*
