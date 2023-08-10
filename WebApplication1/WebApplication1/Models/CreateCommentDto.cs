using System.ComponentModel.DataAnnotations;

public class CreateCommentDto
{
    [Required]
    public int PostId { get; set; }
    
    [Required]
    [DataType(DataType.Text)]
    public string? Text { get; set; }
}