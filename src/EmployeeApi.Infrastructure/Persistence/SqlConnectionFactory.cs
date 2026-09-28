using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EmployeeApi.Infrastructure.Persistence;

public sealed class SqlConnectionFactory(IConfiguration configuration)
{
    private readonly string connectionString = configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("ConnectionStrings:DefaultConnection is not configured.");

    public IDbConnection CreateConnection() => new SqlConnection(connectionString);
}
