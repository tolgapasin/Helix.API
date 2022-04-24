using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Helix.Infrastructure.Database
{
    public class DBConnection : IDBConnection
    {
        private SqlConnection _connection;

        public DBConnection(string connectionString)
        {
            Initialise(connectionString);
        }

        public void Initialise(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }

        public async Task<bool> Open()
        {
            try
            {
                await _connection.OpenAsync();
            }
            catch (System.Exception ex)
            {

            }


            if (_connection.State == ConnectionState.Open)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Close()
        {
            try
            {
                await _connection.CloseAsync();
            }
            catch (System.Exception ex)
            {

            }


            if (_connection.State == ConnectionState.Closed)
            {
                return true;
            }

            return false;
        }
    }
}
