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

namespace BlogPost.Application.Features.Comments.Commands.CreateComment
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, Comment>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CreateCommentHandler(ICommentRepository repository, IMapper mapper) {
            _commentRepository = repository;
            _mapper = mapper;
        }
        public async Task<Comment> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCommentCommandValidator();
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid) 
            {
                throw new BadRequestException();
            }
            var comment = _mapper.Map<Comment>(request);
            return await _commentRepository.AddAsync(comment);
        }
    }
}
