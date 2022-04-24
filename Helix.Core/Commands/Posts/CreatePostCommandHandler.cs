using System;
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
                    ('{Guid.NewGuid()}'
                    ,'{request.Content}'
                    ,'{DateTime.Now}'
                    ,'{userId}'
                    ,'{DateTime.Now}'
                    ,'{userId}');";

            var response = await _commandHandler.Insert(sql);

            if (response != 0)
                return response;

            return 0;
        }
    }
}
