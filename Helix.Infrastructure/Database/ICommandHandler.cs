using System.Threading.Tasks;

namespace Helix.Infrastructure.Database
{
    public interface ICommandHandler
    {
        Task<int> ExecuteCommandAsync(string sql);
    }
}