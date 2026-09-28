namespace EmployeeApi.Domain.Entities;

public sealed class Employee
{
    public int Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string? PhoneNumber { get; private set; }
    public string Department { get; private set; } = string.Empty;
    public decimal Salary { get; private set; }
    public DateTime HireDate { get; private set; }

    public Employee(string firstName, string lastName, string email, string? phoneNumber, string department, decimal salary, DateTime hireDate, int id = 0)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Department = department;
        Salary = salary;
        HireDate = hireDate;
    }

    public void Update(string firstName, string lastName, string email, string? phoneNumber, string department, decimal salary, DateTime hireDate)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Department = department;
        Salary = salary;
        HireDate = hireDate;
    }
}
