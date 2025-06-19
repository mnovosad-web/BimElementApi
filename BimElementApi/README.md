# BimElementApi

A simple ASP.NET Core Web API (.NET 9) that manages BIM elements (e.g., walls, doors) using in-memory storage. Built as a take-home test project with clean controller-based architecture, automatic status mapping, Swagger UI, and input validation.

---

## ✅ Features

- RESTful API with 4 endpoints
- Auto-calculates `Status` based on `ProgressPercent`
- In-memory data store (no DB)
- Input validation using `[Range]` attribute
- Clean MVC structure with `Controllers/`, `Models/`, `Dtos/`, `Repositories/`
- Interactive API testing via Swagger UI
- XML comments included for better Swagger documentation

---

## 🚀 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- IDE: JetBrains Rider (recommended), Visual Studio, or VS Code

---

### 🛠 Run the API

```bash
  dotnet run
```
  
Than open
```bash
http://localhost:5000/swagger
```

## 📡 API Endpoints

**➕ POST /api/elements**
Add a new BIM element.

Request body:
```json
{
  "ifcGuid": "wall-123",
  "elementType": "Wall",
  "progressPercent": 0,
  "status": ""
}
```
Response: 201 Created


**🔍 GET /api/elements/{ifcGuid}**
Fetch element by ID.

Example:
```bash
curl http://localhost:5000/api/elements/wall-123
```
Response:
  - 200 OK with element
  - 404 Not Found if not found

**📃 GET /api/elements**
Returns all stored elements.

Example:
```bash
curl http://localhost:5000/api/elements
```
Response: 200 OK with array of elements

**🔄 PUT /api/elements/{ifcGuid}/progress**
Update the progress of an element.

Request body:
```json
{
 "progressPercent": 99
}
```
Response:
  - 204 No Content if successful
  - 404 Not Found if element doesn’t exist
  - 400 Bad Request if invalid progress value

## 🧠 Status Auto-Mapping

| ProgressPercent | Status     |
| --------------- | ---------- |
| 0               | NotStarted |
| 1–99            | InProgress |
| 100             | Completed  |

## 🧱 Project Structure

```
BimElementApi/
├── Program.cs
├── BimElementApi.csproj
├── Controllers/
│   └── BimElementsController.cs
├── Models/
│   └── BimElement.cs
├── Dtos/
│   └── ProgressDto.cs
├── Repositories/
│   └── ElementStore.cs
└── README.md
```

## 🔗 Extra Tools
  - Swagger UI: http://localhost:5000/swagger
  - Run: dotnet run
  - Build: dotnet build
  - Restore: dotnet restore
















