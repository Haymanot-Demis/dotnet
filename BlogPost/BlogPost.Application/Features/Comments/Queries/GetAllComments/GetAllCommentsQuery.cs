using BlogPost.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Comments.Queries.GetAllComments
{
    public class GetAllCommentsQuery : IRequest<List<Comment>>
    {
    }
}
