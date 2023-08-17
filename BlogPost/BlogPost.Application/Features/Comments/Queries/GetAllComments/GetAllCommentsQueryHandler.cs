using AutoMapper;
using BlogPost.Application.Interfaces.Repositories;
using BlogPost.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Comments.Queries.GetAllComments
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, List<Comment>>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;
        public GetAllCommentsQueryHandler(IMapper mapper, ICommentRepository commentRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public Task<List<Comment>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = _mapper.Map<List<Comment>>(_commentRepository.GetAll());
            return Task.FromResult(comments);
        }
    }
}
