using BlogPost.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Posts.Queries.GetAllPosts
{
    public class GetAllPostsQuery : IRequest<List<Post>>
    {
    }
}
