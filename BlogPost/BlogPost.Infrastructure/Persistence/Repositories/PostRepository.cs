using BlogPost.Application.Interfaces.Repositories;
using BlogPost.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Infrastructure.Persistence.Repositories
{
    public class PostRepository : IPostRepository
    {
        private List<Post> posts;
        public PostRepository() 
        {
            posts = new List<Post>();
        }


        public async Task<Post> GetByIdAsync(int id)
        {
            var post = posts.Where(post => post.Id == id).FirstOrDefault();
            return await Task.FromResult(post);
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return posts.ToList();
        }
        public async Task<Post> AddAsync(Post item)
        {
            // asynchronous adding
            posts.Add(item);
            return item;
        }

        public async Task<Post> UpdateAsync(Post item)
        {
            var post = posts.FirstOrDefault(post => post.Id == item.Id);

            return post;
        }

        public Task DeleteAsync(Post item)
        {
            posts.Remove(item);
            return Task.CompletedTask;
        }

    }
}
