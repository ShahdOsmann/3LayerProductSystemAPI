# ASP.NETCore3LayerProductSystemAPI

🏢 ProductSystem API

🔷 **ASP.NET Core Web API – 3-Layer Architecture (Repository + Unit Of Work) (.NET 9)**

---

## 📌 Project Overview

**ProductSystem API** is a structured ASP.NET Core Web API application built using a professional multi-layered architecture.

The goal of this project is to demonstrate:

* ✅ Clean 3-Layer Architecture
* ✅ JWT Authentication 
* ✅ Repository Pattern
* ✅ Generic Repository
* ✅ Unit of Work Pattern
* ✅ Dependency Injection (DI)
* ✅ Inversion of Control (IoC)
* ✅ Dependency Inversion Principle (DIP)
* ✅ Separation of Concerns (SoC)
* ✅ ViewModel / DTO Pattern
* ✅ Entity Framework Core
* ✅ Fluent API Configuration
* ✅ Fluent Validation
* ✅ Async Programming
* ✅ Uploading Images
* ✅ Filtering for Products
* ✅ Pagination for Products
* ✅ Logging  
* ✅ API Versioning  
* ✅ CORS  
* ✅ Data Seeding
* ✅ Audit Logging

This architecture is scalable and suitable for enterprise-level business systems.

---

## 🏗 Architecture Overview

```
ProductSystem.API
│
├── ProductSystem.API       → Presentation Layer (API Controllers)
├── ProductSystem.BLL       → Business Logic Layer
└── ProductSystem.DAL       → Data Access Layer
```

### 🔁 Application Flow

```
Client Request (HTTP API)
      ↓
Controller (API)
      ↓
Manager (BLL)
      ↓
UnitOfWork (DAL)
      ↓
Repository (DAL)
      ↓
DbContext (EF Core)
      ↓
SQL Server
```

Each layer has a clear and strict responsibility.

---

## 🧩 Layers Explained

### 1️⃣ Presentation Layer – ProductSystem.API

**Contains:**

* API Controllers
* Program.cs (Dependency Injection setup)

**Responsibilities:**

* Handle HTTP Requests
* Validate incoming data
* Call Business Layer
* Return API Responses (JSON)
* Apply API Versioning, CORS, and Logging

**Important Rules:**

❌ No direct DbContext usage
❌ No business logic
❌ No repository instantiation with `new`
Controllers depend ONLY on BLL interfaces.

---

### 2️⃣ Business Logic Layer – ProductSystem.BLL

**Contains:**

* Managers Interfaces: `IProductManager`, `ICategoryManager`
* Managers Implementations: `ProductManager`, `CategoryManager`
* DTOs (Data Transfer Objects)
* Business Rules and Validations
* Coordination of UnitOfWork

**Responsibilities:**

* Business rules enforcement
* Data transformation
* Transaction control via UnitOfWork
* Validations using FluentValidation
* Async CRUD operations

**Rules:**

* Depend only on Repository Interfaces and UnitOfWork
* No direct EF Core logic

---

### 3️⃣ Data Access Layer – ProductSystem.DAL

**Contains:**

* DbContext
* Repository Interfaces
* Repository Implementations
* UnitOfWork

**Repositories:**

* `IGenericRepository` / `GenericRepository`
* `IProductRepository` / `ProductRepository`
* `ICategoryRepository` / `CategoryRepository`

**Responsibilities:**

* Add / Update / Delete / GetById / GetAll
* Any custom queries
* Track changes and save via UnitOfWork

**UnitOfWork:**

* `IUnitOfWork` / `UnitOfWork`
* Properties: `IProductRepository Products`, `ICategoryRepository Categories`
* Method: `SaveChangesAsync()`

---

## 🛠 Design Patterns Used

* ✅ Repository Pattern
* ✅ Generic Repository
* ✅ Unit of Work Pattern
* ✅ Dependency Injection (DI)
* ✅ Inversion of Control (IoC)
* ✅ Dependency Inversion Principle (DIP)
* ✅ Fluent Validation
* ✅ Async Programming
* ✅ DTO Pattern

---

## 🗄 Database Layer

**Database Provider:** SQL Server
**ORM:** Entity Framework Core

### 📦 Entities

**Category**
Relationship: One Category → Many Products

**Product**
Relationship: Many Products → One Category

---

## 🔎 Audit Logging

Implemented inside `AppDbContext`:

```csharp
foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
{
    if (entry.State == EntityState.Added)
        entry.Entity.CreatedAt = DateTime.UtcNow;

    if (entry.State == EntityState.Modified)
        entry.Entity.UpdatedAt = DateTime.UtcNow;
}
```

All auditable entities implement:

```csharp
public interface IAuditableEntity
{
    DateTime CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
}
```

---

## 🌱 Data Seeding

Seeded inside `OnModelCreating()`:

* Default Categories
* Default Products

---

## 📌 Features 

* View All Products (GET)
* View Product Details (GET)
* Create Product (POST)
* Assign Product to Category (PUT)
* Image Upload
* Filtering and Pagination

**Authentication & Authorization Features**

* User Registration
* User Login
* JWT-based Authentication
* Policy-Based Authorization
* Secure API endpoints
 

---

## 🚀 How To Run

1️⃣ **Configure Connection String** in `appsettings.json`:

```json
"ConnectionStrings": {
  "ProductSystem": "Server=.;Database=ProductSystemDB;Trusted_Connection=True;"
}
```

2️⃣ **Apply Migrations**

```bash
Add-Migration InitialCreate
Update-Database
```

3️⃣ **Run Application**

```bash
dotnet run
```

---

## 🧠 Architectural Principles Applied

* Separation of Concerns (SoC)
* Dependency Inversion Principle (DIP)
* Single Responsibility Principle (SRP)
* DRY Principle
* Layered Architecture
* Loose Coupling
* Clean Code Structure

---

## 🧪 Testing Strategy (Future)

* Mock `IUnitOfWork`
* Test Managers independently
* Use InMemory Database for integration tests

---

## 🏆 Project Level Assessment

This project demonstrates:

* Solid understanding of ASP.NET Core API
* Clean architecture thinking
* Proper pattern usage
* Enterprise-ready structure

---

## 👨‍💻 Author

**Shahd Osman**
Software Engineer
