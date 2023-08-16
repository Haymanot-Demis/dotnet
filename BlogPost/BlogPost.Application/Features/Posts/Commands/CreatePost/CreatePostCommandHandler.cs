using AutoMapper;
using BlogPost.Application.Exceptions;
using BlogPost.Application.Interfaces.Repositories;
using BlogPost.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Posts.Commands.CreatePost
{
    internal class CreateCommentHandler : IRequestHandler<CreateCommentCommand, Post>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public CreateCommentHandler(IPostRepository repository, IMapper mapper) {
            _postRepository = repository;
            _mapper = mapper;
        }
        public async Task<Post> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePostCommandValidator();
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }
            var post = _mapper.Map<Post>(request);
            return await _postRepository.AddAsync(post);
        }
    }
}
