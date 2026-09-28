# EmployeeApi

.NET 8 ASP.NET Core Web API using Clean Architecture, Dapper, SQL Server, and stored procedures for employee CRUD.

## Layers

- `EmployeeApi.Domain`: Employee entity.
- `EmployeeApi.Application`: DTOs, service, and repository abstraction.
- `EmployeeApi.Infrastructure`: SQL connection factory and Dapper stored-procedure repository.
- `EmployeeApi.Api`: HTTP controllers and composition root.

## Run

1. Execute `database/001_CreateEmployees.sql` and `database/002_EmployeeProcedures.sql` against SQL Server.
2. Update `ConnectionStrings:DefaultConnection` in `src/EmployeeApi.Api/appsettings.json`.
3. Run `dotnet build EmployeeApi.slnx`.
4. Run `dotnet run --project src/EmployeeApi.Api` and open Swagger in the development environment.

Endpoints: `GET/POST /api/employees`, `GET/PUT/DELETE /api/employees/{id}`.
