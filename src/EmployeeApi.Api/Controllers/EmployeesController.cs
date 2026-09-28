using EmployeeApi.Application.Employees;
using EmployeeApi.Application.Employees.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class EmployeesController(EmployeeService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<EmployeeResponse>>> GetAll(CancellationToken cancellationToken) => Ok(await service.GetAllAsync(cancellationToken));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<EmployeeResponse>> GetById(int id, CancellationToken cancellationToken)
    {
        var employee = await service.GetByIdAsync(id, cancellationToken);
        return employee is null ? NotFound() : Ok(employee);
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeResponse>> Create(CreateEmployeeRequest request, CancellationToken cancellationToken)
    {
        var id = await service.CreateAsync(request, cancellationToken);
        var employee = await service.GetByIdAsync(id, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, employee);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateEmployeeRequest request, CancellationToken cancellationToken) =>
        await service.UpdateAsync(id, request, cancellationToken) ? NoContent() : NotFound();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken) =>
        await service.DeleteAsync(id, cancellationToken) ? NoContent() : NotFound();
}
