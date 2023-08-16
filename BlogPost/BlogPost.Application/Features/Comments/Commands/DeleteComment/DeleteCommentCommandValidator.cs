using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandValidator : AbstractValidator<DeleteCommentCommand>
    {
        public DeleteCommentCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(1).WithMessage("Comment id can't be less than 1");
        }
    }
}
