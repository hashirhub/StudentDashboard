# Deployment Instructions

1. Install Visual Studio with ASP.NET workload and .NET 10 SDK.
2. Open `StudentDashboard.slnx` from the root folder.
3. Restore NuGet packages.
4. Run the `StudentDashboard.Web` startup project.
5. The SQLite database file is created automatically on first run using seed data.
6. For production, replace demo authentication with ASP.NET Core Identity and configure a production database connection string.

The project uses classic Blazor Server hosting with `MapBlazorHub()` and `_Host.cshtml`, so it does not depend on `REMOVED_RENDER_MODE` render mode syntax.
