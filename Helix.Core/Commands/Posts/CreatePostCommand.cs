using System.Runtime.Serialization;
using MediatR;

namespace Helix.Core.Commands.Posts
{
    [DataContract]
    public class CreatePostCommand : IRequest<int>
    {
        [DataMember]
        public string Content { get; private set; }

        public CreatePostCommand(string content)
        {
            Content = content;
        }

    }
}
