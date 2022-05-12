using System;
using System.Runtime.Serialization;
using MediatR;

namespace Helix.Core.Commands.Posts
{
    [DataContract]
    public class UpdatePostCommand : IRequest<int>//: UpsertPostCommand
    {
        [DataMember]
        public Guid PostId { get; private set; }

        [DataMember]
        public string Content { get; private set; }

        public UpdatePostCommand(Guid postId, string content) //: base(postId, content)
        {
            PostId = postId;
            Content = content;
        }
    }
}
