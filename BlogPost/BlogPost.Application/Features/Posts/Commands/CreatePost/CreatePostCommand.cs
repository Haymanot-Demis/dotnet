using BlogPost.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Posts.Commands.CreatePost
{
    public class CreateCommentCommand : IRequest<Post>
    {
        public string? Title { get; set; } 
        public string? Content { get; set; }
    }
}
