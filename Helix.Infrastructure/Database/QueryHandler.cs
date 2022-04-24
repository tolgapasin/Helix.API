using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace Helix.Infrastructure.Database
{
    public class QueryHandler : IQueryHandler
    {
        private string _connectionString;

        public QueryHandler(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql, object param = null)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                if (conn.State == ConnectionState.Open)
                {
                    var result = await conn.QueryAsync<T>(sql, param);
                    await conn.CloseAsync();

                    return result;
                }

                return null;
            }
        }
    }
}
