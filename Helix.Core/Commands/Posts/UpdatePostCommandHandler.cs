using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Helix.Core.Commands.Posts
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, int>
    {
        public UpdatePostCommandHandler()
        {
        }

        public Task<int> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
