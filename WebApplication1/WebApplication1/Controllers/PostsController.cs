using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DBContexts;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase{
    private readonly AppDBContext _context;
    private readonly IMapper _mapper;

    public PostsController(AppDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("all")]
    public IActionResult GetAll(){
        var posts = _context.Posts.ToList();
        return Ok(posts);
    }

    [HttpGet("{id}"), ActionName("GetOne")]
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
    public async Task<IActionResult> Add(CreatePostDto post){
        var res =  await _context.Posts.AddAsync(_mapper.Map<Post>(post));
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetOne), new {Id = res.Entity.PostId} , res.Entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdatePostsDto post){
        var post_tobe_changed = await _context.Posts.FindAsync(id);

        if (post_tobe_changed == null)
        {
            return NotFound();
        }

        _mapper.Map(post, post_tobe_changed);
        _context.SaveChanges();
        return Ok(post_tobe_changed);
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