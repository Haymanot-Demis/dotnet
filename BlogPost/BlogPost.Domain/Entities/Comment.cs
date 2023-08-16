using BlogPost.Domain.Common;

namespace BlogPost.Domain.Entities
{
    public class Comment: BaseEntity
    {
        public int PostId { get; set; }
        public string?  Text { get; set; }
        public Post? Post { get; set; }

    }
}