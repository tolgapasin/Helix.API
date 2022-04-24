using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Helix.Infrastructure.Database
{
    public class CommandHandler : ICommandHandler
    {
        private string _connectionString;

        public CommandHandler(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> ExecuteCommandAsync(string sql)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                if (conn.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    var result = await cmd.ExecuteNonQueryAsync();

                    await conn.CloseAsync();

                    return result;
                }
            }

            return 0;
        }
    }
}
