using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DBContexts;

[ApiController]
[Route("[controller]")]
public class CommentsController : ControllerBase{
    private readonly AppDBContext _context;
    private readonly IMapper _mapper;

    public CommentsController(AppDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
        return Ok(comment);
    }

    [HttpPost()]
    public async Task<IActionResult> Add(CreateCommentDto comment){
        var result = await _context.Comments.AddAsync(_mapper.Map<Comment>(comment));
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetOne), new {id = result.Entity.CommentId}, comment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCommentDto comment){
        var comment_tobe_updated = await _context.Comments.FindAsync(id);
        if (comment_tobe_updated == null)
        {
            return NotFound();
        }

        _mapper.Map(comment, comment_tobe_updated);
        await _context.SaveChangesAsync();
        return Ok(comment_tobe_updated);
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