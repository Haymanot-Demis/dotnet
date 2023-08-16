using BlogPost.Application.Exceptions;
using BlogPost.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteCommentCommandValidator();
            var validationResult = validator.Validate(request);
            var comment = await _commentRepository.GetByIdAsync(request.Id);

            if (comment == null)
            {
                throw new NotFoundException();
            }

            await _commentRepository.DeleteAsync(comment);
        }
    }
}
