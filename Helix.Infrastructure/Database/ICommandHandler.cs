using System.Threading.Tasks;

namespace Helix.Infrastructure.Database
{
    public interface ICommandHandler
    {
        //void Delete(string sql);
        Task<int> Insert(string sql);
        //void Update(string sql);
    }
}