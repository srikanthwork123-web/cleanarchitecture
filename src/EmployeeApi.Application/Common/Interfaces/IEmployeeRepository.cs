using EmployeeApi.Domain.Entities;

namespace EmployeeApi.Application.Common.Interfaces;

public interface IEmployeeRepository
{
    Task<IReadOnlyList<Employee>> GetAllAsync(CancellationToken cancellationToken);
    Task<Employee?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<int> CreateAsync(Employee employee, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(Employee employee, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}
