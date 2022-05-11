using System;
using System.Threading;
using System.Threading.Tasks;
using Helix.Infrastructure.Database;
using MediatR;

namespace Helix.Core.Commands.Posts
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, int>
    {
        private ICommandHandler _commandHandler;

        public UpdatePostCommandHandler(ICommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public async Task<int> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            Guid userId = Guid.NewGuid();

            string sql = $@"
                UPDATE dbo.Posts
                SET Content = '{request.Content}', UpdatedDate = '{DateTime.Now}', UpdatedBy = '{userId}'
                WHERE PostId = '{request.PostId}'";

            var response = await _commandHandler.ExecuteCommandAsync(sql);

            if (response != 0)
                return response;

            return 0;
        }
    }
}
