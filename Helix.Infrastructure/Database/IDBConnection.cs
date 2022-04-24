using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Helix.Infrastructure.Database
{
    public interface IDBConnection
    {
        SqlConnection GetConnection();
        Task<bool> Close();
        Task<bool> Open();
    }
}