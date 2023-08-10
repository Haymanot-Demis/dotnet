using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Comment
{
    [Key]   
    public int CommentId { get; set; }

    [Required]
    public int PostId { get; set; }
    public Post? Post { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string? Text { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}