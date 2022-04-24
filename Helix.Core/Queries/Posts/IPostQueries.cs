using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Helix.Core.Queries.Posts
{
    public interface IPostQueries
    {
        Task<IEnumerable<Post>> GetPostsAsync();
        Task<Post> GetPostByIdAsync(Guid postId);
    }
}