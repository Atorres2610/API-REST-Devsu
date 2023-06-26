using Dapper;
using Devsu.Core.Contracts.Queries;
using Devsu.Core.Features.Reporte.Queries;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Devsu.Infrastructure.Queries
{
    public class ReporteQuery : IReporteQuery
    {
        private readonly string? connectionString;

        public ReporteQuery(IConfiguration configuration)
        {
            connectionString = ConfigurationExtensions.GetConnectionString(configuration, "DefaultConnection");
        }

        public async Task<IEnumerable<EstadoCuentaResponse>> EstadoCuenta(int idCliente, DateTime? fechaInicio, DateTime? fechaFin)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<EstadoCuentaResponse>("sp_ReporteEstadoCuenta", param: new { idCliente, fechaInicio, fechaFin }, commandType: CommandType.StoredProcedure);
        }
    }
}
