using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Comment
{
    [Key]   
    public int CommentId { get; set; }
    public int PostId { get; set; }
    public Post? Post { get; set; }
    public string? Text { get; set; }
    public string? Author { get; set; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}