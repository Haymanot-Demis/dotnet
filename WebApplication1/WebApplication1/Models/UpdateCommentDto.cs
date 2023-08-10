using System.ComponentModel.DataAnnotations;

public class UpdateCommentDto
{
    public int? PostId { get; set; }
    [DataType(DataType.Text)]
    public string? Text { get; set; }
}