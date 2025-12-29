# Dapper Basics – When, Why, and How

This repository documents the path I followed to learn what **Dapper** is, when to use it, how it compares with **Entity Framework Core**, and best practices to **optimize queries using Dapper**.
I covered those areas by creating simple CRUD API.

---

## 📌 What is Dapper?

Dapper is a **lightweight ORM (Object-Relational Mapper)** for .NET.  
It works as a **micro-ORM**, meaning:

- No change tracking
- No LINQ-to-SQL translation
- Minimal abstraction over raw SQL
- Very fast performance

Dapper maps SQL query results directly to C# objects.

---

## 📌 When to Use Dapper

Use Dapper when:

- Performance is critical
- You want full control over SQL queries
- You are working with complex joins or stored procedures
- You prefer SQL over LINQ
- Read-heavy applications (reports, dashboards)

Avoid Dapper when:

- You need automatic change tracking
- You want rapid CRUD development
- Your domain logic heavily relies on relationships and navigation properties

---

## 📌 How to Use Dapper (Basic Example)

```csharp
using Dapper;
using System.Data.SqlClient;

using var connection = new SqlConnection(connectionString);

var users = connection.Query<User>(
    "SELECT Id, Name, Email FROM Users WHERE IsActive = @IsActive",
    new { IsActive = true }
).ToList();
