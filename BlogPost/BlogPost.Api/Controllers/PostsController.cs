using AutoMapper;
using BlogPost.Application.DTO;
using BlogPost.Application.Features.Posts.Commands.CreatePost;
using BlogPost.Application.Features.Posts.Commands.DeletePost;
using BlogPost.Application.Features.Posts.Commands.UpdatePost;
using BlogPost.Application.Features.Posts.Queries.GetAllPosts;
using BlogPost.Application.Features.Posts.Queries.GetPostById;
using BlogPost.Application.Interfaces.Repositories;
using BlogPost.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogPost.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PostsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // GET: api/<PostsController>
        [HttpGet("all")]
        public async Task<ActionResult<List<Post>>> GetAll()
        {
            var query = new GetAllPostsQuery();
            var posts  = await _mediator.Send(query);
            return posts;
        }

        // GET api/<PostsController>/5
        [HttpGet("GetOne/{id}")]
        public async Task<ActionResult<Post>> GetOne(int id)
        {
            var post = await _mediator.Send(new GetPostByIdQuery { Id = id });
            return post;
        }

        // POST api/<PostsController>
        [HttpPost]
        public async Task<ActionResult<Post>> AddPost([FromBody] CreatePostCommand post)
        {
            var posted = _mapper.Map<Post>(await _mediator.Send(post));
            return CreatedAtAction(nameof(GetOne), new { Id = posted.Id }, posted);
        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> Put(int id, [FromBody] UpdatePostCommand post)
        {
            post.Id = id;
            var result = await _mediator.Send(post);
            return CreatedAtAction(nameof(GetOne), new { Id = result.Id }, result);
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(DeletePostCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
