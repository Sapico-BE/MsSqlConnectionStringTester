# MsSqlConnectionStringTester

A lightweight Windows Forms utility for testing MS SQL Server connection strings.

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

## Usage

### Manual test

Paste any MS SQL Server connection string into the text box and click **Test Connection**. The result appears immediately below.

Example connection string:

```
Data Source=.\SQLEXPRESS;Initial Catalog=MyDB;User ID=sa;Password=secret;
```

### File test

Click **Browse appsettings.json**, select a file, then click **Test All**. Every entry under the `"ConnectionStrings"` section is tested and the results are shown in the grid.

Example `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "Default": "Server=localhost;Database=App;Trusted_Connection=True;",
    "Reporting": "Server=rep-srv;Database=Reports;User Id=sa;Password=pass;"
  }
}
```

## Result colors

| Color | Meaning |
|-------|---------|
| Dark green | Connection succeeded |
| Dark red | Connection failed (error detail shown) |
