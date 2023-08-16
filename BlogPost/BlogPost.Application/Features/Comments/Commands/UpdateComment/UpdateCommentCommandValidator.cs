using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(1).WithMessage("Post id can't be less than 1");
            RuleFor(x => x.Title).ToString();
            RuleFor(x => x.Content).ToString();
        }
    }
}
