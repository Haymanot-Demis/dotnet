using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

public class UpdatePostsDto
{
    [DataType(DataType.Text)]
    [StringLength(50)]
    public string? Title { get; set; }

    [DataType(DataType.Text)]
    public string? Content { get; set; }
}