using EmployeeApi.Application.Common.Interfaces;
using EmployeeApi.Application.Employees.Dtos;
using EmployeeApi.Domain.Entities;

namespace EmployeeApi.Application.Employees;

public sealed class EmployeeService(IEmployeeRepository repository)
{
    public async Task<IReadOnlyList<EmployeeResponse>> GetAllAsync(CancellationToken cancellationToken) =>
        (await repository.GetAllAsync(cancellationToken)).Select(Map).ToList();

    public async Task<EmployeeResponse?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var employee = await repository.GetByIdAsync(id, cancellationToken);
        return employee is null ? null : Map(employee);
    }

    public Task<int> CreateAsync(CreateEmployeeRequest request, CancellationToken cancellationToken) =>
        repository.CreateAsync(ToEntity(request), cancellationToken);

    public async Task<bool> UpdateAsync(int id, UpdateEmployeeRequest request, CancellationToken cancellationToken)
    {
        var employee = new Employee(request.FirstName, request.LastName, request.Email, request.PhoneNumber, request.Department, request.Salary, request.HireDate, id);
        return await repository.UpdateAsync(employee, cancellationToken);
    }

    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken) => repository.DeleteAsync(id, cancellationToken);

    private static Employee ToEntity(CreateEmployeeRequest request) => new(request.FirstName, request.LastName, request.Email, request.PhoneNumber, request.Department, request.Salary, request.HireDate);

    private static EmployeeResponse Map(Employee employee) => new(employee.Id, employee.FirstName, employee.LastName, employee.Email, employee.PhoneNumber, employee.Department, employee.Salary, employee.HireDate);
}
