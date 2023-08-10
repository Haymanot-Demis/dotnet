using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

public class Post
{
    [Key]
    public int PostId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Content { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; init; }

    public ICollection<Comment>? Comments { get; set;}

    public Post()
    {
        CreatedAt = DateTime.UtcNow;
        Comments = new List<Comment>();
    }


    /*
    public Post(int id, string title,string content)
    {
        PostId = id;
        Title = title;
        Content = content;
        CreatedAt = DateTime.UtcNow;
        Comments = new List<Comment>();
    }*/
}   