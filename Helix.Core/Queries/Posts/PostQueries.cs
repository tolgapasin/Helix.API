using System;
using System.Collections.Generic;
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
            //var post = new Post();

            string sql = @"
                            SELECT [PostId]
                                  ,[Content]
                                  ,[DateCreated]
                                  ,[CreatedBy]
                                  ,[UpdatedDate]
                                  ,[UpdatedBy]
                            FROM [dbo].[Posts]";

            var result = await _queryHandler.ExecuteQuery<Post>(sql, new { });

            return result;
        }
    }
}
