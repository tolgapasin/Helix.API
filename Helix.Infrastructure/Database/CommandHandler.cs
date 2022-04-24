using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Helix.Infrastructure.Database
{
    public class CommandHandler : ICommandHandler
    {
        private IDBConnection _connection;

        public CommandHandler(IDBConnection connection)
        {
            _connection = connection;
        }

        //Insert statement
        public async Task<int> Insert(string sql)
        {
            if (await _connection.Open())
            {
                //create command and assign the query and connection from the constructor
                SqlCommand cmd = new SqlCommand(sql, _connection.GetConnection());

                //Execute command
                var result = await cmd.ExecuteNonQueryAsync();

                //close connection
                await _connection.Close();

                return result;
            }

            return 0;
        }

        ////Update statement
        //public void Update(string sql)
        //{
        //    //Open connection
        //    if (_connection.OpenConnection())
        //    {
        //        //create mysql command
        //        MySqlCommand cmd = new MySqlCommand();
        //        //Assign the query using CommandText
        //        cmd.CommandText = sql;
        //        //Assign the connection using Connection
        //        cmd.Connection = _connection.connection;

        //        //Execute query
        //        cmd.ExecuteNonQuery();

        //        //close connection
        //        _connection.CloseConnection();
        //    }
        //}

        ////Delete statement
        //public void Delete(string sql)
        //{
        //    if (_connection.OpenConnection() == true)
        //    {
        //        MySqlCommand cmd = new MySqlCommand(sql, _connection.connection);
        //        cmd.ExecuteNonQuery();
        //        _connection.CloseConnection();
        //    }
        //}
    }
}
