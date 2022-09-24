using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Helix.Infrastructure.Database;
using MediatR;

namespace Helix.Core.Commands.Posts
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private ICommandHandler _commandHandler;

        public CreatePostCommandHandler(ICommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            Guid userId = Guid.NewGuid();

            string sql = $@"
                INSERT INTO dbo.Posts
                    (PostId
                    ,Content
                    ,DateCreated
                    ,CreatedBy
                    ,UpdatedDate
                    ,UpdatedBy)
                VALUES
                    (@PostId
                    ,@Content
                    ,@DateCreated
                    ,@CreatedBy
                    ,@UpdatedDate
                    ,@UpdatedBy);";


            var response = await _commandHandler.ExecuteCommandAsync(
                sql,
                new Dictionary<string, object>
                {
                    { "@PostId", Guid.NewGuid() },
                    { "@Content", request.Content },
                    { "@DateCreated", DateTime.Now },
                    { "@CreatedBy", userId },
                    { "@UpdatedDate",  DateTime.Now },
                    { "@UpdatedBy", userId }
                }
            );

            if (response != 0)
                return response;

            return 0;
        }
    }
}
