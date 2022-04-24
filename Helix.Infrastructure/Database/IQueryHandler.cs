using System.Collections.Generic;
using System.Threading.Tasks;

namespace Helix.Infrastructure.Database
{
    public interface IQueryHandler
    {
        Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql, object param = null);
    }
}