# MsSqlConnectionStringTester

A lightweight Windows Forms utility for testing MS SQL Server connection strings — by hand or in bulk from an `appsettings.json` file — and running ad-hoc queries directly from the UI.

[![Screenshot](docs/screenshots/success.png)](docs/screenshots/success.png)

## Requirements

- Windows
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

## Build & Run

```bash
cd SQLConnCheck
dotnet run
```

Or build a self-contained executable:

```bash
dotnet publish -c Release -r win-x64 --self-contained
```

## Features

### Manual connection test

Paste any MS SQL Server connection string into the **Connection String** box and click **Test Connection**. The result appears immediately below.

```
Data Source=.\SQLEXPRESS;Initial Catalog=MyDB;User ID=sa;Password=secret;
```

### Batch test from appsettings.json

Click **Browse appsettings.json**, select a file, then click **Test All**. Every entry under the `"ConnectionStrings"` section is tested in sequence; a live summary updates as each result arrives.

```json
{
  "ConnectionStrings": {
    "Default":    "Server=localhost;Database=App;Trusted_Connection=True;",
    "Reporting":  "Server=rep-srv;Database=Reports;User Id=sa;Password=pass;"
  }
}
```

### Execute Query

Type any SQL in the **Query** box and click **Execute Query**. Results are rendered as plain text with a pipe-separated header row, a separator line, and a row count at the bottom — no connection to a separate database tool required.

```
Id  |  Name  |  CreatedAt
--------------------------
1   |  Alice  |  2024-01-15
2   |  Bob    |  2024-03-22
(2 row(s) returned)
```

## Result colors

| Color | Meaning |
|-------|---------|
| Dark green | Connection succeeded |
| Dark red | Connection failed (error detail shown) |
