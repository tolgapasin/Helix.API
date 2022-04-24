using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Helix.Infrastructure.Database
{
    public class QueryHandler : IQueryHandler
    {
        private IDBConnection _connection;

        public QueryHandler(IDBConnection connection)
        {
            _connection = connection;
        }

        public async Task<SqlDataReader> ExecuteQuery(string sql)
        {
            if (await _connection.Open())
            {
                //create command and assign the query and connection from the constructor
                SqlCommand cmd = new SqlCommand(sql, _connection.GetConnection());

                //Execute command
                var result = await cmd.ExecuteReaderAsync();

                //close connection
                await _connection.Close();

                return result;
            }

            return null;
        }
    }
}
