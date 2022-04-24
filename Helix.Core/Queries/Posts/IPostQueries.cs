using System.Threading.Tasks;

namespace Helix.Core.Queries.Posts
{
    public interface IPostQueries
    {
        Task<bool> GetPostsAsync();
    }
}