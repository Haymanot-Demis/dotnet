using Microsoft.AspNetCore.Mvc;
using WebApplication1.DBContexts;

[ApiController]
[Route("[controller]")]
public class CommentsController : ControllerBase{
    private readonly AppDBContext _context;

    public CommentsController(AppDBContext context)
    {
        _context = context;
    }

    [HttpGet("all")]    
    public IActionResult GetAll(){
        var comments = _context.Comments.ToList();
        return Ok(comments);
    }

    [HttpGet("{id}")]
    public IActionResult GetOne(int id){
        var comment = _context.Comments.Find(id);
        if (comment == null)
        {
            return NotFound();
        }
        comment.Post = _context.Posts.Where(p => p.PostId == comment.PostId).FirstOrDefault();
        Console.WriteLine(comment);
        return Ok(comment);
    }

    [HttpPost()]
    public async Task<IActionResult> Add(Comment comment){
        var result = await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
        return CreatedAtAction("Creating comment", comment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Comment comment){
        var result = await _context.Comments.FindAsync(id);
        if (result == null)
        {
            return NotFound();
        }

        // foreach (var prop in comment.GetType().GetProperties())
        // {
        //     var value = prop.GetValue(comment, null);
        //     if (value != null)
        //     {
        //         prop.SetValue(result, value, null);
        //     }
        // }

        _context.Entry(result).CurrentValues.SetValues(comment);      
        await _context.SaveChangesAsync();
        var updated = await _context.Comments.FindAsync(id);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id){
        var comment = _context.Comments.Find(id);
        if (comment == null)
        {
            return NotFound();
        }
        var res = _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}