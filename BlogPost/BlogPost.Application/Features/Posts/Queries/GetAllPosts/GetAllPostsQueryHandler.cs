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

namespace BlogPost.Application.Features.Posts.Queries.GetAllPosts
{
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, List<Post>>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        public GetAllPostsQueryHandler(IMapper mapper, IPostRepository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public Task<List<Post>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = _mapper.Map<List<Post>>(_postRepository.GetAll());
            return Task.FromResult(posts);
        }

    }
}
