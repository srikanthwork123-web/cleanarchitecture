# EmployeeApi Workspace

- .NET 8 ASP.NET Core Web API.
- Use Clean Architecture boundaries: API depends on Application and Infrastructure; Application depends on Domain; Infrastructure implements Application abstractions.
- Employee persistence uses Dapper with SQL Server stored procedures only.
- Keep nullable reference types and implicit usings enabled.
- Verify changes with `dotnet build EmployeeApi.slnx`.
