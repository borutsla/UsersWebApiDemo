## Getting Started

Follow these steps to get the project up and running:

### 1. Update Connection String

Before starting the application, update the connection string in the `appsettings.json` file. Open the file and find the `"ConnectionStrings"` section. Update the value of `"WebApiDatabase"` with your SQL Server connection string.

Example connection string:
```json
"ConnectionStrings": {
  "WebApiDatabase": "Server=localhost\\sqlexpress;Database=YourDatabaseName;Integrated Security=True;TrustServerCertificate=True;"
}