using System.ComponentModel.DataAnnotations;

public class CreatePostDto
{
    [Required]
    [StringLength(50)]
    public string? Title { get; set; }
    [Required]
    public string? Content { get; set; }
}