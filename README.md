# 📚 Personal Book Library

A full-stack application to manage your personal collection of books you own, love, or want to read.  
Supports search by **Author**, **ISBN**, and **Ownership Status**.

---

## 🔧 Tech Stack

- **Frontend**: React (TypeScript), MUI (Material UI)
- **Backend**: .NET 9 Minimal API, Entity Framework Core
- **Database**: SQL Server
- **Testing**: xUnit, Moq
- **Tooling**: REST Client `.http` files

---

## 🚀 Getting Started

### 1. 🖥️ Backend Setup (.NET 9)

#### Prerequisites:
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB or full instance)

#### 🔧 Configuration

Update `appsettings.Development.json` or use environment variables:

```json
"ConnectionStrings": {
  "BLDbConnection": "Server=.;Database=PersonalBookLibrary;Trusted_Connection=True;"
}
```

### 🔐 Secrets Handling 

Use `.env`, environment variables, or `dotnet user-secrets`:

```bash
dotnet user-secrets set "bl_db_user" "myuser"
dotnet user-secrets set "bl_db_pass" "mypassword"
```

### 🏃 Run the API

```bash
cd BookLibrary.API
dotnet run
```

API runs at: `https://localhost:7018`


### 📬 API Endpoints

- `POST /api/books` – Add a new book
- `GET /api/books/search?author=&isbn=&ownershipStatus=&page=1&pageSize=10` – Search books

---

## 💻 Frontend Setup (React + TypeScript)

### Prerequisites:
- Node.js (18+ recommended)
- npm or yarn

### 🔧 Install & Run

```bash
cd frontend
npm install
npm run dev
```

App runs at: `http://localhost:5173`


## ✅ Testing

### Backend Unit Tests

```bash
cd BookLibrary.Tests
dotnet test
```

Tests:
- `BookService.SearchAsync`
- `BookService.AddAsync`
