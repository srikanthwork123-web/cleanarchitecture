using EmployeeApi.Application.Common.Interfaces;
using EmployeeApi.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<SqlConnectionFactory>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        return services;
    }
}
