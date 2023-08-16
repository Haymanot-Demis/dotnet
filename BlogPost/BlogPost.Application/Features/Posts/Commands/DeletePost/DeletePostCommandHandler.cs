using BlogPost.Application.Exceptions;
using BlogPost.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Posts.Commands.DeletePost
{
    internal class UpdatetePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IPostRepository _postRepository;

        public UpdatetePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeletePostCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid) 
            {
                throw new BadRequestException();
            }

            var post = await _postRepository.GetByIdAsync(request.Id);

            if (post == null)
            {
                throw new NotFoundException();
            }

            await _postRepository.DeleteAsync(post);                        
        }
    }
}
