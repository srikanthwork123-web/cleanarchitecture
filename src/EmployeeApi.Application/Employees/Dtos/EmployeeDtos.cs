using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Application.Employees.Dtos;

public sealed record EmployeeResponse(int Id, string FirstName, string LastName, string Email, string? PhoneNumber, string Department, decimal Salary, DateTime HireDate);

public class CreateEmployeeRequest
{
    [Required, MaxLength(100)] public string FirstName { get; init; } = string.Empty;
    [Required, MaxLength(100)] public string LastName { get; init; } = string.Empty;
    [Required, EmailAddress, MaxLength(255)] public string Email { get; init; } = string.Empty;
    [MaxLength(30)] public string? PhoneNumber { get; init; }
    [Required, MaxLength(100)] public string Department { get; init; } = string.Empty;
    [Range(0, 999999999)] public decimal Salary { get; init; }
    public DateTime HireDate { get; init; }
}

public sealed class UpdateEmployeeRequest : CreateEmployeeRequest;
