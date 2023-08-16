using BlogPost.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<Comment>
    {
        public int PostId { get; set; } 
        public string? Text { get; set; }
    }
}
