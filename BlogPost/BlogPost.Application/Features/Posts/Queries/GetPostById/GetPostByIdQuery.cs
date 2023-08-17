using BlogPost.Application.Interfaces.Repositories;
using BlogPost.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Posts.Queries.GetPostById
{
    public class GetPostByIdQuery : IRequest<Post>
    {
        public int Id { get; set; }
    }
}
