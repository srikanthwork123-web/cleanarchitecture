using System.Data;
using Dapper;
using EmployeeApi.Application.Common.Interfaces;
using EmployeeApi.Domain.Entities;

namespace EmployeeApi.Infrastructure.Persistence;

public sealed class EmployeeRepository(SqlConnectionFactory connectionFactory) : IEmployeeRepository
{
    public async Task<IReadOnlyList<Employee>> GetAllAsync(CancellationToken cancellationToken)
    {
        using var connection = connectionFactory.CreateConnection();
        var command = new CommandDefinition("dbo.Employee_GetAll", commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken);
        return (await connection.QueryAsync<Employee>(command)).AsList();
    }

    public async Task<Employee?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        using var connection = connectionFactory.CreateConnection();
        var command = new CommandDefinition("dbo.Employee_GetById", new { Id = id }, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken);
        return await connection.QuerySingleOrDefaultAsync<Employee>(command);
    }

    public async Task<int> CreateAsync(Employee employee, CancellationToken cancellationToken)
    {
        using var connection = connectionFactory.CreateConnection();
        var command = new CommandDefinition("dbo.Employee_Create", new { employee.FirstName, employee.LastName, employee.Email, employee.PhoneNumber, employee.Department, employee.Salary, employee.HireDate }, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken);
        return await connection.ExecuteScalarAsync<int>(command);
    }

    public async Task<bool> UpdateAsync(Employee employee, CancellationToken cancellationToken)
    {
        using var connection = connectionFactory.CreateConnection();
        var command = new CommandDefinition("dbo.Employee_Update", new { employee.Id, employee.FirstName, employee.LastName, employee.Email, employee.PhoneNumber, employee.Department, employee.Salary, employee.HireDate }, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken);
        return await connection.ExecuteScalarAsync<int>(command) == 1;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        using var connection = connectionFactory.CreateConnection();
        var command = new CommandDefinition("dbo.Employee_Delete", new { Id = id }, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken);
        return await connection.ExecuteScalarAsync<int>(command) == 1;
    }
}
