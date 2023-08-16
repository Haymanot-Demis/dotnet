using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Comments.Commands.CreateComment
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator() { 
            RuleFor(x => x.PostId).NotEmpty().GreaterThanOrEqualTo(1).WithMessage("Post id must be number greater than or equal to 1");
            RuleFor(x => x.Text).NotEmpty().WithMessage("Comment text is required").Length(10).WithMessage("Comment Text length must be more 10 chars");
        }
    }
}
