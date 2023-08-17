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

namespace BlogPost.Application.Features.Comments.Commands.UpdateComment
{
    public class UpdateteCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Comment>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public UpdateteCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<Comment> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment_tobe_updated = await _commentRepository.GetByIdAsync(request.Id);

            if (comment_tobe_updated == null)
            {
                throw new NotFoundException();
            }

            var validator = new UpdateCommentCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid) 
            {
                throw new BadRequestException();
            }

            var updated_comment = _mapper.Map(request, comment_tobe_updated);
            return updated_comment;            
        }
    }
}
