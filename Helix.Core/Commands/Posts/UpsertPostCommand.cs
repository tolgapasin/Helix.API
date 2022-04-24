using System;
using System.Runtime.Serialization;
using MediatR;

namespace Helix.Core.Commands.Posts
{

    [DataContract]
    public class UpsertPostCommand : IRequest<int>
    {
        [DataMember]
        public Guid? PostId { get; private set; }

        [DataMember]
        public string Content { get; private set; }

        public UpsertPostCommand(
            Guid? postId,
            string content)
        {
            PostId = postId;
            Content = content;
        }

    }
}
