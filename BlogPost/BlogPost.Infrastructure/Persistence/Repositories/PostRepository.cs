using AutoMapper;
using BlogPost.Application.Interfaces.Repositories;
using BlogPost.Domain.Entities;
using BlogPost.Infrastructure.Persistence.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Infrastructure.Persistence.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDBContext _DBContext;
        private readonly IMapper _mapper;
        public PostRepository(AppDBContext context, IMapper mapper)
        {
            _DBContext = context;
            _mapper = mapper;
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            var post = await _DBContext.posts.FindAsync(id);
            return post;
        }

        public List<Post> GetAll()
        {
            return _DBContext.posts.ToList();
        }
        public async Task<Post> AddAsync(Post item)
        {
            // asynchronous adding
            var res = await _DBContext.posts.AddAsync(item);
            _DBContext.SaveChanges();
            return res.Entity;
        }

        public async Task<Post> UpdateAsync(Post item)
        {
            var post = await _DBContext.posts.FindAsync(item.Id);
            _mapper.Map(post, item);
            _DBContext.SaveChanges();
            return post;
        }

        public Task DeleteAsync(Post item)
        {
            var post = _DBContext.posts.FindAsync(item.Id);
            _DBContext.posts.Remove(item);
            _DBContext.SaveChanges();
            return Task.CompletedTask;
        }

    }
}
