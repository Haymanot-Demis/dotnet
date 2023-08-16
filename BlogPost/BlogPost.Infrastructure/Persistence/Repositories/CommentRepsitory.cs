using BlogPost.Application.Interfaces.Repositories;
using BlogPost.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Infrastructure.Persistence.Repositories
{
    internal class CommentRepsitory : ICommentRepository
    {
        private readonly List<Comment> _comments;   
        public CommentRepsitory()
        {
            _comments = new List<Comment>();
        }

        public Task<List<Comment>> GetAllAsync()
        {
            var comments = _comments.ToList();
            return Task.FromResult(comments);
        }

        public Task<Comment> AddAsync(Comment item)
        {
            _comments.Add(item);
            var commment = _comments.FirstOrDefault(c => c.Id == item.Id);
            return Task.FromResult(commment);
        }
        public Task<Comment> GetByIdAsync(int id)
        {
            var comment = _comments.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(comment);
        }
        public Task<Comment> UpdateAsync(Comment item)
        {
            var comment = _comments.FirstOrDefault(c => c.Id == item.Id);
            return Task.FromResult(comment);
        }
        public Task DeleteAsync(Comment item)
        {
            var comment = _comments.FirstOrDefault(c => c.Id == item.Id);
            _comments.Remove(comment);
            return Task.CompletedTask;
        }

    }

}
