using Microsoft.AspNetCore.Mvc;
using WebApplication1.DBContexts;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase{
    private readonly AppDBContext _context;

    public PostsController(AppDBContext context)
    {
        _context = context;
    }

    [HttpGet("all")]
    public IActionResult GetAll(){
        var posts = _context.Posts.ToList();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        var comments = _context.Comments.Where(c => c.PostId == id).ToList();  
        var post = await _context.Posts.FindAsync(id);
        if (post == null)
        {
            return NotFound();
        }

        post.Comments = comments;
        Console.WriteLine(post);
        return Ok(post);
    }

    [HttpPost()]
    public async Task<IActionResult> Add(Post post){
        
        if(ModelState.IsValid){
            return ValidationProblem();
        }

        var res =  await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
        return CreatedAtAction("Creating post", post);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Post post){
        var post_tobe_changed = await _context.Posts.FindAsync(id);

        if (post_tobe_changed == null)
        {
            return NotFound();
        }

        _context.Entry(post_tobe_changed).CurrentValues.SetValues(post);
        _context.SaveChanges();
        var updated = await _context.Posts.FindAsync(id);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var post = _context.Posts.Find(id);
        if (post == null)
        {
            return NotFound();
        }

        var res = _context.Posts.Remove(post);
        Console.WriteLine(res.GetType());
        _context.SaveChanges();
        return NoContent();
    }

}