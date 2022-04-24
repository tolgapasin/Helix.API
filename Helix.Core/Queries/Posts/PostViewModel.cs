using System;
namespace Helix.Core.Queries.Posts
{
    public class Post
    {
        public Guid PostId { get; private set; }

        public string Content { get; private set; }

        public DateTime DateCreated { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime UpdatedDate { get; private set; }

        public Guid UpdatedBy { get; private set; }

        public Post(Guid postId,
                                string content,
                                DateTime dateCreated,
                                Guid createdBy,
                                DateTime updatedDate,
                                Guid updatedBy)
        {
            PostId = postId;
            Content = content;
            DateCreated = dateCreated;
            CreatedBy = createdBy;
            UpdatedDate = updatedDate;
            UpdatedBy = updatedBy;
        }
    }
}
