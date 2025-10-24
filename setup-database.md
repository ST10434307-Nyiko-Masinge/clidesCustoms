# Database Setup Instructions

## Prerequisites
- .NET 9.0 SDK installed
- No additional database software required!

## In-Memory Database Setup

The application now uses an **in-memory database** which means:
- ✅ No database installation required
- ✅ No connection strings to configure
- ✅ No migrations to run
- ✅ Data is automatically seeded on startup
- ✅ Perfect for development and testing

## Steps to Run the Application

1. **Restore NuGet packages**:
   ```bash
   dotnet restore
   ```

2. **Run the Application**:
   ```bash
   dotnet run
   ```

3. **Open your browser** and navigate to the URL shown in the console (usually `https://localhost:5001`)

That's it! The database is automatically created and seeded with sample data.

## Sample Data

The application includes pre-seeded data for:
- 3 Services (Oil Change, Custom Paint Job, Brakes Replacement)
- 3 Products (Performance air filter, LED Headlight Kit, Bucket Seats)

## Important Notes

- **Data Persistence**: Data is stored in memory and will be lost when the application stops
- **Development Only**: This setup is perfect for development and testing
- **Production**: For production, you would typically use SQL Server or another persistent database

## Troubleshooting

If you encounter issues:
1. Make sure all NuGet packages are restored: `dotnet restore`
2. Check that .NET 9.0 SDK is installed
3. Try cleaning and rebuilding: `dotnet clean && dotnet build`
