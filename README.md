# 📦 Inventory and Warehouse Control System

**Student ID:** 2522190010
**Course:** Object Oriented Programming (OOP) Project
**Platform:** ASP.NET Core MVC (.NET 8.0)

## 📖 Project Description

This project is an **Object-Oriented Inventory and Warehouse Control System** built for a technology store ("TeknoStore"). It simulates a real-world warehouse environment, allowing products and suppliers to be tracked, stock levels managed, and advanced sales/restocking algorithms applied using **C#** and **ASP.NET Core MVC**.

## 🚀 Features & Technical Details

### 1. Architecture & Design

- **Composition over Inheritance:** `InventoryItem` is composed of `Product` and `Supplier` objects rather than relying on inheritance hierarchies.
- **In-Memory Database:** A static `WarehouseData` class handles data persistence during runtime.
- **UML Design:** Class structure follows core OOP principles (Encapsulation, Composition) — see diagram below.

### 2. Core Functionality

- **CRUD Operations:** Add, list, and delete inventory items.
- **Validation:** Server-side validation for required fields (email format, phone, etc.).
- **Localization:** Configured for Turkish Lira (₺) currency format.

### 3. Advanced Algorithms

- **FIFO Sales System:** Automatically sells items with the nearest expiration date first.
- **Stock Optimization:** Automatically removes items with 0 quantity from the warehouse.
- **Restock Reporting:** Generates alerts for critical stock levels (< 10 units).
- **Safety Checks:** Prevents selling more items than currently available in stock.

## 🛠 Technologies Used

- **C#** (Backend Logic)
- **ASP.NET Core MVC** (Web Framework)
- **HTML5 / Bootstrap 5** (Frontend Styling)
- **Git & GitHub** (Version Control)

## 🤖 Development Process

The system design, OOP architecture (composition, encapsulation), business logic, and all algorithms (FIFO sales, restocking, stock optimization) were designed and implemented independently. AI tools were used as a support resource for frontend styling (HTML/Bootstrap), with all decisions, planning, and implementation direction defined by the developer.

## ⚠️ Note on Versions

This project targets **.NET 8.0**. If running on a different SDK version, update the `<TargetFramework>` in the `.csproj` file accordingly.

## 📷 How to Run

1. Clone the repository.
2. Open the solution in **JetBrains Rider** or **Visual Studio**.
3. Select the `http` run configuration (to avoid SSL issues).
4. Run the project and navigate to the localhost URL.

## 📐 UML Diagram

<img width="1320" height="909" alt="umldiyagramı" src="https://github.com/user-attachments/assets/1cc946e1-619c-4fee-b005-7f02b8d306fc" />

---

*Developed by Umut Şimşek — 2522190010 — Fall 2024-2025 Semester.*
