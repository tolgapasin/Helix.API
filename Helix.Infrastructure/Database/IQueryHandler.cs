using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Helix.Infrastructure.Database
{
    public interface IQueryHandler
    {
        Task<SqlDataReader> ExecuteQuery(string sql);
    }
}