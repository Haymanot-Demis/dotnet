using BlogPost.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest<Comment>
    {
        public int Id { get; set;}
        public string? Title { get; set;}
        public string? Content { get; set;}
    }
}
