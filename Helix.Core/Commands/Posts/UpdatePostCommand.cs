using System;
namespace Helix.Core.Commands.Posts
{
    public class UpdatePostCommand : UpsertPostCommand
    {
        public UpdatePostCommand(Guid postId, string content) : base(postId, content)
        {
        }
    }
}
