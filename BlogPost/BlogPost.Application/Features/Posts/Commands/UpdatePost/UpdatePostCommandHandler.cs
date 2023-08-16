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

namespace BlogPost.Application.Features.Posts.Commands.UpdatePost
{
    internal class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Post>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Post> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post_tobe_updated = await _postRepository.GetByIdAsync(request.Id);

            if (post_tobe_updated == null)
            {
                throw new NotFoundException();
            }

            var validator = new UpdatePostCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var updated_post = _mapper.Map(request, post_tobe_updated);
            return updated_post;
        }
    }
}
