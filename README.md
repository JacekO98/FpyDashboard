# FPY Dashboard

A web dashboard for monitoring First Pass Yield (FPY) across the Hydr, HydrBV, and Pneu production areas. It presents weekly and monthly production results, including first-pass OK/NOK counts, total units, and FPY percentages.

## Features

- Separate dashboards for Hydr, HydrBV, and Pneu.
- Weekly and monthly FPY summaries, with the latest 15 reporting periods shown for each view.
- Headline metrics for the latest week and month, monthly OK/NOK counts, and a comparison with the preceding period.
- SQL Server data access through Entity Framework Core and raw SQL queries.

FPY is calculated from the first recorded test for each `Serial_Nr`, ordered by test date and time:

```text
FPY = first-pass OK units / first-tested units * 100
```

## Technology

- .NET 8 / ASP.NET Core Razor Components (Blazor)
- Entity Framework Core 8
- Microsoft SQL Server

## Prerequisites

- .NET 8 SDK
- Access to a Microsoft SQL Server database containing the production result tables described below

## Database requirements

The application reads data from these tables in the `dbo` schema:

| Dashboard | Table | Required columns |
| --- | --- | --- |
| Hydr | `HydrResults1` | `Serial_Nr`, `Date`, `Time`, `Week_of_the_Year`, `General_Result` |
| HydrBV | `HydrBVResults1` | `Serial_Nr`, `Date`, `Time`, `Week_of_the_Year`, `General_Result` |
| Pneu | `PneuResults1` | `Serial_Nr`, `Date`, `Time`, `Week_of_the_Year`, `General` |

The result field is expected to be `1` for a passing test. The queries group results by the year and week/month values derived from the first test date. The monthly query returns month names using SQL Server's Polish language setting.

The repository does not include database migrations or scripts to create or seed these tables. The database and source tables must already exist before the dashboard can load results.

## Configuration

The connection string is read from `ConnectionStrings:FPYDashboard`. The checked-in `FPYDashboard/appsettings.json` contains a local SQL Server Express example. Override it for your environment; for example, in PowerShell:

```powershell
$env:ConnectionStrings__FPYDashboard = "Server=YOUR_SERVER;Database=FPYDashboard;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"
```

Use the authentication method and connection options appropriate for your SQL Server. Avoid committing credentials or other secrets to source control. The connection must allow the app to read the tables listed above.

## Run locally

From the repository root:

```powershell
dotnet restore .\FPYDashboard.sln
dotnet build .\FPYDashboard.sln
dotnet run --project .\FPYDashboard\FPYDashboard.csproj
```

Open the local URL printed by `dotnet run`. The root route displays HydrBV; the other dashboards are available at `/Hydr` and `/Pneu`.

## Solution structure

```text
FPYDashboard.sln
|-- FPYDashboard/                  # ASP.NET Core UI, routes, and app configuration
|-- FPY.UseCase/                   # Use cases and their interfaces
|-- FPY.CoreBussines/              # Weekly and monthly FPY result models
`-- Plugins/Plugins.EFCoreSql/     # SQL Server DbContext and repository queries
```

## Data limitations

- A product is counted once per `Serial_Nr`, using its earliest test record in the corresponding source table.
- Weekly grouping uses the source table's `Week_of_the_Year` value.
- Results are read directly from SQL Server when a dashboard route is rendered; unavailable database connectivity or missing tables will prevent the results from loading.
