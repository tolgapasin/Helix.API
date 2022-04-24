using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helix.Infrastructure.Database;

namespace Helix.Core.Queries.Posts
{
    public class PostQueries : IPostQueries
    {
        IQueryHandler _queryHandler;

        public PostQueries(IQueryHandler queryHandler)
        {
            _queryHandler = queryHandler;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            string sql = @"
                            SELECT [PostId]
                                  ,[Content]
                                  ,[DateCreated]
                                  ,[CreatedBy]
                                  ,[UpdatedDate]
                                  ,[UpdatedBy]
                            FROM [dbo].[Posts]";

            var result = await _queryHandler.ExecuteQueryAsync<Post>(sql, new { });

            return result;
        }

        public async Task<Post> GetPostByIdAsync(Guid postId)
        {
            string sql = $@"
                            SELECT [PostId]
                                  ,[Content]
                                  ,[DateCreated]
                                  ,[CreatedBy]
                                  ,[UpdatedDate]
                                  ,[UpdatedBy]
                            FROM [dbo].[Posts]
                            WHERE [PostId] = '{postId}'";

            var result = await _queryHandler.ExecuteQueryAsync<Post>(sql, new { postId });

            return result.FirstOrDefault();
        }
    }
}
